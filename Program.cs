using System;
using System.Collections;
using System.Collections.Generic;
namespace Game
{
    class Program
    {
        static void Main ()
        {
        Console.WriteLine("Як будуть звати героя цієї подорожі?");
        string InputName = Console.ReadLine() ?? "Герой";
        Hero hero = new Hero(InputName);
        bool isRunning = true;
        while(isRunning)
         {
         Console.Clear();
         Console.WriteLine("-------------------------Головне меню-------------------------");
         Console.WriteLine("Оберіть дію: 1 - Статистика | 2 - Обшукати ящик | 3 - Піти в ліс | 4 - Вийти" );
         string action = Console.ReadLine() ?? "";
                switch (action)
                {
                    case "1":
                    Console.Clear();
                    hero.ShowStats();
                    UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");
                    break;
                    case "2":
                    Console.Clear();
                    hero.FindLoot();
                    UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");
                    break;
                    case "3":
                    Console.Clear();
                    Enemy enemy = Enemies.Goblin;
                    Battle combat = new Battle();
                    combat.Fight(hero, enemy);
                    break;
                    case "4":
                    isRunning = false;
                    break;
                }   
        }
    }
}
}