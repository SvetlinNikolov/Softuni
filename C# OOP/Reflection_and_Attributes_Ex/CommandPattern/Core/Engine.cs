using System;
using System.Collections.Generic;
using System.Text;


public class Engine : IEngine
{
    private readonly ICommandInterpreter commandInterpreter;

    public Engine(ICommandInterpreter commandInterpreter)
    {
        this.commandInterpreter = commandInterpreter;
    }
    public void Run()
    {
        while (true)
        {
            string command = Console.ReadLine();

            string result = this.commandInterpreter.Read(command);

            Console.WriteLine(result);
        }
    }
}