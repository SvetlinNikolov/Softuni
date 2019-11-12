namespace BookShop
{
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {
                //DbInitializer.ResetDatabase(db);

                var result = GetTotalProfitByCategory(db);
                Console.WriteLine(result);
            }


        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            StringBuilder resultTitles = new StringBuilder();

            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;

            command = ti.ToTitleCase(command);

            var bookTitles = context
                .Books
                .Select(c => new
                {
                    BookTitle = c.Title,
                    BookAgeRestriction = c.AgeRestriction
                })
                .Where(c => c.BookAgeRestriction.ToString() == command)
                .OrderBy(c => c.BookTitle.ToString())
                .ToList();


            foreach (var bookTitle in bookTitles)
            {
                resultTitles.AppendLine(bookTitle.BookTitle);
            }

            return resultTitles.ToString().TrimEnd();
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var goldenEditionBooks = context
                .Books
                .Select(e => new
                {
                    GoldenBookTitle = e.Title,
                    BookCopies = e.Copies,
                    EditionType = e.EditionType,
                    BookId = e.BookId
                })
                .Where(e => e.EditionType.ToString().ToLower() == "gold"
                && e.BookCopies < 5000)
                .OrderBy(e => e.BookId)
                .ToList();

            foreach (var book in goldenEditionBooks)
            {
                sb.AppendLine(book.GoldenBookTitle.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] bookCategories = input
                .ToLower()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            var booksWithCategory = context
                .Books
                .Where(b => b.BookCategories.Any(bc => bookCategories.Contains(bc.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            foreach (var title in booksWithCategory)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();




        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {

            StringBuilder sb = new StringBuilder();

            var dateParse = DateTime.ParseExact(date, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var booksReleasedBeforeDate = context
                .Books
                .Where(b => b.ReleaseDate < dateParse)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    Title = b.Title,
                    EditionType = b.EditionType,
                    Price = b.Price,
                    ReleaseDate = b.ReleaseDate
                })

                .ToList();


            foreach (var book in booksReleasedBeforeDate)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context
                .Authors
                .Where(a => !string.IsNullOrEmpty(a.FirstName) && a.FirstName.EndsWith(input))
                  .OrderBy(a => a.FirstName)
                  .ThenBy(a => a.LastName)
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName
                })
                .ToList();

            if (authors.Count != 0)
            {
                foreach (var author in authors)
                {
                    sb.AppendLine($"{author.FirstName} {author.LastName}");
                }
                return sb.ToString().TrimEnd();
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var booksContainingInput = context
                .Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(b => b.Title)
                .Select(b => new
                {
                    Title = b.Title
                })
                .ToList();

            foreach (var book in booksContainingInput)
            {
                sb.AppendLine(book.Title);
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authorAndBooks = context
                .Authors
                .Where(a => a.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(a => new
                {
                    AuthorName = a.FirstName + " " + a.LastName,

                    AuthorBooks = a.Books
                   .Select(ab => new
                   {
                       BookTitle = ab.Title,
                       BookID = ab.BookId
                   })
                   .OrderBy(b => b.BookID)
                   .ToList()


                })
                .ToList();


            foreach (var authorBooks in authorAndBooks)
            {

                foreach (var bookTitle in authorBooks.AuthorBooks)
                {

                    sb.AppendLine($"{bookTitle.BookTitle} ({authorBooks.AuthorName})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {

            var booksCount = context
                .Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return booksCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksByAuthorCount = context
                .Authors
                .Select(a => new
                {
                    AuthorName = string.Join(" ", a.FirstName, a.LastName),

                    BookCopies = a.Books
                        .Select(b => new
                        {
                            BookCopies = b.Copies
                        })
                       .Sum(x => x.BookCopies)

                })
                .OrderByDescending(b => b.BookCopies)
                .ToList();

            foreach (var authorBooks in booksByAuthorCount)
            {
                sb.AppendLine($"{authorBooks.AuthorName} - {authorBooks.BookCopies}");


            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var totalProfitPerCategory = context
          .Categories
          .Select(bc => new
          {
              CategoryName = bc.Name,

              BookPrices = bc.CategoryBooks
                            .Select(b => new
                            {
                                BookPrice = b.Book.Price * b.Book.Copies
                            })
                            .Sum(x => x.BookPrice)

          })
          .OrderByDescending(b => b.BookPrices)
          .ThenBy(b => b.CategoryName)
          .ToList();

            foreach (var categoryPrice in totalProfitPerCategory)
            {
                sb.AppendLine($"{categoryPrice.CategoryName} ${categoryPrice.BookPrices:f2}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
