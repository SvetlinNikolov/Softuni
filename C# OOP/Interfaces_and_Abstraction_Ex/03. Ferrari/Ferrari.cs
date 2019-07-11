using System;
using System.Collections.Generic;
using System.Text;

namespace Ferrari
{
    public class Ferrari : IFerrariable
    {

        public Ferrari(string driver)
        {
            this.Driver = driver;
        }
        public string Model => "488-Spider";

        public string Driver { get; private set; }

        public string Accelerate()
        {
            return "Gas!";
        }

        public string Break()
        {
            return "Brakes!";
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            //488-Spider/Brakes!/Gas!/George
            sb.AppendLine($"{this.Model}/{this.Break()}/{this.Accelerate()}/{this.Driver}");

            return sb.ToString().TrimEnd();
        }
    }
}
