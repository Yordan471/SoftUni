namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //Console.WriteLine(GetBooksByAgeRestriction(db, "miNor"));
            //Console.WriteLine(GetGoldenBooks(db));
            Console.WriteLine(GetBooksByPrice(db));

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
    }
}


