using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

public class CommandObjects
{
    public string HelloCommand(string[] args)
    {
        return $"Hello {args[0]}";
    }

    public string ExitCommand()
    {
        return null;

    }

    //public void ExecuteCommand(string[] args)
    //{
    //    string currentCommand = args[0];

    //    Type classType = Type.GetType(this.GetType().Name);

    //    MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);

    //    if (classPublicMethods.Any(x => x.Name == currentCommand))
    //    {
           
    //    }
    //}
}

