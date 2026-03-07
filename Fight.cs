using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;
namespace Game
{
    class Battle
    {
        public void Fight(Hero hero)
        {
            Enemy goblin = new Enemy("Гоблін", 50,5);
            Console.WriteLine($"На вас напав {goblin.Name}");
            Random rnd = new Random();
            while(hero.HP > 0 && goblin.HP >0)
            {
                Console.Clear();
                Console.WriteLine($"Ваш рівень здоров'я {hero.MaxHP}/{hero.HP}");
                Console.WriteLine($"Рівень здоров'я {goblin.Name}: {goblin.MaxHP}/{goblin.HP}");
                Console.WriteLine("Оберіть дію: 1 - Атакувати | 2 - Спробувати посилену атаку | 3 - Спробувати втекти" );
                string action = Console.ReadLine();
                if(action == "1")
                {
                    goblin.HP -= hero.ATK;
                    Console.WriteLine($"Ви нанесли {hero.ATK} шкоди ворогу!");
                }
                else if(action == "2")
                {
                    int chance = rnd.Next(1, 3);
                    if(chance == 1)
                    {
                        goblin.HP -= hero.ATK*2;
                        Console.WriteLine($"Критичний удар! Ви нанесли {hero.ATK * 2} шкоди!");
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
                    hero.HP -= goblin.ATK;
                    Console.WriteLine($"{goblin.Name} завдав вам {goblin.ATK} шкоди");
                }
                UI.WaitEnter("\nНатисніть ENTER для продовження..."); 
            }
            if(hero.HP <= 0)
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