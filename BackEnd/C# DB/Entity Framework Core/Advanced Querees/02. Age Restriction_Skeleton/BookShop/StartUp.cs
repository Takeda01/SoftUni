namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main()
        {

            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

         string cats = Console.ReadLine();

            Console.WriteLine(GetBooksByCategory(db,cats));

        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            if (!Enum.TryParse<AgeRestriction>(command,true, out var ageRestriction ))
            {
                return $"{command} is not a valid AgeRestriction!";
            }

            var books = context.Books.Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => new
                {
                    b.Title
                })
                .OrderBy(c => c.Title).ToList();    

            return string.Join(Environment.NewLine, books.Select(b => b.Title));
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var books = context.Books.Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .Select(b => new
                {
                    b.Title
                })
                .ToList();
            return string.Join(Environment.NewLine, books.Select(x => x.Title));
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books.Where(b => b.Price > 40).Select(b => new
            {
                b.Title,

                b.Price
            }).OrderByDescending(b => b.Price)
            .ToList();
            return String.Join(Environment.NewLine, books.Select(b => $"{b.Title} - ${b.Price:f2}"));
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var books = context.Books.Where(b => b.ReleaseDate.Value.Year != year).Select(b => new
            {
                b.Title
            }).ToList();
            
            
            return string.Join(Environment.NewLine, books.Select(x => x.Title));
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            string[] categories = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToLower()).ToArray();

            var books = context.Books.Select(b => new
            {
                b.Title,
                b.BookCategories
            }).Where(b => b.BookCategories.
            Any(bc => categories.Contains(bc.Category.Name.ToLower()))).OrderBy(b => b.Title).ToList();

            return String.Join(Environment.NewLine, books.Select(b => b.Title));
        }
    }
 }


