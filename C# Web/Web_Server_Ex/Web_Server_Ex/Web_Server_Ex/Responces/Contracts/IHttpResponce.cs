using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Responces.Contracts
{
   public   interface IHttpResponce
    {
        HttpResponceStatusCode StatusCode { get; set; }
        HttpHeaderCollection Headers { get; }
        byte[] Content { get; set; }
        void Addheader(HttpHeader header);
        byte[] GetBytes();

    }
}
