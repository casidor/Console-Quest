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
        public void Fight()
        {
            Enemy goblin = new Enemy();
            goblin.Name = "Гоблін";
            goblin.MaxHP = 50;
            goblin.HP = 50;
            goblin.ATK = 5;
            Console.WriteLine($"На вас напав {goblin.Name}");
            Random rnd = new Random();
            while(this.HP > 0 && goblin.HP >0)
            {
                Console.Clear();
                Console.WriteLine($"Ваш рівень здоров'я {this.MaxHP}/{this.HP}");
                Console.WriteLine($"Рівень здоров'я {goblin.Name}: {goblin.HP}");
                Console.WriteLine("Оберіть дію: 1 - Атакувати | 2 - Спробувати посилену атаку | 3 - Спробувати втекти" );
                string action = Console.ReadLine();
                if(action == "1")
                {
                    goblin.HP -= this.ATK;
                    Console.WriteLine($"Ви нанесли {this.ATK} шкоди ворогу!");
                }
                else if(action == "2")
                {
                    int chance = rnd.Next(1, 3);
                    if(chance == 1)
                    {
                        goblin.HP -= this.ATK*2;
                        Console.WriteLine($"Критичний удар! Ви нанесли {this.ATK * 2} шкоди!");
                    }
                    else
                    {
                        Console.WriteLine("Ви розмахнулися занадто сильно і промахнулися!");
                    }
                }
                else if(action == "3")
                {
                    int chance = rnd.Next(1, 3);
                    if(chance == 1)
                    {
                        Console.WriteLine("Вдолося! Ви втекли з поля бою!");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Втекти невдалося!");
                    }
                }
                if(goblin.HP > 0)
                {
                    this.HP -= goblin.ATK;
                    Console.WriteLine($"{goblin.Name} завдав вам {goblin.ATK} шкоди");
                }
                Program.WaitEnter();  
            }
            if(this.HP == 0)
            {
                Console.WriteLine("Ви загнули...");
                Program.WaitEnter();  
            }
            else if(goblin.HP == 0)
            {
                Console.WriteLine("Ви перемогли!");
                Program.WaitEnter();  
            }
        }
    }
    class Enemy
    {
        public string Name;
        public int MaxHP;
        public int HP;
        public int ATK;
    }
    class Program
    {
        public static void WaitEnter()
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
         Console.WriteLine("Оберіть дію: 1 - Статистика | 2 - Прокачати рівень | 3 - Обшукати ящик | 4 - Піти в ліс | 5 - Вийти" );
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
            Console.Clear();
            hero.Fight();
         }
         else if (action == "5")
         {
            break;
         }
        }
    }
}
}