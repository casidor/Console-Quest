using System;
using Game;
namespace UI
{
    class MainMenu
    {
        public enum MainMenuAction
        {
            ShowStats,
            Inventory,
            Chest,
            GoToForest,
            Exit
        }
        public static void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("------------------------- Головне меню-------------------------");
            Console.WriteLine("Оберіть дію: 1 - Статистика | 2 - Інвентар | 3 - Обшукати ящик | 4 - Піти в ліс | 5 - Вийти");
        }
        public static MainMenuAction GetMainMenuAction(Hero hero)
        {
            string action = Console.ReadLine() ?? "";
            switch (action)
            {
                case "1": return MainMenuAction.ShowStats;
                case "2": return MainMenuAction.Inventory;
                case "3": return MainMenuAction.Chest;
                case "4": return MainMenuAction.GoToForest;
                case "5": return MainMenuAction.Exit;
                default:
                    Console.WriteLine("Невідома дія");
                    Thread.Sleep(1000);
                    return GetMainMenuAction(hero);
            }
        }
    }
}