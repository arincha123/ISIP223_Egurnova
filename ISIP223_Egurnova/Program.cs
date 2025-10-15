using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Egurnova
{
    class Basa
    {
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public string EQP { get; set; }
        public string WEAP { get; set; }
        public int Krit { get; set; }



    }

    class Enwmy
    {
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int Krit { get; set; }
        public string TypeATK { get; set; }


    }

    class Goblin : Basa
    {

    }

    class Skelet : Basa
    {

    }

    class Mage : Basa
    {

    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
