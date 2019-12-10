using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SIS.WebServer.Result
{
    public class RedirectResult:HttpResponce
    {
        public RedirectResult(string location)
            :base(HttpResponceStatusCode.SeeOther)
        {
            this.Headers.AddHeader(new HttpHeader("Location", location));
        }
    }
}
