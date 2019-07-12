using _05._Border_Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Border_Control.Models
{
    public class Pet : IName,IBirthDateable
    {
        public Pet(string name, DateTime birthDate)
        {
            this.Name = name;
            this.BirthDate = birthDate;
        }

        public string Name { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
