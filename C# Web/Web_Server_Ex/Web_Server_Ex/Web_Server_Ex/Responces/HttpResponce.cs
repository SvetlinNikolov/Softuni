using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;
using SIS.HTTP.Responces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Responces
{
    public class HttpResponce : IHttpResponce
    {
        public HttpResponce()
        {
           
        
        }
        public HttpResponce(HttpResponceStatusCode statusCode)
        {
            CoreValidator.ThrowIfNull(statusCode, nameof(statusCode));
            this.StatusCode = statusCode;
        }
        public HttpResponceStatusCode StatusCode { get ; set ; }

        public HttpHeaderCollection Headers { get; private set; } = new HttpHeaderCollection();

        public byte[] Content { get; set; } = new byte[0];

        public void Addheader(HttpHeader header)
        {
            this.Headers.AddHeader(header);
        }

        public byte[] GetBytes()
        {
            byte[] httpResponceWithoutBody = Encoding.UTF8.GetBytes(this.ToString());

            byte[] httpResponceWithBody = new byte[httpResponceWithoutBody.Length + this.Content.Length];

            for (int i = 0; i < httpResponceWithoutBody.Length; i++)
            {
                httpResponceWithBody[i] = httpResponceWithoutBody[i];
            }

            for (int i = 0; i < httpResponceWithBody.Length - httpResponceWithoutBody.Length; i++)
            {
                httpResponceWithBody[i + httpResponceWithoutBody.Length] = this.Content[i];
            }

            return httpResponceWithBody;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetStatusLine()}")
                .Append(GlobalConstants.HttpNewLine)
                .Append($"{this.Headers}")
                .Append(GlobalConstants.HttpNewLine) //double newline
                .Append(GlobalConstants.HttpNewLine);

            return sb.ToString();
        }
    }
}
