

namespace Streams_And_File_Directories
{
    using System;
    using System.IO;
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader(@"D:\african\Text.txt"))
            {
                using (var writer = new StreamWriter(@"D:\african\Kekst.txt"))

                {
                    int counter = 0;

                    while (true)
                    {


                        string currentLine = reader.ReadLine();

                        if (currentLine == null)
                        {
                            break;
                        }
                        else
                        {
                          

                            if (counter % 2 != 0)
                            {
                                writer.WriteLine(currentLine);
                            }

                            counter++;
                        }

                    }
                }
            }
        }
    }
}
