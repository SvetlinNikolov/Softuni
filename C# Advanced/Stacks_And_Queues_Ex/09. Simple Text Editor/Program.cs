using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Simple_Text_Editor
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int countCommands = int.Parse(Console.ReadLine());

            Stack<char> text = new Stack<char>();
            Stack<string> rollback = new Stack<string>();

            rollback.Push("");

            for (int i = 0; i < countCommands; i++)
            {
                string[] commands = Console.ReadLine().Split().ToArray();

                int command = int.Parse(commands[0]);

                if (command == 1)
                {
                    foreach (var symbol in commands[1])
                    {
                        text.Push(symbol);

                    }
                    rollback.Push(commands[1]);
                }
                else if (command == 2)
                {
                    string temp = string.Empty;

                    for (int j = 0; j < int.Parse(commands[1]); j++)
                    {
                        
                        temp+=text.Pop();
                    }
                
                   
                }
                else if (command == 3)
                {

                    char[] printArray = text.Reverse().ToArray();

                    Console.WriteLine(printArray[int.Parse(commands[1]) - 1]);
                }
                else if (command == 4)
                {
                        char[] rollBackPop = rollback.Pop().ToCharArray();
                        text = new Stack<char>(rollBackPop);
                    //bate tva nema stane
                }

            }
        }
    }
}
