﻿using Logger.Exceptions;
using Logger.Models.Contracts;

using System;
using System.Linq;
using System.Reflection;

namespace Logger.Factories
{
    public class LayoutFactory
    {   
        public ILayout GetLayout(string type)
        {
            Assembly assembly = Assembly
                .GetExecutingAssembly();

            Type typeToCreate = assembly
                .GetTypes()
                .FirstOrDefault(c => c.Name == type);

            if (typeToCreate == null)
            {
                throw new InvalidLayoutTypeException();
            }

            ILayout layout = (ILayout)Activator.CreateInstance(typeToCreate);

            return layout;
        }
    }
}
