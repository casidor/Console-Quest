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
        public Hero(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.MaxHP = 100;
            this.HP = 100;
            this.ATK = 10;
            this.Inventory = new List<string>() {"Іржавий меч","Зілля регенерації", "Яблуко"};
        }
        public void ShowStats()
        {
        Console.WriteLine("----------------------");
        Console.WriteLine($"Ім'я героя: {Name}");
        Console.WriteLine($"Рівень героя: {Level}");
        Console.WriteLine($"Здоров'я героя:{MaxHP}/{HP}");
        Console.WriteLine($"Сила героя: {ATK}");
        Console.WriteLine($"Ваш інвентар: ");
        foreach (string item in Inventory)
        {
         Console.WriteLine($"- {item}");
        }
        }
        public void Levelup()
        {
        Level ++; 
        Console.WriteLine("-----------------");
        Console.WriteLine("Рівень підвищено!");
        }
        public void FindLoot()
        {
        string newItem = ("Тестовий предмет");
        Inventory.Add(newItem);
        Console.WriteLine($"Ви знайшли:{newItem}");
        }
    }
}