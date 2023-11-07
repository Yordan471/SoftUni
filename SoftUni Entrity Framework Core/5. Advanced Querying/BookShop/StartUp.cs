namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore.Storage;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));
            //Console.WriteLine(GetGoldenBooks(db));
            //Console.WriteLine(GetBooksByPrice(db));
            Console.WriteLine(GetBooksNotReleasedIn(db, 1998));

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {

            AgeRestriction ageRestriction = Enum.Parse<AgeRestriction>(command, true);

            var books = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToList();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            int copies = 5000;

            EditionType editionType = Enum.Parse<EditionType>("Gold");
            var books = context.Books
                .Where(b => b.EditionType == editionType &&
                            b.Copies < copies)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .AsEnumerable();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.Price > 40)               
                .Select(b => new
                {
                    BookTitle = b.Title,
                    b.Price
                })
                .OrderByDescending(b => b.Price)
                .AsEnumerable();

            StringBuilder sb = new();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.BookTitle} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            DateTime lessThenYear = new(year, 1, 1);
            DateTime OverYear = new(year, 12, 31);
            //DateTime dateTime = DateTime.Now;
            //Console.WriteLine(dateTime.ToString("MM / dd / yyyy"));
            //Console.WriteLine(dateTime);
            //lessThenYear = lessThenYear.ToString("MM/dd/yyyy");
            //var oneReleaseDate = context.Books.Where(b => b.BookId > 5).ToList();
            //foreach (var item in context.Books)
            //{
            //    if (lessThenYear < item.ReleaseDate && OverYear > item.ReleaseDate)
            //        Console.WriteLine("YES");
            //    else
            //        Console.WriteLine("NO");
            //}

            var books = context.Books
                .Where(b => b.ReleaseDate < lessThenYear || b.ReleaseDate > OverYear)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .AsEnumerable();

            return String.Join(Environment.NewLine, books);
        }
    }
}


