using _05._Border_Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Border_Control.Models
{
    public class Robot :ICommonTraits
    {

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
        public string Model { get; private set; }


        public string Id { get; private set; }


    }
}
