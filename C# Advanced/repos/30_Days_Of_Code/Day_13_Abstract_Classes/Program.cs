using System;

namespace Day_13_Abstract_Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string author = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());

            Book newNovel = new MyBook(title, author, price);
            newNovel.Display();
        }
    }

    abstract class Book
    {
        protected string title;
        protected string author;

        public Book(string t, string a)
        {
            title = t;
            author = a;
        }

        public abstract void Display();
    }

    class MyBook : Book
    {
        public decimal price;
        public MyBook(string title, string author, decimal price) : base(title, author)
        {

            this.price = price;
        }

        public override void Display()
        {
            Console.WriteLine($"Title: {title}");
            Console.WriteLine($"Author: {author}");
            Console.WriteLine($"Price: {price}");
        }
    }
}