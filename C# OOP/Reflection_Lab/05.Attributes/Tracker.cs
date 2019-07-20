using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _05.Attributes
{
    public class Tracker
    {
        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

            foreach (var method in methods)
            {
                if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
                {
                    var attributes = method.GetCustomAttributes(true);

                    foreach (AuthorAttribute authorAttribute in attributes)
                    {
                        Console.WriteLine($"{method.Name} is written by {authorAttribute.Name}");
                    }
                }
            }
           
        }
    }
}
