using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeShare.Frontend.Functions;
using CodeShare.Model.EF;
using CodeShare.Model.DAO;
using MoMo;
using Newtonsoft.Json.Linq;

namespace CodeShare.Frontend.Controllers
{
    public class PaysController : Controller
    {
        DataShareCodeEntities db = new DataShareCodeEntities();
        TakePricesDao takePricesDao = new TakePricesDao();
        // GET: Pays
        public ActionResult Index()
        {
            return View(db.Pakages.Where(n=>n.pakage_active == 1).OrderBy(n=>n.pakage_coin).ToList());
        }
        public ActionResult Details(int ? id)
        {
            return View(db.Pakages.Find(id));
        }
        public ActionResult PayMoMo(int? id)
        {
            var coo = new FunctionsController();
            var idus = coo.CookieID();

            Pakage pakage = db.Pakages.Find(id);

            var money = pakage.pakage_coin * 1000;

            //request params need to request to MoMo system
            string endpoint = "https://test-payment.momo.vn/gw_payment/transactionProcessor";
            string partnerCode = "MOMO5RGX20191128";
            string accessKey = "M8brj9K6E22vXoDB";
            string serectkey = "nqQiVSgDMy809JoPF6OzP5OdBUB550Y4";
            string orderInfo = "Nạp " + pakage.pakage_coin + " vào tài khoản " + idus.user_email;
            string returnUrl = "https://localhost:44327/Pays/ReturnUrl";
            string notifyurl = "https://localhost:44327/Pays/ReturnUrl";

            string amount = money.ToString();
            string orderid = Guid.NewGuid().ToString();
            string requestId = Guid.NewGuid().ToString();
            string extraData = "";

            //Before sign HMAC SHA256 signature
            string rawHash = "partnerCode=" +
                partnerCode + "&accessKey=" +
                accessKey + "&requestId=" +
                requestId + "&amount=" +
                amount + "&orderId=" +
                orderid + "&orderInfo=" +
                orderInfo + "&returnUrl=" +
                returnUrl + "&notifyUrl=" +
                notifyurl + "&extraData=" +
                extraData;

            MoMoSecurity crypto = new MoMoSecurity();
            string signature = crypto.signSHA256(rawHash, serectkey);
            //build body json request
            JObject message = new JObject
                {
                    { "partnerCode", partnerCode },
                    { "accessKey", accessKey },
                    { "requestId", requestId },
                    { "amount", amount },
                    { "orderId", orderid },
                    { "orderInfo", orderInfo },
                    { "returnUrl", returnUrl },
                    { "notifyUrl", notifyurl },
                    { "extraData", extraData },
                    { "requestType", "captureMoMoWallet" },
                    { "signature", signature }

                };

            string responseFromMomo = PaymentRequest.sendPaymentRequest(endpoint, message.ToString());
            JObject jmessage = JObject.Parse(responseFromMomo);

            Session["idpake"] = id; 

            return Redirect(jmessage.GetValue("payUrl").ToString());
        }
        public ActionResult ReturnUrl(int errorCode)
        {
            if(Session["idpake"] == null)
            {
                return RedirectToAction("History");
            }
            else
            {
                var coo = new FunctionsController();
                var id = coo.CookieID();

                User user = db.Users.Find(id.user_id);

                int idpake = int.Parse(Session["idpake"].ToString());
                Pakage pakage = db.Pakages.Find(idpake);

                if (errorCode.Equals(0))
                {
                    user.user_coin = user.user_coin + pakage.pakage_coin;
                    db.SaveChanges();

                    Bill bills = new Bill
                    {
                        bill_datecreate = DateTime.Now,
                        bill_active = true,
                        user_id = id.user_id,
                        pakege_id = pakage.pakege_id,
                        bill_dealine = DateTime.Now,
                        coin = pakage.pakage_coin
                    };
                    db.Bills.Add(bills);


                    History history = new History()
                    {
                        user_id = id.user_id,
                        his_datecreate = DateTime.Now,
                        his_content = id.user_name + " đã nạp thành công " + pakage.pakage_coin + " xu vào tài khoản" 
                    };
                    db.Historys.Add(history);

                    db.SaveChanges();
                    Session["idpake"] = null;
                    return RedirectToAction("History");
                }
                else
                {
                    Bill bills = new Bill
                    {
                        bill_datecreate = DateTime.Now,
                        bill_active = false,
                        user_id = id.user_id,
                        pakege_id = pakage.pakege_id,
                        bill_dealine = DateTime.Now.AddDays(10),
                        coin = pakage.pakage_coin
                    };
                    db.Bills.Add(bills);

                    db.SaveChanges();
                    Session["idpake"] = null;
                    return RedirectToAction("History");
                }
            }
        }
        public ActionResult History()
        {
            var coo = new FunctionsController();
            var id = coo.CookieID();

            Session["idpake"] = null;

            return View(db.Bills.Where(n=>n.user_id == id.user_id).ToList());
        }
        //Rut tien
        public ActionResult TakePrice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult TakePrice(TakePrice takePrice)
        {
            if (ModelState.IsValid)
            {
                var coo = new FunctionsController();
                var idus = coo.CookieID();

                User user = db.Users.Find(idus.user_id);

                user.user_coin = idus.user_coin - takePrice.tp_coin;
                db.SaveChanges();


                takePrice.user_id = idus.user_id;
                takePricesDao.Create(takePrice);
                TempData["noti_send_request"] = "success";
                return View();
            }
            return View();
        }

        // lich su rut tien
        public ActionResult HistoryTakePrice()
        {
            return View();
        }
    }
}