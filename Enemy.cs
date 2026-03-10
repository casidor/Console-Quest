using System;
using System.Collections;
using System.Collections.Generic;
namespace Game
{
    public class Enemy
    {
        public string Name;
        public int MaxHP;
        public int HP;
        public int expGained;
        public int minATK;
        public int maxATK;
        public int Crit;
        public Enemy(string Name, int MaxHP, int expGained, int minATK, int maxATK, int Crit)
        {
            this.Name = Name;
            this.MaxHP = MaxHP;
            this.HP = MaxHP;
            this.expGained = expGained;
            this.minATK = minATK;
            this.maxATK = maxATK;
            this.Crit = Crit;
        }
        public int GetDMG(Random rnd)
        {
          int ATK = rnd.Next(minATK, maxATK + 1);
          int CritChance = rnd.Next(1, 101);
          if(CritChance <= Crit)
            {
                ATK *= 2;
                Console.WriteLine($"{Name} завдає КРИТИЧНОГО удару!");
            }
          return ATK;
        }
    }
    public class Enemies
    {
        public static Enemy Goblin => new Enemy("Гоблін", 50, 15, 5, 7, 10);
        public static Enemy Ork => new Enemy("Орк", 70, 20, 5, 12, 20);
        public static Enemy Skeleton => new Enemy("Скелет", 50, 25, 4, 9, 15);
        public static Enemy Golem => new Enemy("Голем", 100, 30, 2, 5, 20);
        public static List<Enemy> AllEnemies = new List<Enemy> (){Goblin, Ork, Skeleton, Golem};
    }
}
