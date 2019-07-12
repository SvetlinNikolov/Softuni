using _05._Border_Control.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05._Border_Control.Models
{
    public class Citizen: IName,IBirthDateable
    {
        public Citizen(string name, int age, string id,DateTime birthDate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthDate;
        }
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Id { get; private set; }

        public DateTime BirthDate { get; private set; }
    }
}
