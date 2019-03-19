using System;
using System.Collections.Generic;
using System.Linq;
namespace _07._Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            var studentAndGradeDict = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                string studentName = Console.ReadLine();
                double studentGrade = double.Parse(Console.ReadLine());


                if (!studentAndGradeDict.ContainsKey(studentName))
                {
                    studentAndGradeDict.Add(studentName, new List<double>());
                    studentAndGradeDict[studentName].Add(studentGrade);
                }
                else
                {
                    studentAndGradeDict[studentName].Add(studentGrade);
                }
            }
            var betterStudents = studentAndGradeDict.Where(j => j.Value.Average() >= 4.50);

            foreach (var student in betterStudents
                .OrderByDescending(x => x.Value.Average()))
            {
                Console.WriteLine($"{student.Key} -> {student.Value.Average():f2}");
            }
        }
    }
}