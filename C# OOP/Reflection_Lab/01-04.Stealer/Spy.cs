using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;


public class Spy
{
    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        Type classType = Type.GetType(investigatedClass);

        FieldInfo[] classFields = classType.GetFields(
            BindingFlags.Instance
            | BindingFlags.Static
            | BindingFlags.NonPublic
            | BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });
        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var field in classFields.Where(f => requestedFields.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string AnalyzeAccessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] classPublicFields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();

        foreach (var publicField in classPublicFields)
        {
            sb.AppendLine($"{publicField.Name} must be private!");
        }

        foreach (var publicMethod in classPublicMethods)
        {
            sb.AppendLine($"{publicMethod.Name} must be public!");
        }

        foreach (var privateMethod in classNonPublicMethods)
        {
            sb.AppendLine($"{privateMethod.Name} must be private!");
        }
        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        string baseType = classType.BaseType.Name;

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All private methods of Class {classType}");
        sb.AppendLine($"Base Class: {baseType}");

        foreach (var item in privateMethods)
        {
            sb.AppendLine(item.Name);
        }
        return sb.ToString().TrimEnd();
    }

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] methodInfos = classType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (var getterAndSetter in methodInfos.Where(n => n.Name.StartsWith("get")))
        {
           
            sb.AppendLine($"{getterAndSetter.Name} will return {getterAndSetter.ReturnType}");
        }
        foreach (var getterAndSetter in methodInfos.Where(n => n.Name.StartsWith("set")))
        {
    
            sb.AppendLine($"{getterAndSetter.Name} will set field of {getterAndSetter.GetParameters().First().ParameterType}");
        }

        return sb.ToString().TrimEnd();
    }

}

