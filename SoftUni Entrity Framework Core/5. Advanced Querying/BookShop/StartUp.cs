namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
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
            //Console.WriteLine(GetBooksNotReleasedIn(db, 1998));
            //Console.WriteLine(GetBooksByCategory(db, "horror mystery drama"));
            //Console.WriteLine(GetBooksReleasedBefore(db, "30-12-1989"));
            //Console.WriteLine(GetAuthorNamesEndingIn(db, "dy"));
            //Console.WriteLine(GetBookTitlesContaining(db, "WOR"));
            //Console.WriteLine(GetBooksByAuthor(db, "po"));
            //Console.WriteLine(CountBooks(db, 40));
            //Console.WriteLine(CountCopiesByAuthor(db));
            //Console.WriteLine(GetTotalProfitByCategory(db));
            Console.WriteLine(GetMostRecentBooks(db));

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

            var books = context.Books
                .Where(b => b.ReleaseDate < lessThenYear || b.ReleaseDate > OverYear)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .AsEnumerable();

            return String.Join(Environment.NewLine, books);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] inputInfo = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(i => i.ToLower())
                .ToArray();

            var books = context.Books
                .Where(b => b.BookCategories
                .Any(bc => inputInfo.Contains(bc.Category.Name)))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .AsEnumerable();

            return string.Join(Environment.NewLine, books);
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            string formatDate = "dd-MM-yyyy";
            DateTime.Now.ToString(formatDate);
            DateTime inputDateTime = DateTime.Parse(date);

            var books = context.Books
                .Where(b => b.ReleaseDate < inputDateTime)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price,
                    b.ReleaseDate
                })
                .AsEnumerable();

            StringBuilder sb = new();

            foreach (var book in books.OrderByDescending(b => b.ReleaseDate))
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Books
                .Where(b => b.Author.FirstName.Substring(b.Author.FirstName.Length - input.Length) == input)
                .Select(b => new
                {
                    b.Author.FirstName,
                    b.Author.LastName
                })
                .Distinct()
                .OrderBy(b => b.FirstName)
                .ToList();

            StringBuilder sb = new();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var booksTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .AsEnumerable();

            return string.Join(Environment.NewLine, booksTitles);
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().Substring(0, input.Length) == input.ToLower())
                .Select(b => new
                {
                    b.Title,
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                    b.BookId
                })
                .OrderBy(b => b.BookId)
                .AsEnumerable();

            StringBuilder sb = new();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.AuthorName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var countBooks = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return countBooks;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var bookCopies = context.Books
                .Select(b => new
                {
                    AuthorName = b.Author.FirstName + " " + b.Author.LastName,
                    Copies = b.Author.Books.Sum(b => b.Copies)
                })
                .Distinct()
                .OrderByDescending(b => b.Copies)
                .AsEnumerable();

            StringBuilder sb = new();

            foreach (var bookCopy in bookCopies)
            {
                sb.AppendLine($"{bookCopy.AuthorName} - {bookCopy.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var profitByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    Profit = c.CategoryBooks.Sum(cb => cb.Book.Price * cb.Book.Copies)
                })
                .OrderByDescending(c => c.Profit)
                .ThenBy(c => c.Name)
                .AsEnumerable();

            StringBuilder sb = new();

            foreach (var profit in profitByCategory)
            {
                sb.AppendLine($"{profit.Name} - ${profit.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var mostRecentBooks = context.Categories
            .Select(c => new
            {
                CategoryName = c.Name,
                MostRecentBooks = c.CategoryBooks
                                             .OrderByDescending(cb => cb.Book.ReleaseDate)
                                             .Select(sb => new
                                             {
                                                 sb.Book.Title,
                                                 sb.Book.ReleaseDate,
                                             })
                                             .Take(3)
                                             .AsEnumerable()

            })
            .OrderBy(c => c.CategoryName)
            .AsEnumerable();

            StringBuilder sb = new();

            foreach (var bookCategory in mostRecentBooks)
            {
                sb.AppendLine($"--{bookCategory.CategoryName}");

                foreach (var bookName in bookCategory.MostRecentBooks)
                {
                    int year = bookName.ReleaseDate.Value.Year;
                    sb.AppendLine($"{bookName.Title} - {year}");
                }
            }

            return sb.ToString().TrimEnd();
        }
    }
}


