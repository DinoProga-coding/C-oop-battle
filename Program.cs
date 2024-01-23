using Classes;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp
{
    internal class Program
    { 
        static void Main(string[] args)
        {

            string decoration = new string('-', 30);

            Player player = new Player(100, 19, "Player");
            string playerInfo = player.info();

            Entity mob1 = new Mobs(89, 13, "Zombie");
            string mob1Info = mob1.GetInfo();
            Entity mob2 = new Mobs(80, 16, "Cursed skull");

            Player.AttackType attackType1 = Player.AttackType.flyAttack;
            Player.AttackType attackType2 = Player.AttackType.longAttack;
            Player.AttackType attackType3 = Player.AttackType.PowerAttack;

            string[] types = new string[] {attackType1.ToString(), attackType2.ToString(), attackType3.ToString()};

            Console.WriteLine($"You hero: {playerInfo}");
            Console.WriteLine("You attacks: ");
            Console.WriteLine("");
            for (int i = 0; i < types.Length; i++)
            {
                Console.WriteLine($"{i}: {types[i]}");
                Console.WriteLine(new string('-', 30));
            }
            Console.Write("You select: ");
            string selectedAttackType = Console.ReadLine();
            switch(selectedAttackType)
            {
                case "0":
                    Console.WriteLine("You Select: flyAttack");
                    player.UpgradeDamage();
                    Console.WriteLine("Player damage increased by 2");
                    break;      
                case "1":
                    Console.WriteLine("You Select: longAttack");
                    player.UpgradeDamage();
                    Console.WriteLine("Player damage increased by 2");
                    break;   
                case "2":
                    Console.WriteLine("You Select: PowerAttack");
                    player.UpgradeDamage();
                    Console.WriteLine("Player damage increased by 2");
                    break;
                default:
                    Console.WriteLine("Incorrect select");
                    break;
            }
            Console.WriteLine(decoration);
            Console.WriteLine($"You're going into battle with {mob1.Name}");
            Console.WriteLine(decoration);
            Console.WriteLine(mob1Info);
            Console.WriteLine(decoration);
            Thread.Sleep(1000);
            while (player.Health > 0 && mob1.Health > 0)
            {
                player.TakeDamage(mob1.Damage);
                mob1.TakeDamage(player.Damage);
                Console.WriteLine($"{player.Name} health:  {player.Health}");
                Console.WriteLine($"{mob1.Name} health: {mob1.Health}");
                Console.ReadKey();
            }
            if(player.Health <= 0 && mob1.Health <= 0)
            {
                Console.WriteLine("Draw");
            }
            else if (player.Health <= 0)
            {
                Console.WriteLine("You lose");
            }
            else if(mob1.Health <= 0)
            {
                Console.WriteLine("Victory");
            }
        }
        class Player
        {
            public int Health { get; private set; }
            public int Damage { get; private set; }
            public string Name { get; private set; }

            public Player(int health, int damage, string name)
            {
                Health = health;
                Damage = damage;
                Name = name;
            }
            public int TakeDamage(int damage)
            { 
                return Health -= damage;
            }
            public string info()
            {
                return $"{Name}, health: {Health}, damage: {Damage}";
            }
            public void UpgradeDamage()
            {
                Damage += 2;
            }

            public enum AttackType
            {
                longAttack,
                flyAttack,
                PowerAttack
            }
        }
    }
}

namespace Classes
{
    abstract class Entity
    {
        public int Health { get; private set; }
        public int Damage { get; private set; }
        public string Name { get; private set; }
        public Entity(int health, int damage, string name)
        {
            Health = health;
            Damage = damage;
            Name = name;
        }
        public int TakeDamage(int damage)
        {
            return Health -= damage;
        }
        public string GetInfo()
        {
            return $"{Name}, health: {Health}, damage: {Damage}";
        }
        public abstract string EntityType();
    }

    class Mobs : Entity
    {
        public Mobs(int health, int damage, string name) : base(health, damage, name) { }

        public override string EntityType()
        {
            return "Type: mob";
        }
    }   
    class Bosses : Entity
    {
        public Bosses(int health, int damage, string name) : base(health, damage, name) { }

        public override string EntityType()
        {
            return "Type: boss";
        }
    }
}