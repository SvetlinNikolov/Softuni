using System;

namespace ValidPerson
{
    public class Person
    {
        private const int MIN_AGE = 0;
        private const int MAX_AGE = 120;

        private string firstName;
        private string lastName;
        private int age;


        public Person(string firstName,string lastName,int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (MIN_AGE > value || MAX_AGE < value)
                {
                    throw new ArgumentOutOfRangeException($"Age should be in the range [{MIN_AGE} ... {MAX_AGE}]");
                }
                this.age = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (NameIsNull(value))
                {
                    throw new ArgumentNullException("The first name cannot be null or empty.");
                }
                this.lastName = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                if (NameIsNull(value))
                {
                    throw new ArgumentNullException("The last name cannot be null or empty.");
                }
                this.firstName = value;
            }
        }

        private bool NameIsNull(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return true;
            }
            return false;
        }
    }
}
