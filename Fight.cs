using System;
using System.Collections;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Threading;
namespace Game
{
    class Battle
    {
        public void Fight(Hero hero, Enemy enemy)
        {
            Console.WriteLine($"На вас напав {enemy.Name}");
            Random rnd = new Random();
            bool Escaped = false;
            while(hero.HP > 0 && enemy.HP >0 && !Escaped)
            {
                Console.Clear();
                Console.WriteLine($"Ваш рівень здоров'я {hero.HP}/{hero.MaxHP}");
                Console.WriteLine($"Рівень здоров'я {enemy.Name}: {enemy.HP}/{enemy.MaxHP}");
                Console.WriteLine("Оберіть дію: 1 - Атакувати | 2 - Спробувати посилену атаку | 3 - Спробувати втекти" );
                string action = Console.ReadLine() ?? "";
                switch (action)
                {
                    case "1":
                    enemy.HP -= hero.ATK;
                    Console.WriteLine($"Ви нанесли {hero.ATK} шкоди ворогу!");
                    Thread.Sleep(1000);
                    break;
                    case "2":
                    int chanceCRIT = rnd.Next(1, 3);
                    if(chanceCRIT == 1)
                    {
                        enemy.HP -= hero.ATK*2;
                        Console.WriteLine($"Критичний удар! Ви нанесли {hero.ATK * 2} шкоди!");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Ви розмахнулися занадто сильно і промахнулися!");
                        Thread.Sleep(1000);
                    }
                    break;
                    case "3":
                    int chanceESC = rnd.Next(1, 3);
                    if(chanceESC == 1)
                    {
                        Console.WriteLine("Вдолося! Ви втекли з поля бою!");
                        Escaped = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Втекти невдалося!");
                        Thread.Sleep(1000);
                    }
                    break;
                    default:
                    Console.WriteLine("Невідома дія");
                    Thread.Sleep(1000);
                    continue;
                }
                if(enemy.HP > 0 && !Escaped)
                {
                    int damage = enemy.GetDMG(rnd);
                    hero.HP -= damage;
                    Console.WriteLine($"{enemy.Name} завдав вам {damage} шкоди");
                    Thread.Sleep(1000);
                }
                if(hero.HP > 0 && enemy.HP >0 && !Escaped){
                    UI.WaitEnter("\nНатисніть ENTER для продовження..."); 
                }
            }
            if (Escaped)
            {
                UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню..."); 
            }
            else if(hero.HP <= 0)
            {
                Console.WriteLine("Ви загнули...");
                UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");  
            }
            else if(enemy.HP <= 0)
            {
                Console.WriteLine("Ви перемогли!");
                hero.GainEXP(enemy.expGained);
                UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");  
            }
        }
    }
}