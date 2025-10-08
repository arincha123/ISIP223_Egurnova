using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Egurnova
{
    class Program
    {
        static List<Book> books = new List<Book>();

        class Book
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Author { get; set; }
            public string BookGenre { get; set; }
            public int Year { get; set; }
            public float Price { get; set; }

            public Book(int id, string title, string author, string genre, int year, float price)
            {
                Id = id;
                Title = title;
                Author = author;
                BookGenre = genre;
                Year = year;
                Price = price;
            }

            public enum Genre
            {
                Фантастика = 1,
                Детектив = 2,
                Роман = 3,
                Научная_литература = 4,
                Биография = 5
            }
        }

        private static void Print(Book book)
        {
            Console.WriteLine($"ID: {book.Id}\tНазвание: {book.Title}\tАвтор: {book.Author}\tЖанр: {book.BookGenre}\tГод: {book.Year}\tЦена: {book.Price}");
        }

        private static void Print(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine($"ID: {book.Id}\tНазвание: {book.Title}\tАвтор: {book.Author}\tЖанр: {book.BookGenre}\tГод: {book.Year}\tЦена: {book.Price}");
            }
        }

        public static void ShowAll()
        {
            Console.WriteLine("--- Все книги ---");
            if (books.Count == 0)
            {
                Console.WriteLine("Книги отсутствуют.");
                return;
            }

            foreach (Book book in books)
            {
                Print(book);
            }
        }

        private static string ChooseGenre()
        {
            Console.Write("Доступные жанры:\n1. Фантастика\n2. Детектив\n3. Роман\n4. Научная литература\n5. Биография\n");
            string input = Console.ReadLine();

            if (input == "2") return Book.Genre.Детектив.ToString();
            if (input == "3") return Book.Genre.Роман.ToString();
            if (input == "4") return Book.Genre.Научная_литература.ToString();
            if (input == "5") return Book.Genre.Биография.ToString();
            return Book.Genre.Фантастика.ToString();
        }

        static void AddBook()
        {
            Console.WriteLine("\n=== ДОБАВЛЕНИЕ НОВОЙ КНИГИ ===");

            Console.Write("Введите название книги: ");
            string title = Console.ReadLine();

            Console.Write("Введите автора книги: ");
            string author = Console.ReadLine();

            Console.Write("Введите жанр книги: ");
            string genre = ChooseGenre();

            Console.Write("Введите год издания: ");
            int year = Convert.ToInt32(Console.ReadLine());
            if (year < 1000 || year > DateTime.Now.Year)
            {
                Console.WriteLine("Неверный год издания!");
                return;
            }

            Console.Write("Введите цену книги: ");
            float price = Convert.ToSingle(Console.ReadLine());
            if (price < 0)
            {
                Console.WriteLine("Цена не может быть отрицательной!");
                return;
            }

            int newid = 1;
            if (books.Count > 0)
            {
                int maxId = 0;
                for (int j = 0; j < books.Count; j++)
                {
                    if (books[j].Id > maxId)
                    {
                        maxId = books[j].Id;
                    }
                }
                newid = maxId + 1;
            }

            Book newBook = new Book(newid, title, author, genre, year, price);
            books.Add(newBook);
            Console.WriteLine($"\nКнига успешно добавлена! ID");

        }

        static void RemoveBook()
        {
            Console.WriteLine("\n=== УДАЛЕНИЕ КНИГИ ===");
            ShowAll();

            Console.WriteLine("Введите номер (id) книги: ");
            int code = Convert.ToInt32(Console.ReadLine());

            var removebook = books.FirstOrDefault(x => x.Id == code);

            if (removebook != null)
            {
                books.Remove(removebook);
                Console.WriteLine("Книга успешно удалена!");
            }
            else
            {
                Console.WriteLine("Книга с указанным ID не найдена.");
            }
        }

        static void SearchBooks()
        {
            Console.WriteLine("\n=== ПОИСК КНИГ ===");
            Console.WriteLine("1. По названию");
            Console.WriteLine("2. По автору");
            Console.WriteLine("3. По жанру");
            Console.Write("Выберите тип поиска: ");

            int ser = Convert.ToInt32(Console.ReadLine());
            List<Book> sr = new List<Book>();

            switch (ser)
            {
                case 1:
                    Console.Write("Введите название: ");
                    string title = Console.ReadLine();
                    sr = books.Where(b => b.Title.ToLower().Contains(title.ToLower())).ToList();
                    Print(sr);

                    break;
                case 2:
                    Console.Write("Введите автора: ");
                    string author = Console.ReadLine();
                    sr = books.Where(b => b.Author.ToLower().Contains(author.ToLower())).ToList();
                    Print(sr);
                    
                    break;
                case 3:
                    Console.Write("Введите жанр: ");
                    string genre = Console.ReadLine();
                    sr = books.Where(b => b.BookGenre.ToLower().Contains(genre.ToLower())).ToList();
                    Print(sr);
                    break;
                default:
                    Console.WriteLine("Неверный выбор!");
                    return;
            }
        }

        static void SortBooks()
        {
            Console.WriteLine("\n=== СОРТИРОВКА КНИГ ===");
            Console.WriteLine("1. По названию");
            Console.WriteLine("2. По году издания");
            Console.Write("Выберите тип сортировки: ");

            int sortType = Convert.ToInt32(Console.ReadLine());
            List<Book> sb = new List<Book>();

            switch (sortType)
            {
                case 1:
                    sb = books.OrderBy(b => b.Title).ToList();
                    Console.WriteLine("Книги отсортированы по названию:");
                    break;
                case 2:
                    sb = books.OrderBy(b => b.Year).ToList();
                    Console.WriteLine("Книги отсортированы по году издания:");
                    break;
                default:
                    Console.WriteLine("Неверный выбор!");
                    return;
            }

            Print(sb);
        }

        static void ShowPriceExtremes()
        {
            Console.WriteLine("\n=== САМАЯ ДОРОГАЯ И ДЕШЁВАЯ КНИГА ===");

            if (books.Count == 0)
            {
                Console.WriteLine("Нет книг в библиотеке");
                return;
            }

            var che = books.OrderBy(b => b.Price).First();
            var exp = books.OrderByDescending(b => b.Price).First();

            Console.WriteLine("Самая дешёвая книга: ");
            Print(che);

            Console.WriteLine("Самая дорогая книга: ");
            Print(exp);

        }

        static void GroupByAuthors()
        {
            Console.WriteLine("\n=== ГРУППИРОВКА ПО АВТОРАМ ===");
            var groupa = books.GroupBy(b => b.Author);

            foreach (var group in groupa)
            {
                Console.WriteLine($"Автор: {group.Key}, Количество книг: {group.Count()}");
            }

        }

        static void Main(string[] args)
        {
            books.Add(new Book(1, "Тихий Дон", "Михаил Шолохов", "Роман", 1941, 450));
            books.Add(new Book(2, "Робинзон Крузо", "Даниэля Дефо", "Роман", 1719, 380));
            books.Add(new Book(3, "451 градус по Фаренгейту", "Рэй Брэдбери", "Фантастика", 1953, 399));
            books.Add(new Book(4, "Преступление и наказание", "Федор Достоевский", "Детектив", 1866, 229));
            books.Add(new Book(5, "Собачье сердце", "Михаил Булгаков", "Фантастика", 1925, 79));


            int a = -1;
            while (a != 0)
            {
                Console.Clear();
                Console.WriteLine("=== СИСТЕМА УПРАВЛЕНИЯ БИБЛИОТЕКОЙ ===");
                Console.WriteLine("1. Добавить книгу");
                Console.WriteLine("2. Удалить книгу");
                Console.WriteLine("3. Найти книги");
                Console.WriteLine("4. Сортировать книги");
                Console.WriteLine("5. Самая дорогая/дешёвая книга");
                Console.WriteLine("6. Группировка по авторам");
                Console.WriteLine("7. Показать все книги");
                Console.WriteLine("0. Выход");
                Console.Write("Выберите действие: ");

                Console.Write("Ваш выбор: ");
                a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        RemoveBook();
                        break;
                    case 3:
                        SearchBooks();
                        break;
                    case 4:
                        SortBooks();
                        break;
                    case 5:
                        ShowPriceExtremes();
                        break;
                    case 6:
                        GroupByAuthors();
                        break;
                    case 7:
                        ShowAll();
                        break;
                    case 0:
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор!");
                        break;
                }

                if (a != 0)
                {
                    Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}