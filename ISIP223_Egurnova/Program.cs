using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIP223_Egurnova.Model;

namespace ISIP223_Egurnova
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    public enum WeaponType
    {
        Melee,
        Ranged,
        Magic
    }

    public enum ArmorType
    {
        Light,
        Medium,
        Heavy
    }


    //public abstract class  Item
    //{
    //    public string Name { get; set; }
    //    public int Attack { get; set; }
    //    public int Defense { get; set; }

    //    protected Item(string name, int attack, int defense)
    //    {
    //        Name = name;
    //        Attack = attack;
    //        Defense = defense;
    //    }
    //}

    //public class Weapon : Item
    //{
    //    public WeaponType TypeWeap { get; set; }
    //    public bool IsWeapon => true;

    //    public Weapon(string name, int attack, int defense, WeaponType type)
    //        : base(name, attack, defense)
    //    {
    //        TypeWeap = type;
    //    }

    //    public override string ToString()
    //    {
    //        string typeStr;

    //        if (TypeWeap == WeaponType.Melee)
    //            typeStr = "Холодное";
    //        else if (TypeWeap == WeaponType.Ranged)
    //            typeStr = "Дальнострельное";
    //        else if (TypeWeap == WeaponType.Magic)
    //            typeStr = "Магия";
    //        else
    //            typeStr = "Неизвестно";

    //        return $"{Name} [Тип: {typeStr}, АТК: {Attack}, ЗАЩ: {Defense}]";
    //    }

    //}

    //public class Armor : Item
    //{
    //    public ArmorType TypeArmor { get; set; }
    //    public bool IsWeapon => false;

    //    public Armor(string name, int attack, int defense, ArmorType type)
    //        : base(name, attack, defense)
    //    {
    //        TypeArmor = type;
    //    }

    //    public override string ToString()
    //    {
    //        string typeStr;

    //        if (TypeArmor == ArmorType.Light)
    //            typeStr = "Лёгкая";
    //        else if (TypeArmor == ArmorType.Medium)
    //            typeStr = "Средняя";
    //        else if (TypeArmor == ArmorType.Heavy)
    //            typeStr = "Тяжёлая";
    //        else
    //            typeStr = "Неизвестно";

    //        return $"{Name} [Тип: {typeStr}, АТК: {Attack}, ЗАЩ: {Defense}]";
    //    }

    //}


    //public class Player
    //{
    //    public int MaxHP { get; set; } = 100;
    //    public int CurrentHP { get; set; } = 100;
    //    public Weapon Weapon { get; set; }
    //    public Armor Armor { get; set; }
    //    public bool IsFrozen { get; set; } = false;
    //    public Player()
    //    {
    //        Weapon = new Weapon("Ржавый меч", 5, 0, WeaponType.Melee);
    //        Armor = new Armor("Потрёпанная кожаная броня", 0, 3, ArmorType.Light);
    //    }
    //    public int GetAttack()
    //    {
    //        if (Weapon != null)
    //        {
    //            return Weapon.Attack;
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }
    //    public int GetDefense()
    //    {
    //        if (Armor != null)
    //        {
    //            return Armor.Defense;
    //        }
    //        else
    //        {
    //            return 0;
    //        }
    //    }
    //    public void TakeDamage(int damage)
    //    {
    //        CurrentHP -= damage;
    //        if (CurrentHP < 0) CurrentHP = 0;
    //    }
    //    public void Heal()
    //    {
    //        CurrentHP = MaxHP;
    //    }
    //    public bool IsAlive() => CurrentHP > 0;
    //    public override string ToString()
    //    {
    //        return $"Игрок: HP {CurrentHP}/{MaxHP}, Атака: {GetAttack()}, Защита: {GetDefense()}";
    //    }
    //}



    //public abstract class Enemy
    //{
    //    public string Name { get; set; }
    //    public int MaxHP { get; set; }
    //    public int CurrentHP { get; set; }
    //    public int Attack { get; set; }
    //    public int Defense { get; set; }
    //    public bool IsAlive() => CurrentHP > 0;
    //    public virtual void TakeDamage(int damage)
    //    {
    //        CurrentHP -= damage;
    //        if (CurrentHP < 0) CurrentHP = 0;
    //    }
    //    public abstract int GetDamage(Player player, bool usedDefense);
    //    public abstract string Effect(Player player);
    //    public override string ToString()
    //    {
    //        return $"{Name}: HP {CurrentHP}/{MaxHP}, Атака: {Attack}, Защита: {Defense}";
    //    }
    //}

    //public class Goblin : Enemy
    //{
    //    public Goblin()
    //    {
    //        Name = "Гоблин";
    //        MaxHP = 15;
    //        CurrentHP = 15;
    //        Attack = 4;
    //        Defense = 2;
    //    }

    //    public override int GetDamage(Player player, bool usedDefense)
    //    {
    //        Random random = new Random();
    //        int critRoll = random.Next(0, 5);
    //        bool isCrit = (critRoll == 0);
    //        int damage = Attack;

    //        if (isCrit)
    //        {
    //            damage = (int)(damage * 1.5);
    //            Console.WriteLine("Критический удар!");
    //        }

    //        return damage;
    //    }

    //    public override string Effect(Player player) => "";
    //}

    //public class BossVVG : Goblin
    //{
    //    public BossVVG()
    //    {
    //        Name = "Босс гоблинов ВВГ";
    //        MaxHP = (int)(30 * 2.0);
    //        CurrentHP = MaxHP;
    //        Attack = (int)(8 * 1.5);
    //        Defense = (int)(2 * 1.2);
    //    }

    //    public override int GetDamage(Player player, bool usedDefense)
    //    {
    //        Random random = new Random();
    //        int critRoll = random.Next(0, 5);
    //        bool isCrit = (critRoll == 0);
    //        int damage = Attack;

    //        if (isCrit)
    //        {
    //            damage = (int)(damage * 1.5);
    //            Console.WriteLine("Критический удар!");
    //        }

    //        return damage;
    //    }
    //}

    //public class Skeleton : Enemy
    //{
    //    public Skeleton()
    //    {
    //        Name = "Скелет";
    //        MaxHP = 20;
    //        CurrentHP = 20;
    //        Attack = 8;
    //        Defense = 3;
    //    }

    //    public override int GetDamage(Player player, bool usedDefense)
    //    {
    //        return Attack;
    //    }

    //    public override string Effect(Player player) => "";
    //}

    //public class BossKovalsky : Skeleton
    //{
    //    public BossKovalsky()
    //    {
    //        Name = "Босс скелет Ковальский";
    //        MaxHP = (int)(25 * 2.5);
    //        CurrentHP = MaxHP;
    //        Attack = (int)(10 * 1.3);
    //        Defense = (int)(3 * 1.4);
    //    }
    //}

    //public class BossPestov : Skeleton
    //{
    //    private double freezeChance = 0.4;

    //    public BossPestov()
    //    {
    //        Name = "Пестов С-- ";
    //        MaxHP = (int)(25 * 1.3);
    //        CurrentHP = MaxHP;
    //        Attack = (int)(10 * 1.8);
    //        Defense = (int)(3 * 0.6);
    //    }

    //    public override string Effect(Player player)
    //    {
    //        Random random = new Random();
    //        int freezeRoll = random.Next(0, 4);
    //        bool isFrozen = (freezeRoll == 0);

    //        if (isFrozen)
    //        {
    //            player.IsFrozen = true;
    //            return "Пестов замораживает вас магией С--! Вы пропустите следующий ход.";
    //        }
    //        return "";
    //    }
    //}

    //public class Mage : Enemy
    //{

    //    public Mage()
    //    {
    //        Name = "Маг";
    //        MaxHP = 20;
    //        CurrentHP = 20;
    //        Attack = 10;
    //        Defense = 1;
    //    }

    //    public override int GetDamage(Player player, bool usedDefense)
    //    {
    //        return Attack;
    //    }

    //    public override string Effect(Player player)
    //    {
    //        Random random = new Random();
    //        int freezeRoll = random.Next(0, 4);
    //        bool isFrozen = (freezeRoll == 0);

    //        if (isFrozen)
    //        {
    //            player.IsFrozen = true;
    //            return "Маг замораживает вас! Вы пропустите следующий ход.";
    //        }
    //        return "";
    //    }
    //}

    //public class BossArchmage : Mage
    //{
    //    public BossArchmage()
    //    {
    //        Name = "Архимаг C++";
    //        MaxHP = (int)(20 * 1.8);
    //        CurrentHP = MaxHP;
    //        Attack = (int)(12 * 1.6);
    //        Defense = (int)(1 * 1.1);
    //    }

    //    public override string Effect(Player player)
    //    {
    //        Random rand = new Random();
    //        if (rand.NextDouble() < 0.35)
    //        {
    //            player.IsFrozen = true;
    //            return "Архимаг замораживает вас магией C++! Вы пропустите следующий ход.";
    //        }
    //        return "";
    //    }
    //}

    //public static class ConsoleColors
    //{
    //    public static ConsoleColor PlayerColor = ConsoleColor.Green;
    //    public static ConsoleColor EnemyColor = ConsoleColor.Red;
    //    public static ConsoleColor BossColor = ConsoleColor.Magenta;
    //    public static ConsoleColor ItemColor = ConsoleColor.Yellow;
    //    public static ConsoleColor SystemColor = ConsoleColor.Cyan;
    //    public static ConsoleColor DamageColor = ConsoleColor.Red;
    //    public static ConsoleColor HealColor = ConsoleColor.Green;
    //    public static ConsoleColor WarningColor = ConsoleColor.Yellow;
    //    public static ConsoleColor MenuColor = ConsoleColor.White;
    //    public static ConsoleColor InputColor = ConsoleColor.Gray;
    //}

    //public static class ConsoleHelper
    //{
    //    public static void WriteLineColor(string text, ConsoleColor color)
    //    {
    //        Console.ForegroundColor = color;
    //        Console.WriteLine(text);
    //        Console.ResetColor();
    //    }

    //    public static void WriteColor(string text, ConsoleColor color)
    //    {
    //        Console.ForegroundColor = color;
    //        Console.Write(text);
    //        Console.ResetColor();
    //    }

    //    public static void PrintSeparator()
    //    {
    //        Console.ForegroundColor = ConsoleColor.DarkGray;
    //        Console.WriteLine(new string('=', 50));
    //        Console.ResetColor();
    //    }
    //}

}
