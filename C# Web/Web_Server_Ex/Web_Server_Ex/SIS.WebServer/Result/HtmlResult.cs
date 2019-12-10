using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Result
{
    public class HtmlResult : HttpResponce
    {
        public HtmlResult(string content, HttpResponceStatusCode responceStatusCode)
            :base(responceStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", "text/html; charset=utf-8"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
