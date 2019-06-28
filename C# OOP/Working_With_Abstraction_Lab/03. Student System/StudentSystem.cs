using System;
using System.Collections.Generic;
using System.Text;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        public StudentSystem()
        {
            this.StudentInformation = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> StudentInformation { get; private set; }

        public void ExecuteCommand()
        {
            string[] currentCommand = Console.ReadLine().Split();

            if (currentCommand[0] == "Create")
            {
                var studentName = currentCommand[1];
                var studentAge = int.Parse(currentCommand[2]);
                var studentGrade = double.Parse(currentCommand[3]);

                if (!StudentInformation.ContainsKey(studentName))
                {
                    var student = new Student(studentName, studentAge, studentGrade);

                    StudentInformation[studentName] = student;
                }
            }
            else if (currentCommand[0] == "Show")
            {
                var studentName = currentCommand[1];

                if (StudentInformation.ContainsKey(studentName))
                {
                    var student = StudentInformation[studentName];

                    Console.WriteLine(student.ToString());

                }
                else if (currentCommand[0] == "Exit")
                {
                    Environment.Exit(0);
                }
            }
        }

    }

}
