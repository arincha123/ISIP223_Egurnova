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



            /* Рандом
            tekuchdetail = Core.Context.Detail.ToList();

            Detail detail = tekuchdetail[Random.Next(tekuchdetail.Count)];

            Console.WriteLine(detail.Name);*/




        }

        private void mainMenu()
        {
            Console.WriteLine($"=== АВТОМАСТЕРСКАЯ === === ДЕНЬ {day}");
            Console.WriteLine($"=== БАЛАНС {balance}");
            Console.WriteLine($"=== ---------------------------- ===");
            Console.WriteLine($"1. Инвентаризация");
            Console.WriteLine($"2. Заказать детали");
            Console.WriteLine($"3. Принять клиента");
            Console.WriteLine($" ");
            Console.WriteLine($"0. Выйти из игры ");








        }
    }















}
