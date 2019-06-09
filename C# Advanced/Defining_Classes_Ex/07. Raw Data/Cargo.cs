using System;
using System.Collections.Generic;
using System.Text;

namespace _07._Raw_Data
{
    public class Cargo
    {
        public int CargoWeight { get; set; }
       
        public string CargoType { get; set; }
       
        public Cargo(int cargoWeight,string cargoType)
        {
            this.CargoType = cargoType;
            this.CargoWeight = cargoWeight;
        }
    }
}
