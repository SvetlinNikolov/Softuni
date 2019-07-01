using System;
using System.Collections.Generic;
using System.Text;

namespace P01_RawData
{
   public class Engine
    {
        private int engineSpeed;
        private int enginePower;

        public Engine(int engineSpeed,int enginePower)
        {
            this.EnginePower = enginePower;
            this.EngineSpeed = engineSpeed;
        }

        public int EngineSpeed { get => engineSpeed; set => engineSpeed = value; }
        public int EnginePower { get => enginePower; set => enginePower = value; }
    }
}
