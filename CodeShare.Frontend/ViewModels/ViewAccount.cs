using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShare.Frontend.ViewModels
{
    public class ViewLogin
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class ViewRegister
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}