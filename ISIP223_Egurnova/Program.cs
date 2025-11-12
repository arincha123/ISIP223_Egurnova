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

        public List<CartofTovari> cartoftovari;

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
        public void UserMenu(Users useuser)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("======== МАГАЗ ========");
                Console.WriteLine("=== ЛИЧНЫЙ КАБИНЕТ ===");
                Console.WriteLine($"Пользователь: {useuser.Name}");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1. Все товары");
                Console.WriteLine("2. Корзина");
                Console.WriteLine("3. Заказы");
                Console.WriteLine(" ");
                Console.WriteLine("0. Выйти из учётной записи ");
                Console.WriteLine("-------------------");
                Console.WriteLine("Выберите действие... ");

                int a = Convert.ToInt32(Console.ReadLine());

                switch (a)
                {
                    case 1:
                        tovariforuser(useuser);
                        break;
                    case 2:
                        userscart(useuser);
                        break;
                    case 3:
                        userorders(useuser);
                        break;
                    case 0:
                        return;
                    default:
                        Console.WriteLine("Неверное значение!");
                        Console.ReadKey();
                        break;
                }
            }
        }


        //Меню для взаимодействия с корзиной
        //Добавить товар в корзину
        //
        //1. Выбирает по айдишнику товар, записывает количество
        //2. Формирует объект класса Корзина товаров и заполняет введёнными данными
        public void tovariforuser(Users useuser)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== МАГАЗ ======");
                Console.WriteLine("====== ТОВАРЫ ===== ");
                Console.WriteLine("-------------------");

                var listtov = Core.Context.Tovari.ToList();

                foreach (var item in listtov)
                {
                    Console.WriteLine($"ID: {item.ID_Tovar}\t Название: {item.Name.PadRight(20)}\t Цена: {item.Price.ToString().PadRight(10)}\tВ наличае: {item.Quantity} шт.");
                }

                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1. Добавить товар в корзину");
                Console.WriteLine("2. Вернуться назад");
                Console.WriteLine("-------------------");

                int a = Convert.ToInt32(Console.ReadLine());

                switch (a)
                {
                    case 1:
                        addincart(useuser);
                        break;
                    case 2:
                        return;
                    default:
                        Console.WriteLine("Неверное значение!");
                        Console.ReadKey();
                        break;
                }
            }
        }


        public void addincart(Users useuser)
        {
            Console.Clear();
            Console.WriteLine("====== ДОБАВЛЕНИЕ В КОРЗИНУ ======");

            var tovi = Core.Context.Tovari.ToList();
            Console.WriteLine("Введите ID товара");
            int idtov = Convert.ToInt32(Console.ReadLine());

            var currenttov = tovi.FirstOrDefault(ct => ct.ID_Tovar == idtov);
            if (currenttov == null)
            {
                Console.WriteLine($"Товара с таким ID не существует");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Введите количество товара");
            int quanttov = Convert.ToInt32(Console.ReadLine());

            if (quanttov > currenttov.Quantity || currenttov.Quantity == 0)
            {
                Console.WriteLine("Неверное количество");
                Console.ReadKey();
                return;
            }

            try
            {
                var cart = Core.Context.Carts.FirstOrDefault(c => c.ID_user == useuser.ID_User);

                if (cart == null)
                {
                    cart = new Carts
                    {
                        ID_user = useuser.ID_User,
                        Date = DateTime.Now
                    };
                    Core.Context.Carts.Add(cart);
                    Core.Context.SaveChanges();
                }

                var estincart = Core.Context.CartofTovari.FirstOrDefault(ci => ci.ID_cart == cart.ID_Cart && ci.ID_tovar == idtov);

                if (estincart != null)
                {
                    estincart.Quantity += quanttov;
                }
                else
                {
                    var cartofTovari = new CartofTovari
                    {
                        ID_cart = cart.ID_Cart,
                        ID_tovar = idtov,
                        Quantity = quanttov
                    };
                    Core.Context.CartofTovari.Add(cartofTovari);
                }

                Core.Context.SaveChanges();
                Console.WriteLine($"Товар '{currenttov.Name}' добавлен в корзину!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при добавлении в корзину: {ex.Message}");
            }

            Console.ReadKey();
        }



        //Корзина пользователя
        //
        //1. Если корзина пустая, то выводит сообщение об этом
        //2. Позволяет удалить товар из корзины, оформитьь заказ или вернуться в меню
        //

        public void userscart(Users useuser)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("====== МАГАЗ ======");
                Console.WriteLine("===== КОРЗИНА =====");
                Console.WriteLine("-------------------");

                var cart = Core.Context.Carts.FirstOrDefault(c => c.ID_user == useuser.ID_User);

                if (cart == null)
                {
                    Console.WriteLine("Ваша корзина пуста!");
                    Console.ReadKey();
                    return;
                }

                var tovariincart = Core.Context.CartofTovari.Where(ci => ci.ID_cart == cart.ID_Cart).ToList();

                if (!tovariincart.Any())
                {
                    Console.WriteLine("Ваша корзина пуста!");
                    Console.ReadKey();
                    return;
                }

                totalsum = 0;
                foreach (var tov in tovariincart)
                {
                    var tovar = Core.Context.Tovari.FirstOrDefault(t => t.ID_Tovar == tov.ID_tovar);
                    if (tovar != null)
                    {
                        totaltov = tov.Quantity * tovar.Price;
                        totalsum += totaltov;

                        Console.WriteLine($"ID в корзине: {tovar.ID_Tovar}\t Название: {tovar.Name.PadRight(20)}\t Цена за шт: {tovar.Price.ToString().PadRight(10)}\t Количество: {tov.Quantity} шт.\t Сумма: {totaltov} руб.");
                        Console.WriteLine("-----------------------");
                    }
                }

                Console.WriteLine($"Общая сумма: {totalsum} руб.");
                Console.WriteLine("1. Оформить заказ");
                Console.WriteLine("2. Удалить товар из корзины");
                Console.WriteLine("3. Вернуться в меню");
                Console.Write("Выберите действие: ");

                int a = Convert.ToInt32(Console.ReadLine());

                switch (a)
                {
                    case 1:
                        orderorder(useuser, cart, tovariincart);
                        break;
                    case 2:
                        deltetov(useuser);
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Неверное значение!");
                        Console.ReadKey();
                        break;
                }
            }
        }


        //Удаление товара из корзины
        //
        //1. Ищет по ID товары в корзине
        //2. Если нашёл, то удаляет
        //


        public void deltetov(Users useuser)
        {
            Console.Clear();
            Console.WriteLine("====== УДАЛЕНИЕ ИЗ КОРЗИНЫ ======");

            Console.Write("Введите ID товара в корзине для удаления: ");
            int cartItemId = Convert.ToInt32(Console.ReadLine());

            var cart = Core.Context.Carts.FirstOrDefault(c => c.ID_user == useuser.ID_User);
            if (cart == null)
            {
                Console.WriteLine("Корзина не найдена!");
                Console.ReadKey();
                return;
            }

            var cartItem = Core.Context.CartofTovari.FirstOrDefault(ci => ci.ID_cartoftovari == cartItemId && ci.ID_cart == cart.ID_Cart);

            if (cartItem == null)
            {
                Console.WriteLine("Товар с таким ID не найден в вашей корзине!");
                Console.ReadKey();
                return;
            }

            try
            {
                var tovar = Core.Context.Tovari.FirstOrDefault(t => t.ID_Tovar == cartItem.ID_tovar);
                string productName = tovar?.Name ?? "Неизвестный товар";

                Core.Context.CartofTovari.Remove(cartItem);
                Core.Context.SaveChanges();

                Console.WriteLine($"Товар '{productName}' удален из корзины!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при удалении: {ex.Message}");
            }

            Console.ReadKey();
        }

       //Оформление заказов
       //
       //1. выбираете пункт выдачи
       //2. Показываются все товары, которые есть в корзине, и общая цена

        public void orderorder(Users useuser, Carts cart, List<CartofTovari> cartoftovari)
        {
            Console.Clear();
            Console.WriteLine("=========== МАГАЗ ============");
            Console.WriteLine("===== ОФОРМЛЕНИЕ ЗАКАЗОВ =====");
            Console.WriteLine("------------------------------");

            var pickupPoints = Core.Context.PickupPoint.ToList();

            Console.WriteLine("Доступные пункты выдачи:");
            foreach (var point in pickupPoints)
            {
                Console.WriteLine($"ID: {point.ID_PickupPoint} - {point.Name}");
            }

            Console.Write("Выберите ID пункта выдачи: ");
            int pintid = Convert.ToInt32(Console.ReadLine());

            var searchpoint = pickupPoints.FirstOrDefault(sp => sp.ID_PickupPoint == pintid);
            if (searchpoint == null)
            {
                Console.WriteLine("Неверный ID пункта выдачи!");
                Console.ReadKey();
                return;
            }

            try
            {
                decimal total = 0;
                foreach (var cartItem in cartoftovari)
                {
                    var tovar = Core.Context.Tovari.FirstOrDefault(t => t.ID_Tovar == cartItem.ID_tovar);
                    if (tovar != null)
                    {
                        total += cartItem.Quantity * tovar.Price;
                    }
                }

                var order = new Orders
                {
                    ID_user = useuser.ID_User,
                    ID_pickuppoint = pintid,
                    Date = DateTime.Now,
                    TotalPrice = total
                };
                Core.Context.Orders.Add(order);
                Core.Context.SaveChanges();

                foreach (var cartItem in cartoftovari)
                {
                    var tovar = Core.Context.Tovari.FirstOrDefault(t => t.ID_Tovar == cartItem.ID_tovar);
                    if (tovar != null)
                    {
                        var tovertinorder = new TovariInOrders
                        {
                            ID_order = order.ID_Order,
                            ID_tovar = cartItem.ID_tovar,
                            Quantity = cartItem.Quantity,
                            Price = tovar.Price
                        };
                        Core.Context.TovariInOrders.Add(tovertinorder);

                        tovar.Quantity -= cartItem.Quantity;
                    }
                }

                Core.Context.CartofTovari.RemoveRange(cartoftovari);
                Core.Context.SaveChanges();

                Console.WriteLine($"Заказ #{order.ID_Order} успешно оформлен!");
                Console.WriteLine($"Общая сумма: {total} руб.");
                Console.WriteLine($"Пункт выдачи: {searchpoint.Name}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при оформлении заказа: {ex.Message}");
            }

            Console.ReadKey();
        }

        //Составление заказа
        //
        //1. Указывается пункт выдачи и товары

        public void userorders(Users useuser)
        {
            Console.Clear();
            Console.WriteLine("====== МАГАЗ ======");
            Console.WriteLine("===== МОИ ЗАКАЗЫ =====");
            Console.WriteLine("-------------------");

            var orders = Core.Context.Orders
                .Where(o => o.ID_user == useuser.ID_User)
                .OrderByDescending(o => o.Date)
                .ToList();

            if (!orders.Any())
            {
                Console.WriteLine("У вас еще нет заказов!");
                Console.ReadKey();
                return;
            }

            foreach (var order in orders)
            {
                Console.WriteLine($"Заказ #{order.ID_Order}");
                Console.WriteLine($"Дата: {order.Date:dd.MM.yyyy HH:mm}");
                Console.WriteLine($"Сумма: {order.TotalPrice} руб.");

                var pickupPoint = Core.Context.PickupPoint.FirstOrDefault(p => p.ID_PickupPoint == order.ID_pickuppoint);
                Console.WriteLine($"Пункт выдачи: {pickupPoint?.Name ?? "Неизвестно"}");
                var orderItems = Core.Context.TovariInOrders.Where(oi => oi.ID_order == order.ID_Order).ToList();
                Console.WriteLine("Товары:");
                foreach (var item in orderItems)
                {
                    var tovar = Core.Context.Tovari.FirstOrDefault(t => t.ID_Tovar == item.ID_tovar);
                    if (tovar != null)
                    {
                        Console.WriteLine($"  - {tovar.Name} x {item.Quantity} по {item.Price} руб.");
                    }
                }
                Console.WriteLine("===================================");
            }

            Console.WriteLine("Нажмите любую клавишу для возврата...");
            Console.ReadKey();
        }
    }
}