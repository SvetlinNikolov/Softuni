namespace _02._Average_Student_Grades
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> dict = new Dictionary<string, List<double>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] studentAndGrades = Console.ReadLine()
                    .Split();

                string name = studentAndGrades[0];
                double grade = double.Parse(studentAndGrades[1]);

                if (!dict.ContainsKey(name))
                {
                    dict[name] = new List<double>();
                    dict[name].Add(grade);
                }
                else if (dict.ContainsKey(name))
                {
                    dict[name].Add(grade);
                }
            }
            foreach (var kvp in dict)
            {
                string nameOfStudent = kvp.Key;
                List<double> gradesOfStudent = kvp.Value;
                Console.Write(nameOfStudent+" -> ");

                //Console.WriteLine($"{nameOfStudent} -> {string.Join(" ", gradesOfStudent)} (avg: {gradesOfStudent.Average():F2})");
                foreach (var grade in kvp.Value)
                {
                    Console.Write($"{grade:f2} ");
                }
                Console.WriteLine($"(avg: {kvp.Value.Average():f2})");
                
            }

        }
    }
}
