﻿using Logger.Factories;
using Logger.Models.Contracts;

using System;

namespace Logger.Core
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        public Engine(ILogger logger)
        {
            this.logger = logger;
            this.errorFactory = new ErrorFactory();
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] errorArgs = command.Split("|");

                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}
