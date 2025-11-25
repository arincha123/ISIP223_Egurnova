using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISIP223_Egurnova.Model;

//рвоарюфдвал
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

    public class Game
    {
        private Player player;
        private Random random;
        private int turnCount;
        private List<Item> possibleItems;

        public Game()
        {
            player = new Player();
            random = new Random();
            turnCount = 0;
            InitializeItems();
        }

        private void InitializeItems()
        {
            possibleItems = new List<Item>
            {
                new Weapon("Стальной меч", 10, 0, WeaponType.Melee),
                new Weapon("Секира воина", 15, 2, WeaponType.Melee),
                new Weapon("Кинжал убийцы", 8, 0, WeaponType.Melee),
                new Weapon("Легендарный клинок", 20, 5, WeaponType.Melee),

                new Weapon("Длинный лук", 12, 0, WeaponType.Ranged),
                new Weapon("Арбалет снайпера", 18, 1, WeaponType.Ranged),
                new Weapon("Боевой посох", 6, 3, WeaponType.Ranged),

                new Weapon("Магический посох", 12, 3, WeaponType.Magic),
                new Weapon("Книга заклинаний", 14, 2, WeaponType.Magic),
                new Weapon("Кристальный скипетр", 16, 4, WeaponType.Magic),

                new Armor("Кожаный доспех", 0, 5, ArmorType.Light),
                new Armor("Одежды мага", 2, 4, ArmorType.Light),
                new Armor("Плащ разведчика", 1, 3, ArmorType.Light),

                new Armor("Кольчуга", 0, 8, ArmorType.Medium),
                new Armor("Чешуйчатая броня", 1, 10, ArmorType.Medium),
                new Armor("Бригантина", 0, 12, ArmorType.Medium),

                new Armor("Латные доспехи", 0, 15, ArmorType.Heavy),
                new Armor("Драконья броня", 5, 20, ArmorType.Heavy),
                new Armor("Доспехи чемпиона", 3, 18, ArmorType.Heavy)
            };
        }

        public void Start()
        {
            Console.Title = "Текстовый Рогалик";
            Console.Clear();

            ConsoleHelper.WriteLineColor("Добро пожаловать в текстовый рогалик!", ConsoleColors.SystemColor);
            ConsoleHelper.WriteLineColor("Каждый ход вы будете встречать либо сундук, либо врага.", ConsoleColors.MenuColor);
            ConsoleHelper.WriteLineColor("Каждые 10 ходов вас ждёт встреча с боссом!\n", ConsoleColors.WarningColor);

            while (player.IsAlive())
            { 
                turnCount++;
                ConsoleHelper.PrintSeparator();
                ConsoleHelper.WriteLineColor($"=== Ход {turnCount} ===", ConsoleColors.SystemColor);
                ConsoleHelper.WriteLineColor(player.ToString(), ConsoleColors.PlayerColor);

                if (player.IsFrozen)
                {
                    ConsoleHelper.WriteLineColor("Вы заморожены и пропускаете ход!", ConsoleColors.WarningColor);
                    player.IsFrozen = false;
                    ContinueGame();
                    continue;
                }

                int eventType = random.Next(0, 2);
                switch (eventType)
                {
                    case 0:
                        EncounterEnemy();
                        break;
                    case 1:
                        OpenChest();
                        break;
                }

                if (!player.IsAlive())
                {
                    ConsoleHelper.PrintSeparator();
                    ConsoleHelper.WriteLineColor("=== ИГРА ОКОНЧЕНА ===", ConsoleColors.DamageColor);
                    ConsoleHelper.WriteLineColor($"Вы продержались {turnCount} ходов.", ConsoleColors.SystemColor);
                    break;
                }

                ContinueGame();
            }
        }

        private void EncounterEnemy()
        {
            Enemy enemy;

            if (turnCount % 10 == 0)
            {
                int bossType = random.Next(0, 4);
                switch (bossType)
                {
                    case 0: enemy = new BossVVG(); break;
                    case 1: enemy = new BossKovalsky(); break;
                    case 2: enemy = new BossArchmage(); break;
                    case 3: enemy = new BossPestov(); break;
                    default: enemy = new BossVVG(); break;
                }
                ConsoleHelper.WriteLineColor($"\n!!! Появляется БОСС - {enemy.Name} !!!", ConsoleColors.BossColor);
            }
            else
            {
                int enemyType = random.Next(0, 3);
                switch (enemyType)
                {
                    case 0: enemy = new Goblin(); break;
                    case 1: enemy = new Skeleton(); break;
                    case 2: enemy = new Mage(); break;
                    default: enemy = new Goblin(); break;
                }
                ConsoleHelper.WriteLineColor($"\nПоявляется враг - {enemy.Name}!", ConsoleColors.EnemyColor);
            }

            ConsoleHelper.WriteLineColor(enemy.ToString(), ConsoleColors.EnemyColor);
            Battle(enemy);
        }

        private void Battle(Enemy enemy)
        {
            while (player.IsAlive() && enemy.IsAlive())
            {
                ConsoleHelper.WriteLineColor("\nВаш ход:", ConsoleColors.MenuColor);
                ConsoleHelper.WriteLineColor("1 - Атаковать", ConsoleColors.MenuColor);
                ConsoleHelper.WriteLineColor("2 - Защищаться", ConsoleColors.MenuColor);
                ConsoleHelper.WriteColor("Выберите действие: ", ConsoleColors.InputColor);

                string input = Console.ReadLine();
                bool usedDefense = false;

                if (input == "1")
                {
                    int playerDamage = player.GetAttack();
                    enemy.TakeDamage(playerDamage);
                    ConsoleHelper.WriteLineColor($"Вы наносите {playerDamage} урона!", ConsoleColors.DamageColor);
                }
                else if (input == "2")
                {
                    usedDefense = true;
                    ConsoleHelper.WriteLineColor("Вы готовитесь к защите...", ConsoleColors.SystemColor);
                }
                else
                {
                    ConsoleHelper.WriteLineColor("Неверный ввод, вы пропускаете ход!", ConsoleColors.WarningColor);
                }

                if (!enemy.IsAlive())
                {
                    ConsoleHelper.WriteLineColor($"\n{enemy.Name} повержен!", ConsoleColors.SystemColor);
                    return;
                }

                ConsoleHelper.WriteLineColor($"\nХод {enemy.Name}:", ConsoleColors.EnemyColor);

                int enemyDamage = enemy.GetDamage(player, usedDefense);
                int finalDamage = enemyDamage;

                if (usedDefense)
                {
                    int dodgeRoll = random.Next(0, 10);
                    if (dodgeRoll < 4)
                    {
                        ConsoleHelper.WriteLineColor("Вы успешно уклонились от атаки!", ConsoleColors.HealColor);
                        finalDamage = 0;
                    }
                    else
                    {
                        int blockPower = random.Next(0, 4);
                        double blockPercent = 0;
                        switch (blockPower)
                        {
                            case 0: blockPercent = 0.7; break;
                            case 1: blockPercent = 0.8; break;
                            case 2: blockPercent = 0.9; break;
                            case 3: blockPercent = 1.0; break;
                            default: blockPercent = 0.8; break;
                        }
                        int blockedDamage = (int)(player.GetDefense() * blockPercent);
                        finalDamage = Math.Max(0, enemyDamage - blockedDamage);
                        ConsoleHelper.WriteLineColor($"Вы блокируете {blockedDamage} урона!", ConsoleColors.SystemColor);
                    }
                }

                if (finalDamage > 0)
                {
                    player.TakeDamage(finalDamage);
                    ConsoleHelper.WriteLineColor($"{enemy.Name} наносит вам {finalDamage} урона!", ConsoleColors.DamageColor);
                }

                string specialEffect = enemy.Effect(player);
                if (!string.IsNullOrEmpty(specialEffect))
                {
                    ConsoleHelper.WriteLineColor(specialEffect, ConsoleColors.WarningColor);
                }

                ConsoleHelper.WriteLineColor($"\nСостояние после раунда:", ConsoleColors.SystemColor);
                ConsoleHelper.WriteLineColor(player.ToString(), ConsoleColors.PlayerColor);
                ConsoleHelper.WriteLineColor(enemy.ToString(), ConsoleColors.EnemyColor);

                if (!player.IsAlive())
                {
                    ConsoleHelper.WriteLineColor("\nВы пали в бою...", ConsoleColors.DamageColor);
                    return;
                }

                ContinueGame();
            }
        }

        private void OpenChest()
        {
            ConsoleHelper.WriteLineColor("\nВы нашли сундук!", ConsoleColors.ItemColor);

            int chestContent = random.Next(0, 10);
            switch (chestContent)
            {
                case 0:
                case 1:
                case 2:
                    ConsoleHelper.WriteLineColor("В сундуке лечебное зелье!", ConsoleColors.HealColor);
                    player.Heal();
                    ConsoleHelper.WriteLineColor("Ваше здоровье полностью восстановлено!", ConsoleColors.HealColor);
                    break;
                default:
                    int itemIndex = random.Next(0, possibleItems.Count);
                    Item foundItem = possibleItems[itemIndex];
                    ConsoleHelper.WriteLineColor($"В сундуке: {foundItem}", ConsoleColors.ItemColor);

                    ConsoleHelper.WriteLineColor("\nВаша текущая экипировка:", ConsoleColors.MenuColor);

                    if (foundItem is Weapon)
                    {
                        Weapon foundWeapon = (Weapon)foundItem;
                        ConsoleHelper.WriteLineColor($"Оружие: {player.Weapon}", ConsoleColors.ItemColor);
                        ConsoleHelper.WriteColor("\nХотите взять новое оружие? (y/n): ", ConsoleColors.InputColor);

                        string input = Console.ReadLine().ToLower();
                        if (input == "y" || input == "д")
                        {
                            player.Weapon = foundWeapon;
                            ConsoleHelper.WriteLineColor($"Вы экипировали: {foundWeapon.Name}", ConsoleColors.SystemColor);
                        }
                        else
                        {
                            ConsoleHelper.WriteLineColor("Вы оставили оружие в сундуке.", ConsoleColors.WarningColor);
                        }
                    }
                    else if (foundItem is Armor)
                    {
                        Armor foundArmor = (Armor)foundItem;
                        ConsoleHelper.WriteLineColor($"Броня: {player.Armor}", ConsoleColors.ItemColor);
                        ConsoleHelper.WriteColor("\nХотите взять новую броню? (y/n): ", ConsoleColors.InputColor);

                        string input = Console.ReadLine().ToLower();
                        if (input == "y" || input == "д")
                        {
                            player.Armor = foundArmor;
                            ConsoleHelper.WriteLineColor($"Вы экипировали: {foundArmor.Name}", ConsoleColors.SystemColor);
                        }
                        else
                        {
                            ConsoleHelper.WriteLineColor("Вы оставили броню в сундуке.", ConsoleColors.WarningColor);
                        }
                    }
                    break;
            }
        }

        private void ContinueGame()
        {
            {
                Console.WriteLine("\nНажмите любую клавишу для продолжения...");
                Console.ReadKey();
            }
        }
    }
}
