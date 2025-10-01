using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Egurnova
{
    internal class Program
    {
        static List<Product> tovari = new List<Product>();

        class Product
        {
            public int ProductID { get; set; }
            public string Name { get; set; }
            public double Price { get; set; }
            public int Quantity { get; set; }
            public string Availability { get; set; }
            public string Category { get; set; }

            public Product(int id, string name, double pri, int colich, string nalich, string cat)
            {
                ProductID = id;
                Name = name;
                Price = pri;
                Availability = nalich;
                Quantity = colich;
                Category = cat;
            }

            public enum category
            {
                Канцелярия = 1,
                Еда = 2,
                Мебель = 3
            }
        }

        private static void Print(Product product)
        {
            Console.WriteLine("ID\tНазвание\tЦена\tКоличество\tНаличие\tКатегория\t");
            Console.WriteLine(product.ProductID + "\t" + product.Name + "\t\t" + product.Price.ToString("F2") + "\t" + product.Quantity + "\t\t" + product.Availability + "\t" + product.Category);
        }

        public static void Add()
        {
            Console.WriteLine("--- Добавление товара ---");
            Console.Write("Сколько товаров добавите? ");
            int col = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < col; i++)
            {
                Console.Write("Название товара: ");
                string name = Console.ReadLine();

                Console.Write("Цена товара: ");
                double pri = Convert.ToDouble(Console.ReadLine());

                Console.Write("Есть ли на складе: ");
                string nalich = Console.ReadLine();

                Console.Write("Количество: ");
                int colich = Convert.ToInt32(Console.ReadLine());

                Console.Write("Категория: ");
                string category = ChooseCat();

                int newid = 1;
                if (tovari.Count > 0)
                {
                    int maxId = 0;
                    for (int j = 0; j < tovari.Count; j++)
                    {
                        if (tovari[j].ProductID > maxId)
                        {
                            maxId = tovari[j].ProductID;
                        }
                    }
                    newid = maxId + 1;
                }

                Product newtovar = new Product(newid, name, pri, colich, nalich, category);
                tovari.Add(newtovar);

                Console.Write("\nТовар добавлен\n");
            }
        }

        private static string ChooseCat()
        {
            Console.Write("Категория (1-Канцелярия, 2-Еда, 3-Мебель): ");
            string input = Console.ReadLine();

            if (input == "2") return Product.category.Еда.ToString();
            if (input == "3") return Product.category.Мебель.ToString();
            return Product.category.Канцелярия.ToString();
        }

        public static void Remove()
        {
            Console.WriteLine("--- Удаление товара ---");

            for (int i = 0; i < tovari.Count; i++)
            {
                Print(tovari[i]);
            }

            Console.WriteLine("Введите номер (id) товара: ");
            int code = Convert.ToInt32(Console.ReadLine());

            Product removeprod = null;
            for (int i = 0; i < tovari.Count; i++)
            {
                if (code == tovari[i].ProductID)
                {
                    removeprod = tovari[i];
                    break;
                }
            }

            if (removeprod != null)
            {
                tovari.Remove(removeprod);
                Console.WriteLine("Товар успешно удален!");
            }
            else
            {
                Console.WriteLine("Товар с указанным ID не найден.");
            }
        }

        public static void Delivery()
        {
            Console.WriteLine("--- Заказ доставки товара ---");

            for (int i = 0; i < tovari.Count; i++)
            {
                Print(tovari[i]);
            }

            Console.WriteLine("Введите номер (id) товара для заказа: ");
            int dev = Convert.ToInt32(Console.ReadLine());

            Product devprod = null;
            for (int i = 0; i < tovari.Count; i++)
            {
                if (dev == tovari[i].ProductID)
                {
                    devprod = tovari[i];
                    break;
                }
            }

            if (devprod != null)
            {
                Console.Write("Введите количество для заказа: ");
                int col = Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите адрес: ");
                string adr = Console.ReadLine();

                if (col > 0 && !string.IsNullOrEmpty(adr))
                {
                    devprod.Quantity += col;
                    Console.WriteLine("Доставка заказана! Товар '" + devprod.Name + "' в количестве " + col + " шт. будет добавлен на склад и отправлен на адрес: " + adr);
                }
                else
                {
                    Console.WriteLine("Данные были некорректно введены.");
                }
            }
            else
            {
                Console.WriteLine("Товар с указанным ID не найден.");
            }
        }

        public static void Sell()
        {
            Console.WriteLine("--- Продажа товара ---");

            for (int i = 0; i < tovari.Count; i++)
            {
                Print(tovari[i]);
            }

            Console.WriteLine("Введите номер (id) товара для продажи: ");
            int sel = Convert.ToInt32(Console.ReadLine());

            Product selprod = null;
            for (int i = 0; i < tovari.Count; i++)
            {
                if (sel == tovari[i].ProductID)
                {
                    selprod = tovari[i];
                    break;
                }
            }

            if (selprod != null)
            {
                if (selprod.Quantity > 0 && selprod.Availability.ToLower() == "да")
                {
                    Console.Write("Введите количество для продажи: ");
                    int col = Convert.ToInt32(Console.ReadLine());

                    if (col > 0 && col <= selprod.Quantity)
                    {
                        selprod.Quantity -= col;
                        double total = selprod.Price * col;
                        Console.WriteLine("Продажа совершена! Товар '" + selprod.Name + "' в количестве " + col + " шт. на сумму " + total.ToString("F2") + " руб.");

                        if (selprod.Quantity == 0)
                        {
                            selprod.Availability = "нет";
                            Console.WriteLine("Товар закончился на складе.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Некорректное количество или недостаточно товара на складе.");
                    }
                }
                else
                {
                    Console.WriteLine("Товар отсутствует на складе.");
                }
            }
            else
            {
                Console.WriteLine("Товар с указанным ID не найден.");
            }
        }

        public static void Search()
        {
            Console.WriteLine("По какому именно атрибуту будем искать товар?\n1. По коду\n2. По названию\n3. По категории");
            int s = Convert.ToInt32(Console.ReadLine());

            switch (s)
            {
                case 1:
                    Console.WriteLine("Введите номер (id) товара: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Product product1 = null;
                    for (int i = 0; i < tovari.Count; i++)
                    {
                        if (tovari[i].ProductID == id)
                        {
                            product1 = tovari[i];
                            break;
                        }
                    }

                    if (product1 != null)
                    {
                        Print(product1);
                    }
                    else
                    {
                        Console.WriteLine("Товар не найден.");
                    }
                    break;
                case 2:
                    Console.WriteLine("Введите название товара: ");
                    string name = Console.ReadLine();

                    List<Product> foundProducts = new List<Product>();
                    for (int i = 0; i < tovari.Count; i++)
                    {
                        if (tovari[i].Name.ToLower() == name.ToLower())
                        {
                            foundProducts.Add(tovari[i]);
                        }
                    }

                    if (foundProducts.Count > 0)
                    {
                        Console.WriteLine("Найденные товары:");
                        foreach (Product product in foundProducts)
                        {
                            Print(product);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Товар не найден.");
                    }
                    break;
                case 3:
                    Console.WriteLine("Введите категорию товара: ");
                    string cat = Console.ReadLine();

                    List<Product> categoryProducts = new List<Product>();
                    for (int i = 0; i < tovari.Count; i++)
                    {
                        if (tovari[i].Category.ToLower() == cat.ToLower())
                        {
                            categoryProducts.Add(tovari[i]);
                        }
                    }

                    if (categoryProducts.Count > 0)
                    {
                        Console.WriteLine("Найденные товары в категории '" + cat + "':");
                        foreach (Product product in categoryProducts)
                        {
                            Print(product);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Товар не найден.");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        public static void ShowAll()
        {
            Console.WriteLine("--- Все товары ---");
            if (tovari.Count == 0)
            {
                Console.WriteLine("Товары отсутствуют.");
                return;
            }

            foreach (Product product in tovari)
            {
                Print(product);
            }
        }

        static void Main(string[] args)
        {
            Product Prod1 = new Product(1, "ручка", 55, 3, "да", "Канцелярия");
            tovari.Add(Prod1);
            Product Prod2 = new Product(2, "диван", 250, 0, "нет", "Мебель");
            tovari.Add(Prod2);
            Product Prod3 = new Product(3, "лапша", 5, 50, "да", "Еда");
            tovari.Add(Prod3);

            int a = -1;
            while (a != 0)
            {
                Console.WriteLine("\nВыберите операцию: \n1. Добавление\n2. Удаление\n3. Заказ доставки\n4. Продажа товара\n5. Поиск\n6. Показать все товары\n0. Выход");
                Console.Write("Ваш выбор: ");
                a = Convert.ToInt32(Console.ReadLine());

                switch (a)
                {
                    case 1:
                        Add();
                        break;
                    case 2:
                        Remove();
                        break;
                    case 3:
                        Delivery();
                        break;
                    case 4:
                        Sell();
                        break;
                    case 5:
                        Search();
                        break;
                    case 6:
                        ShowAll();
                        break;
                    case 0:
                        Console.WriteLine("Выход из программы...");
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
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