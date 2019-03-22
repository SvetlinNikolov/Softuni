using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Extract_File
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> path = Console.ReadLine().Split("\\").ToList();

            string[] fileNameAndExtension = path.Last().Split(".");

            string fileName = fileNameAndExtension[0];
            string fileExtension = fileNameAndExtension[1];

            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
            
        }
    }
}
