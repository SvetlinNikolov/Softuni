using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfInputs = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfInputs; i++)
            {
                List<string> parameters = Console.ReadLine()
                .Split(", ")
                .ToList();

                Article article = new Article();

                article.Title = parameters[0];
                article.Content = parameters[1];
                article.Author = parameters[2];

                articles.Add(article);
            }

            string sortBy = Console.ReadLine();

            if (sortBy == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (sortBy == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (sortBy == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            foreach (var article in articles)
            {
                Console.WriteLine($"{article.Title} - {article.Content}: {article.Author}");
            }
        }
    }

    class Article
    {
        public string Title;
        public string Content;
        public string Author;
    }
}