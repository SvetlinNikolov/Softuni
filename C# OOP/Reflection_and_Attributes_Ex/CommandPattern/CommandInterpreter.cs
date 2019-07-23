using System;
using System.Reflection;
using System.Linq;
public class CommandInterpreter : ICommandInterpreter
{
    private const string COMMAND_POSTFIX = "Command";

    public string Read(string inputLine)
    {
        var commandTokens
            = inputLine
           .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string currentCommand = commandTokens.First() + COMMAND_POSTFIX;

        string[] commandArgs = commandTokens.Skip(1).ToArray();

        Assembly assembly = Assembly.GetCallingAssembly();

        Type[] types = assembly.GetTypes();

        Type typeToCreate = types.FirstOrDefault(x => x.Name == currentCommand);

        if (typeToCreate == null)
        {
            throw new InvalidOperationException("The command does not exist!");
        }

        Object instance = Activator.CreateInstance(typeToCreate);

        ICommand command = (ICommand)instance;

        string result = command.Execute(commandArgs);

        return result;

    }
}

