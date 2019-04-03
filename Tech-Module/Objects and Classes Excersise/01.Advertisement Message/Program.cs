using System;

namespace Advertisement_Message
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            string[] phrases = { "Excellent product.", "Such a great product.", "I always use that product.",
            "Best product of its category.", "Exceptional product.", "I can't live without this product."};

            string[] events = { "Now I feel good.", "I have succeeded with this product.",
            "Makes miracles. I am happy of the results!", "Try it yourself, I am very satisfied.", "I feel great!"};

            string[] authors = { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };

            string[] cities = { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            Random rnd = new Random();


            for (int i = 0; i < numberOfInputs; i++)
            {
                string resultString = string.Empty;
                int rndPhrase = rnd.Next(0, 6);
                int rndEvent = rnd.Next(0, 5);
                int rndAuthor = rnd.Next(0, 8);
                int rndCity = rnd.Next(0, 5);

                Console.WriteLine($"{phrases[rndPhrase]} {events[rndEvent]} {authors[rndAuthor]} - {cities[rndCity]}");
            }
        }
    }
}
