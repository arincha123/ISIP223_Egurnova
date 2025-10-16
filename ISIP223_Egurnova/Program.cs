using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISIP223_Egurnova
{
    class Player
    {
        public int HP { get; set; } = 100;
        public int DEF { get; set; }
        public string EQP { get; set; }
        public string WEAP { get; set; }
        public int Krit { get; set; }

        public Player(int hp, int def, string eqp, string weap, int krit)
        {
            HP = hp;
            DEF = def;
            EQP = eqp;
            WEAP = weap;
            Krit = krit;
        }



    }

    class Enemy
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public string TypeATK { get; set; }

        public Enemy(string name, int hp, int atk, int def, string ta)
        {
            Name = name;
            HP = hp;
            ATK = atk;
            DEF = def;
            TypeATK = ta;
        }


    }

    class Goblin : Enemy
    {
        public int Krit { set; get; }

        public Goblin(string name, int hp, int atk, int def, string ta, int krit)
            :base(name, hp, atk, def, ta)
        {
            Krit = krit;
        }
    }

    class Skelet : Enemy
    {
        public Skelet(string name, int hp, int atk, int def, string ta)
            : base(name, hp, atk, def, ta)
        {

        }
    }

    class Mage : Enemy
    {
        public Mage(string name, int hp, int atk, int def, string ta)
            : base(name, hp, atk, def, ta)
        {

        }
    }

    public enum WeapType
    {
        Melee,
        Ranged,
        Magic
    }

    public enum ArmType
    {
        Light,
        Medium,
        Heavy
    }


    class Item
    {
        public string Name { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }


        public Item(string name, int atk, int def, bool weap)
        {
            Name = name;
            ATK = atk;
            DEF = def;
        }
    }

    class Weapon : Item
    {
        public WeapType Type
        public bool IsWeapon = true;

        public Weapon(string name, int atk, int def, bool weap, WeapType type)
            : base(name, atk, def, weap)
        {
            Type = type;
        }



    }

    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
