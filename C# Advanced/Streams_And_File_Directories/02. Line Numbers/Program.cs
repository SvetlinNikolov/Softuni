using System;
using System.IO;
namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
           
            using(var reader = new StreamReader("Text.txt"))
            {
                using(var writer = new StreamWriter("Kekst.txt"))
                {
                    string currentLine = reader.ReadLine();
                    int counter = 1;
                    while (currentLine != null)
                    {
                       
                        writer.WriteLine($"{counter}. {currentLine}");
                        counter++;
                        currentLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
