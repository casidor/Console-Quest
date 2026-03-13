using System;
using System.Collections;
using System.Collections.Generic;
namespace Game
{
    public class GameCore
    {
        Hero hero;
        bool isRunning;
        public GameCore(Hero hero)
        {
            this.hero = hero;
            this.isRunning = true;
        }
        public void Run()
        {
            while (isRunning)
            {
                UI.MainMenuAction action = UI.GetMainMenuAction(hero);
                switch (action)
                {
                    case UI.MainMenuAction.ShowStats:
                        Console.Clear();
                        hero.ShowStats();
                        UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");
                        break;
                    case UI.MainMenuAction.Inventory:
                        UI.OpenInventory(hero);
                        break;
                    case UI.MainMenuAction.Chest:
                        Console.Clear();
                        if (hero.UsesLeft > 0)
                        {
                            hero.FindLoot();
                            hero.UsesLeft--;
                        }
                        else
                        {
                            Console.WriteLine("Ящик порожній. Схоже він загадковим чином наповнюється після битв :)");
                        }
                        UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");
                        break;
                    case UI.MainMenuAction.GoToForest:
                        Console.Clear();
                        Random rnd = new Random();
                        Enemy enemy = Enemies.AllEnemies[rnd.Next(Enemies.AllEnemies.Count)];
                        Battle combat = new Battle();
                        combat.Fight(hero, enemy);
                        break;
                    case UI.MainMenuAction.Exit:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}