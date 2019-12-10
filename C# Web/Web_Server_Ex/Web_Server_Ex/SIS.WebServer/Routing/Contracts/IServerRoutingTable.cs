using SIS.HTTP.Enums;
using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responces;
using SIS.HTTP.Responces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Routing.Contracts
{
    public interface IServerRoutingTable
    {
        void Add(HttpRequestMethod method, string path, Func<IHttpRequest, IHttpResponce> func);
        bool Contains(HttpRequestMethod method, string path);
        Func<IHttpRequest, IHttpResponce> Get(HttpRequestMethod requestMethod, string path);
    }
}
