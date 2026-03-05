using System;
namespace Game
{
    class Hero
    {
        public string Name;
        public int Level = 1;
        public void ShowStats()
        {
        Console.WriteLine("----------------------");
        Console.WriteLine($"Ім'я героя: {Name}");
        Console.WriteLine($"Рівень героя: {Level}");
        }
        public void Levelup()
        {
        Level ++; 
        Console.WriteLine("-----------------");
        Console.WriteLine("Рівень підвищено!");
        }
    }
    class Program
    {
        static void WaitEnter()
        {
          Console.WriteLine("\n Натисніть ENTER для повернення в головне меню...");
          while (Console.ReadKey(true).Key != ConsoleKey.Enter)
          {

          }
        }
        static void Main ()
        {
        Hero hero = new Hero();
        Console.WriteLine("Як будуть звати героя цієї подорожі?");
        hero.Name = Console.ReadLine();
        while(true)
         {
         Console.Clear();
         Console.WriteLine("-------------------------Головне меню-------------------------");
         Console.WriteLine("Оберіть дію: 1 - Статистика | 2 - Прокачати рівень | 3 - Вийти");
         string action = Console.ReadLine();
         if(action == "1")
         {
          Console.Clear();
          hero.ShowStats();
          WaitEnter();
         }
         else if(action == "2")
         {
            Console.Clear();
            hero.Levelup();
            WaitEnter();
         }
         else if(action == "3")
         {
            break;
         }
         }
        }
    }
}