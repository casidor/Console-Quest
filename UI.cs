using System;
using System.Collections;
using System.Collections.Generic;
namespace Game
{
    public class UI
    {
        public enum MainMenuAction
        {
            ShowStats,
            Inventory,
            Chest,
            GoToForest,
            Exit
        }
        public static MainMenuAction GetMainMenuAction(Hero hero)
        {
            Console.Clear();
            Console.WriteLine("------------------------- Головне меню-------------------------");
            Console.WriteLine("Оберіть дію: 1 - Статистика | 2 - Інвентар | 3 - Обшукати ящик | 4 - Піти в ліс | 5 - Вийти");
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
        public static void WaitEnter(string message)
        {
            Console.WriteLine(message);
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {

            }
        }
        public static void ShowInventory(List<Item> items)
        {
            Console.WriteLine($"Ваш інвентар: ");
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {items[i].Name} (Сила: {items[i].Value})");
            }
        }
        public static bool UseItemFromInventory(Hero hero)
        {
            while (true)
            {
                Console.Clear();
                ShowInventory(hero.Inventory);
                Console.WriteLine("Оберіть предмет: | 0 - Назад");
                int choice;
                string input = Console.ReadLine() ?? "";
                bool check = int.TryParse(input, out choice);
                if (check)
                {
                    if (choice > 0 && choice <= hero.Inventory.Count)
                    {
                        Item picked = hero.Inventory[choice - 1];
                        bool used = hero.UseItem(picked);
                        if (used)
                        {
                            return true;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (choice == 0)
                    {
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Невідома дія");
                    Thread.Sleep(1000);
                    continue;
                }
            }
        }
        public static void OpenInventory(Hero hero)
        {
            while (true)
            {
                Console.Clear();
                ShowInventory(hero.Inventory);
                Console.WriteLine("Оберіть предмет: | 0 - Назад");
                int choice;
                string input = Console.ReadLine() ?? "";
                bool check = int.TryParse(input, out choice);
                if (check)
                {
                    if (choice > 0 && choice <= hero.Inventory.Count)
                    {
                        Item picked = hero.Inventory[choice - 1];
                        Console.WriteLine($"Обрано: {picked.Name}");
                        Console.WriteLine("Оберіть дію: 1 - Використати | 2 - Викинути | 0 - Назад");
                        string action = Console.ReadLine() ?? "";
                        switch (action)
                        {
                            case "1":
                                hero.UseItem(picked);
                                break;
                            case "2":
                                hero.Inventory.Remove(picked);
                                Console.WriteLine($"Ви викинули {picked.Name}");
                                Thread.Sleep(1000);
                                break;
                            case "0":
                                break;
                        }
                    }
                    else if (choice == 0)
                    {
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Невідома дія");
                    Thread.Sleep(1000);
                    continue;
                }
            }
        }
    }
}