using System;
using System.Collections;
using System.Collections.Generic;
namespace Game
{
    class Hero
    {
        public List<string> Inventory;
        public string Name;
        public int Level;
        public int MaxHP;
        public int HP;
        public int ATK;
        public int EXP;
        public int MaxEXP;
        public Hero(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.MaxHP = 100;
            this.HP = 100;
            this.ATK = 10;
            this.EXP = 0;
            this.MaxEXP = 100;
            this.Inventory = new List<string>() {"Іржавий меч","Зілля регенерації", "Яблуко"};
        }
        public void ShowStats()
        {
        Console.WriteLine("----------------------");
        Console.WriteLine($"Ім'я героя: {Name}");
        Console.WriteLine($"Рівень героя: {Level}");
        Console.WriteLine($"Досвід героя: {EXP}/{MaxEXP}");
        Console.WriteLine($"Здоров'я героя:{MaxHP}/{HP}");
        Console.WriteLine($"Сила героя: {ATK}");
        Console.WriteLine($"Ваш інвентар: ");
        foreach (string item in Inventory)
        {
         Console.WriteLine($"- {item}");
        }
        }
        public void GainEXP()
        {
            int XP = 50;
            EXP += XP;
            Console.WriteLine("-----------------");
            Console.WriteLine($"Ви отримали {XP} досвіду!");
            if(EXP >= MaxEXP)
            {
                Levelup();
            }
        }
        public void Levelup()
        {
        Level ++; 
        MaxHP += 20;
        ATK += 5;
        HP = MaxHP;
        EXP -= MaxEXP;
        MaxEXP += 50;
        Console.WriteLine("-----------------");
        Console.WriteLine($"Рівень підвищено! Ваші характеристики тепер:");
        Console.WriteLine($"Ваш рівень здоров'я {MaxHP}/{HP}");
        Console.WriteLine($"Сила героя: {ATK}");
        }
        public void FindLoot()
        {
        string newItem = ("Тестовий предмет");
        Inventory.Add(newItem);
        Console.WriteLine($"Ви знайшли:{newItem}");
        }
    }
}