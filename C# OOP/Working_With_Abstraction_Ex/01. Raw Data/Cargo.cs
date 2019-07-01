using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
    public class Cargo
    {
        private int cargoWeight;
        private string cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.CargoType = cargoType;
            this.CargoWeight = cargoWeight;
        }

        public int CargoWeight { get => cargoWeight; set => cargoWeight = value; }
        public string CargoType { get => cargoType; set => cargoType = value; }
    }
}
