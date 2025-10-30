using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
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


    public class Game
    {

        private int balance { get; set; }
        private int shtraf { get; set; }
        private int obsluga { get; set; }
        private int day {  get; set; }

        private List<Client> tekuchclient;
        private List<Car> tekuchcar;
        private List<Detail> tekuchdetail;

        Random Random = new Random();

        public void Start()
        {
            balance = 3300;
            shtraf = 300;
            obsluga = 250;
            day = 1;


            int key = mainMenu();

            /* Рандом
            tekuchdetail = Core.Context.Detail.ToList();

            Detail detail = tekuchdetail[Random.Next(tekuchdetail.Count)];

            Console.WriteLine(detail.Name);*/

            switch (key)
            {
                case 1:
                    invent();
                    break;
                case 2:
                    order();
                    break;
                case 3:
                    remont();
                    break;
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

            int a = Convert.ToInt32( Console.ReadLine() );
            return a;
        }

        public void invent()
        {
            var detfromsklad = Core.Context.Sklad.ToList();

            foreach ( var det in detfromsklad)
            {
                Console.WriteLine($"ID: {det.Detail.ID_DETAIL}\t Name: {det.Detail.Name.PadRight(20)}\t Quantity: {det.Quantity.ToString().PadRight(5)}\t Price for 1 shtuka: {det.Detail.Price}");
            }
        }

        public void order()
        {
            var orderlist = Core.Context.Order.ToList();
            Detail detail = tekuchdetail[Random.Next(tekuchdetail.Count)];

            Order order = new Order {
                ID_car = tekuchcar[Random.Next(tekuchcar.Count)].ID_CAR,
                ID_client = tekuchclient[Random.Next(tekuchclient.Count)].ID_CLIENT,
                ID_detail_on_sklad = detail.ID_DETAIL,
                Price = detail.Price

            };

            Core.Context.Order.Add(order);
            Core.Context.SaveChanges();
        }

        public void remont()
        {

        }


    }















}
