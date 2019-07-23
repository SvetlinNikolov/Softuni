using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ValidationAttributes.Attributes;

namespace ValidationAttributes.Attributes
{
    public class MyRequiredAttribute : MyValidationAttribute
    {

        public override bool IsValid(object obj)
        {
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
