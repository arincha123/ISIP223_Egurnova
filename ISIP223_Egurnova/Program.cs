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
            public decimal Price { get; set; }

            public Book(int id, string title, string author, string genre, int year, decimal price)
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
            Console.WriteLine("ID\tНазвание\tАвтор\tЖанр\tГод\tЦена");
            Console.WriteLine(book.Id + "\t" + book.Title + "\t\t" + book.Author + "\t" + book.BookGenre + "\t\t" + book.Year + "\t" + book.Price);
        }

        private static string ChooseGenre()
        {
            Console.Write("Доступные жанры:\t1. Фантастика\t2. Детектив\t3. Роман\t4. Научная литература\t5. Биография");
            string input = Console.ReadLine();

            if (input == "2") return Book.Genre.Детектив.ToString();
            if (input == "3") return Book.Genre.Роман.ToString();
            if (input == "4") return Book.Genre.Научная_литература.ToString();
            if (input == "5") return Book.Genre.Биография.ToString();
            return Book.Genre.Фантастика.ToString();
        }

        static void AddBook()
        {
            try
            {
                Console.WriteLine("\n=== ДОБАВЛЕНИЕ НОВОЙ КНИГИ ===");

                Console.Write("Введите название книги: ");
                string title = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(title))
                {
                    Console.WriteLine("Название книги не может быть пустым!");
                    return;
                }

                Console.Write("Введите автора книги: ");
                string author = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(author))
                {
                    Console.WriteLine("Автор книги не может быть пустым!");
                    return;
                }

                Console.Write("Введите жанр книги: ");
                string genre = ChooseGenre();

                Console.Write("Введите год издания: ");
                if (!int.TryParse(Console.ReadLine(), out int year) || year < 1000 || year > DateTime.Now.Year)
                {
                    Console.WriteLine("Неверный год издания!");
                    return;
                }

                Console.Write("Введите цену книги: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price < 0)
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
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении книги: {ex.Message}");
            }
        }

        static void RemoveBook()
        {
            Console.WriteLine("\n=== УДАЛЕНИЕ КНИГИ ===");
            ShowAllBooks();

            Console.Write("Введите ID книги для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный формат ID!");
                return;
            }

            var bookToRemove = books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine($"Книга '{bookToRemove.Title}' успешно удалена!");
            }
            else
            {
                Console.WriteLine("Книга с указанным ID не найдена!");
            }
        }

        static void ShowAllBooks()
        {
            Console.WriteLine("\n=== ВСЕ КНИГИ ===");
            DisplayBooks(books);
        }

        static void SearchBooks()
        {
            Console.WriteLine("\n=== ПОИСК КНИГ ===");
            Console.WriteLine("1. По названию");
            Console.WriteLine("2. По автору");
            Console.WriteLine("3. По жанру");
            Console.Write("Выберите тип поиска: ");

            if (!int.TryParse(Console.ReadLine(), out int searchType))
            {
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

        }

        static void ShowPriceExtremes()
        {
            Console.WriteLine("\n=== САМАЯ ДОРОГАЯ И ДЕШЁВАЯ КНИГА ===");
        }

        static void GroupByAuthors()
        {
            Console.WriteLine("\n=== ГРУППИРОВКА ПО АВТОРАМ ===");
        }

        static void Main(string[] args)
        {
            books.Add(new Book(1, "Мастер и Маргарита", "Михаил Булгаков", Genre.Роман, 1966, 450m));
            books.Add(new Book(2, "Преступление и наказание", "Фёдор Достоевский", Genre.Роман, 1866, 380m));
            books.Add(new Book(3, "1984", "Джордж Оруэлл", Genre.Фантастика, 1949, 520m));
            books.Add(new Book(4, "Убийство в Восточном экспрессе", "Агата Кристи", Genre.Детектив, 1934, 390m));
            books.Add(new Book(5, "Собачье сердце", "Михаил Булгаков", Genre.Фантастика, 1925, 420m));


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
                        ShowAllBooks();
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