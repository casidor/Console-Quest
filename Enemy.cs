using System;
using System.Collections;
using System.Collections.Generic;
namespace Game
{
     class Enemy
    {
        public string Name;
        public int MaxHP;
        public int HP;
        public int ATK;
        public Enemy(string Name, int MaxHP, int ATK)
        {
            this.Name = Name;
            this.MaxHP = MaxHP;
            this.HP = MaxHP;
            this.ATK = ATK;
        }
    }
}