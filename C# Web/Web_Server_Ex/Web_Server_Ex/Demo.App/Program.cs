﻿using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Result;
using SIS.WebServer.Routing;
using SIS.WebServer.Routing.Contracts;
using System;

namespace Demo.App
{
    class Program
    {
        static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Add(HttpRequestMethod.Get, "/", httpRequest =>
            {
                return new HomeController().Home(httpRequest);
            });
                
            Server server = new Server(8000, serverRoutingTable);
            server.Run();

        }
    }
}
