﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Web.WebSockets;

namespace WebSocketChat.Controllers
{
    /// <summary>
    /// Summary description for Handler2
    /// </summary>
    public class Handler2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            if (context.IsWebSocketRequest)
            {               
                context.AcceptWebSocketRequest(new MicrosoftWebSockets());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}