using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.WebServer.Result
{
    public class TextResult : HttpResponce
    {
        public TextResult(string content, HttpResponceStatusCode responseStatusCode,
             string contentType = "text/plain; charset=utf-8") 
            : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", contentType));
            this.Content = Encoding.UTF8.GetBytes(content);
        }

        public TextResult(byte[] content, HttpResponceStatusCode responseStatusCode,
            string contentType = "text/plain; charset=utf-8") : base(responseStatusCode)
        {
            this.Headers.AddHeader(new HttpHeader("Content-Type", contentType));
            this.Content = content;
        }

    }
}
