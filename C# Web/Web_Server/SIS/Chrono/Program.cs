using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Chrono
{
    class Program
    {
        static void Main(string[] args)
        {
            Chronometer chronometer = new Chronometer();
   

            while (true)
            {
                string command = Console.ReadLine();

                DoMagic(command, chronometer);
            }
           
            
          
        }
        static  void DoMagic(string command, Chronometer chronometer)
        {
           
                if (command == "exit")
                {
                    Environment.Exit(0);
                }
                else if (command == "start")
                {
                    chronometer.Start();
                }
                else if (command == "lap")
                {
                    Console.WriteLine(chronometer.Lap());
                }
                else if (command == "laps")
                {
                    if (chronometer.Laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                    }
                    else
                    {
                        Console.WriteLine(string.Join(Environment.NewLine, chronometer.Laps));
                    }

                }
                else if (command == "time")
                {
                    Console.WriteLine(chronometer.GetTime);
                }
                else if (command == "reset")
                {
                    chronometer.Reset();
                }
            
        }

     
    }
}
