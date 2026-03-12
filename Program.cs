using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace Game
{
    public class Program
    {
        public static void Main ()
        {
        Console.WriteLine("Як будуть звати героя цієї подорожі?");
        string InputName = Console.ReadLine() ?? "Герой";
        Hero hero = new Hero(InputName);
        bool isRunning = true;
        while(isRunning)
         {
         Console.Clear();
         Console.WriteLine("------------------------- Головне меню-------------------------");
         Console.WriteLine("Оберіть дію: 1 - Статистика | 2 - Інвентар | 3 - Обшукати ящик | 4 - Піти в ліс | 5 - Вийти" );
         string action = Console.ReadLine() ?? "";
                switch (action)
                {
                    case "1":
                    Console.Clear();
                    hero.ShowStats();
                    UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");
                    break;
                    case "2":
                    UI.OpenInventory(hero);
                    break;
                    case "3":
                    Console.Clear();
                    if(hero.UsesLeft > 0)
                        {
                            hero.FindLoot();
                            hero.UsesLeft --; 
                        }
                        else
                        {
                            Console.WriteLine("Ящик порожній. Схоже він загадковим чином наповнюється після битв :)");
                        }
                    UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");
                    break;
                    case "4":
                    Console.Clear();
                    Random rnd = new Random();
                    Enemy enemy = Enemies.AllEnemies[rnd.Next(Enemies.AllEnemies.Count)];
                    Battle combat = new Battle();
                    combat.Fight(hero, enemy);
                    break;
                    case "5":
                    isRunning = false;
                    break;
                }   
        }
    }
}
}