using SIS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIS.HTTP.Extensions
{
    public static class HttpResponceStatusExtensions
    {
       
        public static string GetStatusLine(this HttpResponceStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpResponceStatusCode.Ok:
                    return "200 Ok";
                  
                case HttpResponceStatusCode.Created:
                    return "201 Created";
                case HttpResponceStatusCode.Found:
                    return "302 Found";
                case HttpResponceStatusCode.SeeOther:
                    return "303 See Other";
                case HttpResponceStatusCode.BadRequest:
                    return "400 Bad Request";
                case HttpResponceStatusCode.Unauthorized:
                    return "401 Unathorized";
                case HttpResponceStatusCode.Forbidden:
                    return "403 Forbidden";
                case HttpResponceStatusCode.NotFound:
                    return "404 Not Found";
                case HttpResponceStatusCode.InternalServerError:
                    return "500 InternalServerError";
                default:
                    break;
            }
            return null;
        }
    }
}
