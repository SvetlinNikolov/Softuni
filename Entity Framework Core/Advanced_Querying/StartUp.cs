namespace BookShop
{
    using Data;
    using Initializer;
    using System;
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
                string result = GetGoldenBooks(db);
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
    }
}
