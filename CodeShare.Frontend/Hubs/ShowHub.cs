using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeShare.Frontend.Hubs
{
    public class ShowHub : Hub
    {
        public static void Chat()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<ShowHub>();
            context.Clients.All.displayChat();
        }
    }
}