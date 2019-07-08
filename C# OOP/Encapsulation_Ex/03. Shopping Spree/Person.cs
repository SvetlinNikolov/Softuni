
namespace _03._Shopping_Spree
{

    using System;

    public class Person
    {
        private string name;

        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name
        {
            get { return name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(Exceptions.EmptyNameException);
                }
                name = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(Exceptions.InvalidMoneyValueException);
                }

                age = value;
            }
        }

    }
}
