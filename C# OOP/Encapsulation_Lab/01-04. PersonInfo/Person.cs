using System;
using System.Collections.Generic;
using System.Text;

namespace PersonsInfo
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }
        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value < 460)
                {
                    throw new ArgumentException("Salary cannot be less than 460 leva!");
                }
                else
                {
                    this.salary = value;
                }
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age cannot be zero or a negative integer!");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                NameLenghtCheck(value);
                this.firstName = value;
            }
        }



        public string LastName
        {
            get { return lastName; }
            set
            {
                NameLenghtCheck(value);
                this.lastName = value;
            }
        }

        private void NameLenghtCheck(string value)
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }

        }
        public void IncreaseSalary(decimal percentage)
        {
            if (this.age < 30)
            {
                this.salary += this.salary * (percentage / 2) / 100;
            }
            else
            {
                this.salary += this.salary * (percentage / 100);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.firstName} {this.lastName} receives {this.salary:f2} leva.");
            return sb.ToString().TrimEnd();
        }
    }
}
