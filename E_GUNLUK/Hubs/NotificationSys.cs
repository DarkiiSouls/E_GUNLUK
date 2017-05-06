using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace E_GUNLUK.Models
{
    public class NotificationSys : Hub
    {
        public void SendNotification(string author, string message)
        {
            Clients.All.broadcastNotification(author, message);
        }
        public void Hello()
        {
            Clients.All.hello();
        }
    }
}