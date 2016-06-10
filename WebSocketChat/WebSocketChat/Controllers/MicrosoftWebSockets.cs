using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using Microsoft.Web.WebSockets;

namespace WebSocketChat.Controllers
{
    public class MicrosoftWebSockets : WebSocketHandler
    {
        private static WebSocketCollection clients = new WebSocketCollection();
        private string name;

        public override void OnOpen()
        {           
            clients.Add(this);
            clients.Broadcast("connected");
        }

        public override void OnMessage(string message)
        {
            clients.Broadcast( message);
        }

        public override void OnClose()
        {
            clients.Remove(this);
            clients.Broadcast(string.Format("{0} has gone away.", name));
        }

    }
}