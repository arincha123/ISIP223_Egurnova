using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Egurnova
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Marketplace mark = new Marketplace();
            mark.Start();
        }
    }

    public class Marketplace
    {
        public decimal totaltov { get; set; }
        public decimal totalsum { get; set; }

        public void Start()
        {
            while (true)
            {
                int key = WelcomeMenu();

                switch (key)
                {
                    case 1:
                        tovari();
                        break;
                    case 2:
                        account();
                        break;
                    case 0: return;
                    default:
                        Console.WriteLine("Неверное значение!");
                        break;
                }
            }
        }


        //Вывод главного меню
        //
        //1. Выводит меню
        //2. Просит выбрать пункт меню
        //3. Возвращает значение - пункт, который выбрали

        public int WelcomeMenu()
        {
            Console.WriteLine($"====== МАГАЗ ======");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Все товары");
            Console.WriteLine("2. Учётная запись");
            Console.WriteLine(" ");
            Console.WriteLine("0. Выйти из магазина ");
            Console.WriteLine("-------------------");
            Console.WriteLine("Выберите действие... ");

            int a = Convert.ToInt32(Console.ReadLine());
            return a;
        }


        //Вывод всех товаров
        //
        //1. Выводит все товары, что есть в базе

        public void tovari()
        {
            Console.Clear();
            Console.WriteLine("====== МАГАЗ ======");
            Console.WriteLine("====== ТОВАРЫ =====");
            Console.WriteLine("-------------------");

            var listtov = Core.Context.Tovari.ToList();

            foreach (var item in listtov)
            {
                Console.WriteLine($"ID: {item.ID_Tovar}\t Название: {item.Name.PadRight(20)}\t Цена: {item.Price.ToString().PadRight(10)}\tВ наличае: {item.Quantity} шт.");
            }

            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }


        //Меню входа в аккаунт
        //
        //1. Показывает меню с методами, которые можно выбрать
        public void account()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"====== МАГАЗ ======");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Зарегистрироваться");
                Console.WriteLine("2. Войти в учётную запись");
                Console.WriteLine("0. Назад");
                Console.WriteLine("-------------------");
                Console.WriteLine("Выберите действие... ");

                int a = Convert.ToInt32(Console.ReadLine());

                switch (a)
                {
                    case 1:
                        registr();
                        break;
                    case 2:
                        login();
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Неверное значение!");
                        break;
                }
            }
        }

        //Регистрация
        //
        //1. Попросить пользователя заполнить экземпляр данными
        //2. Проверить не занят ли логин введённый пользователем и верен ли пароль, введённый повторно
        //3. Если все прошло успешно создаёт экземпляр класса пользователя из БД и заполняет его введёнными данными
        //4. Добавляет нового пользователя и возвращается в меню

        public void registr()
        {
            Console.Clear();
            Console.WriteLine("========= МАГАЗ =========");
            Console.WriteLine("====== РЕГИСТРАЦИЯ ======");
            Console.WriteLine("-------------------");

            Console.WriteLine("Введите логин:");
            var login = Console.ReadLine();

            var useuse = Core.Context.Users.FirstOrDefault(u => u.Login == login);

            if (useuse != null)
            {
                Console.WriteLine("Пользователь с таким логином уже существует");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите пароль:");
            var password1 = Console.ReadLine();
            Console.WriteLine("Подтвердите пароль:");
            var password2 = Console.ReadLine();

            if (password1 != password2)
            {
                Console.WriteLine("Пароли не совпадают");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите ваше имя: ");
            var name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password1) || string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Все поля обязательны для заполнения!");
                Console.ReadKey();
                return;
            }

            try
            {
                var newUser = new Users
                {
                    Login = login,
                    Password = password1,
                    Name = name
                };

                Core.Context.Users.Add(newUser);
                Core.Context.SaveChanges();

                Console.WriteLine("Регистрация прошла успешно! Теперь вы можете войти в систему.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при регистрации: {ex.Message}");
            }

            Console.ReadKey();
        }


        //Вход в уже зарегистрированного пользователя
        //
        //1. Проверяет логин и пароль 
        //2. Ищет по уже существующим пользовтелям совпадение
        //3. Если находит, то показывает пользовательское меню (личный кабинет)

        public void login()
        {
            Console.Clear();
            Console.WriteLine("=========== МАГАЗ ===========");
            Console.WriteLine("=== ВХОД В УЧЁТНУЮ ЗАПИСЬ ===");
            Console.WriteLine("-----------------------------");

            Console.WriteLine("Введите логин: ");
            var login = Console.ReadLine();

            Console.WriteLine("Введите пароль: ");
            var password = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                Console.WriteLine("Введите логин и пароль!!!");
                Console.ReadKey();
                return;
            }

            var useuser = Core.Context.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
            if (useuser == null)
            {
                Console.WriteLine("Неверный логин или пароль");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"Добро пожаловать, {useuser.Name}!");
            Console.ReadKey();

            UserMenu(useuser);
        }


        //Меню личного кабинета
        //
        //1. Даёт возможность просмотреть все товары, просмотреть корзину и историю заказов


        //Меню для взаимодействия с корзиной
        //Добавить товар в корзину
        //
        //1. Выбирает по айдишнику товар, записывает количество
        //2. Формирует объект класса Корзина товаров и заполняет введёнными данными


        //Корзина пользователя
        //
        //1. Если корзина пустая, то выводит сообщение об этом
        //2. Позволяет удалить товар из корзины, оформитьь заказ или вернуться в меню
        //


    }
}
