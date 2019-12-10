using SIS.HTTP.Responces.Contracts;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Demo.App
{
   public abstract class BaseController
    {
        public IHttpResponce View([CallerMemberName] string view = "Home"  )
        {
            Console.WriteLine(view );
            return null;
        }
    }
}
