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
        public void Fight(Hero hero, Enemy enemy)
        {
            Console.WriteLine($"На вас напав {enemy.Name}");
            Random rnd = new Random();
            while(hero.HP > 0 && enemy.HP >0)
            {
                Console.Clear();
                Console.WriteLine($"Ваш рівень здоров'я {hero.MaxHP}/{hero.HP}");
                Console.WriteLine($"Рівень здоров'я {enemy.Name}: {enemy.MaxHP}/{enemy.HP}");
                Console.WriteLine("Оберіть дію: 1 - Атакувати | 2 - Спробувати посилену атаку | 3 - Спробувати втекти" );
                string action = Console.ReadLine();
                if(action == "1")
                {
                    enemy.HP -= hero.ATK;
                    Console.WriteLine($"Ви нанесли {hero.ATK} шкоди ворогу!");
                }
                else if(action == "2")
                {
                    int chance = rnd.Next(1, 3);
                    if(chance == 1)
                    {
                        enemy.HP -= hero.ATK*2;
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
                if(enemy.HP > 0)
                {
                    int damage = enemy.GetDMG(rnd);
                    hero.HP -= damage;
                    Console.WriteLine($"{enemy.Name} завдав вам {damage} шкоди");
                }
                UI.WaitEnter("\nНатисніть ENTER для продовження..."); 
            }
            if(hero.HP <= 0)
            {
                Console.WriteLine("Ви загнули...");
                UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");  
            }
            else if(enemy.HP <= 0)
            {
                Console.WriteLine("Ви перемогли!");
                UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");  
            }
        }
    }
}