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



                Console.WriteLine(GetBooksByPrice(db));
            }


        }
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();

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
                sb.AppendLine(bookTitle.BookTitle);
            }

            return sb.ToString().TrimEnd();
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

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();

            var bookTitles = context
                 .Books
                 .Where(e => e.ReleaseDate.Value.Year != year)
                 .OrderBy(e => e.BookId)
                 .Select(e => new
                 {
                     BookTitle = e.Title
                 })
                 .ToList();

            foreach (var book in bookTitles)
            {
                sb.AppendLine(book.BookTitle.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var booksAndPrice = context
            .Books
            .Where(e => e.Price > 40)
            .OrderByDescending(e => e.Price )
           .Select(e => new
           {
               BookTitle = e.Title,
               BookPrice = e.Price
           }).ToList();

            foreach (var book in booksAndPrice)
            {
                sb.AppendLine($"{book.BookTitle} - ${book.BookPrice:f2}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
