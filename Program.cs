using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace Game
{
    class Hero
    {
        public List<string> Inventory = new List<string>() {"Іржавий меч","Зілля регенерації", "Яблуко"};
        public string Name;
        public int Level = 1;
        public int MaxHP = 100;
        public int HP = 100;
        public int ATK = 10;
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
    class Program
    {
        static void WaitEnter()
        {
          Console.WriteLine("\n Натисніть ENTER для повернення в головне меню...");
          while (Console.ReadKey(true).Key != ConsoleKey.Enter)
          {

          }
        }
        static void Main ()
        {
        Hero hero = new Hero();
        Console.WriteLine("Як будуть звати героя цієї подорожі?");
        hero.Name = Console.ReadLine();
        while(true)
         {
         Console.Clear();
         Console.WriteLine("-------------------------Головне меню-------------------------");
         Console.WriteLine("Оберіть дію: 1 - Статистика | 2 - Прокачати рівень | 3 - Обшукати ящик | 4 - Вийти" );
         string action = Console.ReadLine();
         if(action == "1")
         {
          Console.Clear();
          hero.ShowStats();
          WaitEnter();
         }
         else if(action == "2")
         {
            Console.Clear();
            hero.Levelup();
            WaitEnter();
         }
         else if(action == "3")
         {
            Console.Clear();
            hero.FindLoot();
            WaitEnter();
         }
         else if (action == "4")
         {
            break;
         }
        }
    }
}
}