using System;

namespace _05.Attributes
{
    [Author("Ventsi")]
    public class StartUp
    {
        [Author("Gosho")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }

}
