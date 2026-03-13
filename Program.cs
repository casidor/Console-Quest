using System;
using System.Collections;
using System.Collections.Generic;
namespace Game
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Як будуть звати героя цієї подорожі?");
            string InputName = Console.ReadLine() ?? "Герой";
            Hero hero = new Hero(InputName);
            GameCore game = new GameCore(hero);
            game.Run();
        }
    }
}