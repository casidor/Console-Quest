using System;
using System.Collections;
using System.Collections.Generic;
using Battle;
using UI;
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
                MainMenu.ShowMainMenu();
                MainMenu.MainMenuAction action = MainMenu.GetMainMenuAction(hero);
                switch (action)
                {
                    case MainMenu.MainMenuAction.ShowStats:
                        Console.Clear();
                        hero.ShowStats();
                        UI.WaitEnter("\nНатисніть ENTER для повернення до головного меню...");
                        break;
                    case MainMenu.MainMenuAction.Inventory:
                        UI.OpenInventory(hero);
                        break;
                    case MainMenu.MainMenuAction.Chest:
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
                    case MainMenu.MainMenuAction.GoToForest:
                        Console.Clear();
                        Random rnd = new Random();
                        Enemy enemy = Enemies.AllEnemies[rnd.Next(Enemies.AllEnemies.Count)];
                        BattleController combat = new BattleController();
                        combat.BattleMode(hero, enemy);
                        break;
                    case MainMenu.MainMenuAction.Exit:
                        isRunning = false;
                        break;
                }
            }
        }
    }
}