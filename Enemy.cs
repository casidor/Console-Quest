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
        public int minATK;
        public int maxATK;
        public int Crit;
        public Enemy(string Name, int MaxHP, int minATK, int maxATK, int Crit)
        {
            this.Name = Name;
            this.MaxHP = MaxHP;
            this.HP = MaxHP;
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
    public static class Enemies
    {
        public static Enemy Goblin => new Enemy("Гоблін", 50, 5, 7, 40);
    }
}
