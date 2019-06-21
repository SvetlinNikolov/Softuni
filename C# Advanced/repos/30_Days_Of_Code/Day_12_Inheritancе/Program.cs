using System;
using System.Linq;

namespace Day_12_Inheritancе
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            string firstName = input[0];
            string lastName = input[1];
            int id = int.Parse(input[2]);

            int numberOfScores = int.Parse(Console.ReadLine());
            var scoresInput = Console.ReadLine().Split();
            int[] scores = new int[numberOfScores];

            for (int i = 0; i < numberOfScores; i++)
            {
                scores[i] = int.Parse(scoresInput[i]);
            }

            Student student = new Student(firstName, lastName, id, scores);
            student.PrintPerson();
            Console.WriteLine($"Grade: {student.Calculate()}");
        }
    }

    class Person
    {
        public string FirstName;
        public string LastName;
        public int ID;


        public Person() { }
        public Person(string firstName, string lastName, int Id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = Id;
        }

        public void PrintPerson()
        {
            Console.WriteLine($"Name: {LastName}, {FirstName}");
            Console.WriteLine($"ID: {ID}");
        }
    }

    class Student : Person
    {
        public int[] TestScores;

        public Student(string firstName, string lastName, int id, int[] testScores)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ID = id;
            this.TestScores = testScores;
        }

        public char Calculate()
        {
            int sum = TestScores.Sum();

            double result = sum / TestScores.Length;

            if (result < 40)
            {
                return 'T';
            }
            else if (result >= 40 && result < 55)
            {
                return 'D';
            }
            else if (result >= 55 && result < 70)
            {
                return 'P';
            }
            else if (result >= 70 && result < 80)
            {
                return 'A';
            }
            else if (result >= 80 && result < 90)
            {
                return 'E';
            }
            else
            {
                return 'O';
            }
        }
    }
}