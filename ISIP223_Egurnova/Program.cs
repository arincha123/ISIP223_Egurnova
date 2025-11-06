using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Egurnova
{
    /* классы
     * клиенты, машины, склад запчастей, детали, меню закупки, заказ на детали
      
     * глаголы
     * чинить, заменять, заплатить, купить, смотреть, докупить, возместить, согласиться, отказать 
     
     заранее нужно занести информацию о деталях и их стоимости
     появляется меню с клинетом, номнром машины и запчастью, которую надо заменить + стоимость ремонта
     ниже появляется список с деталямии и их количеством на складе

     * в изначальном меню есть пункты: принять клиента, просмотреть склад, докупить детали
     
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            
        }
    }

    public class DeliveryOrder
    {
        public int ID_detail { get; set; }
        public int Quantity { get; set; }
        public int OrderDay { get; set; }
        public int DeliveryDay { get; set; }
        public decimal TotalCost { get; set; }
        public bool IsDelivered { get; set; }

        public virtual Detail Detail { get; set; }
    }

    public class Game
    {

        private decimal balance { get; set; }
        private decimal shtraf { get; set; }
        private decimal obsluga { get; set; }
        private int day { get; set; }
        private decimal price_of_zakaz { get; set; }

        private List<Client> allclient;
        private List<Car> allcar;
        private List<Detail> alldetail;

        Random Random = new Random();

        public void Start()
        {
            balance = 3300;
            shtraf = 300;
            obsluga = 250;
            day = 1;
            price_of_zakaz = 0;


            allclient = Core.Context.Client.ToList();
            allcar = Core.Context.Car.ToList();
            alldetail = Core.Context.Detail.ToList();


            while (true)
            {
                int key = mainMenu();
                Dostavilli();

                /* Рандом
                tekuchdetail = Core.Context.Detail.ToList();

                Detail detail = tekuchdetail[Random.Next(tekuchdetail.Count)];

                Console.WriteLine(detail.Name);*/

                switch (key)
                {
                    case 1:
                        {
                            invent();
                            day--;
                            break;
                        }
                    case 2:
                        {
                            zakaz_det();
                            break;
                        }
                    case 3:
                        {
                            Order order = gencl();
                            zakaz(order);
                            break;
                        }
                    case 0:
                        {
                            return;
                        }
                }
                day++;
            }
        }

        public int mainMenu()
        {
            Console.WriteLine($"=== АВТОМАСТЕРСКАЯ === === ДЕНЬ {day}");
            Console.WriteLine($"=== БАЛАНС {balance}");
            Console.WriteLine("=== ---------------------------- ===");
            Console.WriteLine("1. Инвентаризация");
            Console.WriteLine("2. Заказать детали");
            Console.WriteLine("3. Принять клиента");
            Console.WriteLine(" ");
            Console.WriteLine("0. Выйти из игры ");

            int a = Convert.ToInt32(Console.ReadLine());
            return a;

        }

        public void invent()
        {
            var detfromsklad = Core.Context.Sklad.ToList();

            foreach (var det in detfromsklad)
            {
                Console.WriteLine($"ID: {det.Detail.ID_DETAIL}\t Name: {det.Detail.Name.PadRight(20)}\t Quantity: {det.Quantity.ToString().PadRight(5)}\t Price for 1 shtuka: {det.Detail.Price}");
            }
        }

        public Order gencl()
        {
            var orderlist = Core.Context.Order.ToList();
            Detail detail = alldetail[Random.Next(alldetail.Count)];

            Order order = new Order
            {
                ID_car = allcar[Random.Next(allcar.Count)].ID_CAR,
                ID_client = allclient[Random.Next(allclient.Count)].ID_CLIENT,
                ID_detail_on_sklad = detail.ID_DETAIL,
                Price = detail.Price

            };

            Core.Context.Order.Add(order);
            Core.Context.SaveChanges();

            return order;
        }

        public void zakaz(Order order)
        {
            var tekuchdetail = Core.Context.Detail.FirstOrDefault(t => t.ID_DETAIL == order.ID_detail_on_sklad);
            price_of_zakaz = obsluga + tekuchdetail.Price;

            Console.WriteLine($"=== АВТОМАСТЕРСКАЯ === === ДЕНЬ {day}");
            Console.WriteLine($"=== БАЛАНС {balance}");
            Console.WriteLine("=== ---------------------------- ===");
            Console.WriteLine($"=== Клиент: {order.Client.Name}");
            Console.WriteLine($"=== Машина: {order.Car.Mark} - {order.Car.Model}");
            Console.WriteLine($"=== Деталь: {tekuchdetail.Name}");
            Console.WriteLine($"=== Стоимость ремонта: {price_of_zakaz}");
            Console.WriteLine("=== ---------------------------- ===");
            
            var skladdet = Core.Context.Sklad.ToList();
            var esttli = skladdet.FirstOrDefault(e => e.ID_detail == tekuchdetail.ID_DETAIL);

            if (esttli.Quantity != 0)
            {
                Console.WriteLine("Обслужим клиента? (y/n)");
                string answer = Console.ReadLine().ToLower();

                switch (answer)
                {
                    case "y":
                        {
                            remont();
                            esttli.Quantity--;
                            break;
                        }
                    case "n":
                        {
                            shtrafuved();
                            break;
                        }
                }
            } 
            else {
                Console.WriteLine("Такой детали нет на складе");
                balance -= shtraf * 2;
                Console.WriteLine($"Вам нужно выдать компенсацию клиенту: {shtraf * 2}");
            }
        }

        public void remont()
        {
            balance += price_of_zakaz;

            Console.WriteLine($"=== АВТОМАСТЕРСКАЯ === === ДЕНЬ {day}");
            Console.WriteLine($"=== БАЛАНС {balance}");
            Console.WriteLine("=== ---------------------------- ===");
            Console.WriteLine($"=== Вы выполнили ремонт на сумму: {price_of_zakaz}");


        }

        public void shtrafuved()
        {
            balance -= shtraf;

            Console.WriteLine($"=== АВТОМАСТЕРСКАЯ === === ДЕНЬ {day}");
            Console.WriteLine($"=== БАЛАНС {balance}");
            Console.WriteLine("=== ---------------------------- ===");
            Console.WriteLine($"=== Вы отказали клиенту в ремонте, поэтому вы облагаетесь штрафом = {shtraf}");
        }

        public List<DeliveryOrder> deliveryspis = new List<DeliveryOrder>();

        public void zakaz_det()
        {

            Console.WriteLine($"=== АВТОМАСТЕРСКАЯ === === ДЕНЬ {day}");
            Console.WriteLine($"=== БАЛАНС {balance}");
            Console.WriteLine("=== ---------------------------- ===");

            var detlist = Core.Context.Detail.ToList();

            foreach (var det in detlist)
            {
                Console.WriteLine($"ID: {det.ID_DETAIL}\t Name: {det.Name.PadRight(20)}\t Price for 1 shtuka: {det.Price}");
            }

            Console.WriteLine("Введите ID детали: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество деталей: ");
            int b = Convert.ToInt32(Console.ReadLine());


            var currentdet = detlist.FirstOrDefault(d => d.ID_DETAIL == a);


            if (currentdet == null)
            {
                Console.WriteLine($"=== АВТОМАСТЕРСКАЯ === === ДЕНЬ {day}");
                Console.WriteLine($"=== БАЛАНС {balance}");
                Console.WriteLine("=== ---------------------------- ===");
                Console.WriteLine($"=== Деталей с таким ID не существует");
                Console.ReadKey();
                return;
            }

            decimal final_sum = currentdet.Price * b;

            if (balance >= final_sum)
            {
                deliveryspis.Add(new DeliveryOrder
                {
                    ID_detail = a,
                    Quantity = b,
                    OrderDay = day,
                    DeliveryDay = day + 2,
                    TotalCost = final_sum
                });
                balance -= final_sum;

                Console.WriteLine($"=== АВТОМАСТЕРСКАЯ === === ДЕНЬ {day}");
                Console.WriteLine($"=== БАЛАНС {balance}");
                Console.WriteLine("=== ---------------------------- ===");
                Console.WriteLine($"=== Детали заказаны. Ожидайте 2 дня");
            }
            else
            {
                Console.WriteLine($"=== АВТОМАСТЕРСКАЯ === === ДЕНЬ {day}");
                Console.WriteLine($"=== БАЛАНС {balance}");
                Console.WriteLine("=== ---------------------------- ===");
                Console.WriteLine($"=== Недостаточно средств на балансе");
            }
        }

        public void Dostavilli()
        {
            var zakaz_list = deliveryspis.Where(zl => zl.DeliveryDay <= day && !zl.IsDelivered).ToList();

            foreach (var zl in zakaz_list.ToList())
            {
                var skladItem = Core.Context.Sklad.FirstOrDefault(s => s.ID_detail == zl.ID_detail);
                var detail = Core.Context.Detail.FirstOrDefault(d => d.ID_DETAIL == zl.ID_detail);
                string detailName;

                if (detail != null)
                {
                    detailName = detail.Name;
                }
                else
                {
                    detailName = "Неизвестная деталь";
                }

                if (skladItem != null)
                {
                    skladItem.Quantity += zl.Quantity;
                }
                else
                {
                    skladItem = new Sklad
                    {
                        ID_detail = zl.ID_detail,
                        Quantity = zl.Quantity
                    };
                    Core.Context.Sklad.Add(skladItem);
                }

                zl.IsDelivered = true;
                deliveryspis.Remove(zl);

                Console.WriteLine($"=== АВТОМАСТЕРСКАЯ === === ДЕНЬ {day}");
                Console.WriteLine($"=== БАЛАНС {balance}");
                Console.WriteLine("=== ---------------------------- ===");
                Console.WriteLine($"=== Доставлен заказ: {detailName} x{zl.Quantity}");
            }

            if (zakaz_list.Any())
            {
                Core.Context.SaveChanges();
            }
        }
    }
}
