using SIS.HTTP.Requests.Contracts;
using SIS.HTTP.Responces.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.App
{
    public class HomeController:BaseController
    {
        public IHttpResponce Home(IHttpRequest httpRequest)
        {
            return this.View();
        }
    }
}
