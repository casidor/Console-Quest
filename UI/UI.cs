using System;
using System.Collections;
using System.Collections.Generic;
namespace Game
{
    public class UI
    {
        public static void WaitEnter(string message)
        {
            Console.WriteLine(message);
            while (Console.ReadKey(true).Key != ConsoleKey.Enter)
            {

            }
        }
        public static void ShowHeroStats(Hero hero)
        {
            Console.WriteLine("----------------------");
            Console.WriteLine($"Ім'я героя: {hero.Name}");
            Console.WriteLine($"Рівень героя: {hero.Level}");
            Console.WriteLine($"Досвід героя: {hero.EXP}/{hero.MaxEXP}");
            Console.WriteLine($"Здоров'я героя:{hero.HP}/{hero.MaxHP}");
            Console.WriteLine($"Сила героя: {hero.ATK}");
        }
        public static void ShowEXPGained(int EXP)
        {
            Console.WriteLine("-----------------");
            Console.WriteLine($"Ви отримали {EXP} досвіду!");
        }
        public static void ShowLevelUP(Hero hero){
        Console.WriteLine("-----------------");
        Console.WriteLine($"Рівень підвищено! Ваші характеристики тепер:");
        Console.WriteLine($"Ваш рівень здоров'я {hero.HP}/{hero.MaxHP}");
        Console.WriteLine($"Сила героя: {hero.ATK}");
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