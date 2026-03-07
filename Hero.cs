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
        public void Fight()
        {
            Enemy goblin = new Enemy("Гоблін", 50,5);
            Console.WriteLine($"На вас напав {goblin.Name}");
            Random rnd = new Random();
            while(this.HP > 0 && goblin.HP >0)
            {
                Console.Clear();
                Console.WriteLine($"Ваш рівень здоров'я {this.MaxHP}/{this.HP}");
                Console.WriteLine($"Рівень здоров'я {goblin.Name}: {goblin.MaxHP}/{goblin.HP}");
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
                UI.WaitEnter("\nНатисніть ENTER для продовження..."); 
            }
            if(this.HP <= 0)
            {
                Console.WriteLine("Ви загнули...");
                UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");  
            }
            else if(goblin.HP <= 0)
            {
                Console.WriteLine("Ви перемогли!");
                UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");  
            }
        }
    }
}