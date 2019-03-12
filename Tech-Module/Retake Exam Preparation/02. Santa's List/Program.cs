using System;
using System.Collections.Generic;
using System.Linq;
namespace _02._Santa_s_List
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> kidsSeparated = Console.ReadLine().Split("&").ToList();

            List<string> kids = Console.ReadLine().Split(" ").ToList();

            while (kids[0] != "Finished!")
            {
                string command = kids[0];
                string kidName = kids[1];

                if (command == "Bad")
                {
                    if (!kidsSeparated.Contains(kidName))
                    {
                        kidsSeparated.Insert(0, kidName);
                    }
                }
                if (command == "Good")
                {
                    if (kidsSeparated.Contains(kidName))
                    {
                        kidsSeparated.Remove(kidName);
                    }
                }
                if (command == "Rename")
                {
                    string oldName = kids[1];
                    string newName = kids[2];
                    int tempIndex = kidsSeparated.IndexOf(oldName);

                    if (kidsSeparated.Contains(oldName))
                    {
                        kidsSeparated[tempIndex] = newName;
                    }
                }
                if (command == "Rearrange")
                {
                    if (kidsSeparated.Contains(kidName))
                    {
                        string tempStoreName = kidName;
                        kidsSeparated.Remove(kidName);
                        kidsSeparated.Add(kidName);
                    }
                }
                kids = Console.ReadLine().Split(" ").ToList();
            }
            Console.WriteLine(string.Join(", ", kidsSeparated));

        }
    }
}
