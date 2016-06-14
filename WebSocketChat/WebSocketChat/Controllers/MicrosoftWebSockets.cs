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
        //private static WebSocketCollection clients = new WebSocketCollection();
        private static List<MicrosoftWebSockets> clients= new List<MicrosoftWebSockets>();
       
        public override void OnOpen()
        {           
            clients.Add(this);         
            
        }

        public override void OnMessage(string message)
        {
           
            if (!message.Contains("keep active"))
            {
                var list = clients.Where(c => c.WebSocketContext.WebSocket != this.WebSocketContext.WebSocket);
                foreach (MicrosoftWebSockets socket in list)
                    socket.Send(message);
            }
        }

        public override void OnClose()
        {
            clients.Remove(this);            
        }

    }
}