using System;
using System.Collections.Generic;
using System.Text;

namespace Cars
{
    public class Tesla : Seat, ICar, IElectricCar
    {

        public Tesla(string model, string color, int batteries)
            : base(model, color)
        {
            this.Battery = batteries;
        }

        public int Battery { get; protected set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} {this.Battery} Batteries")
           .AppendLine(Start())
           .AppendLine(Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
