using System;
using System.Collections;
using System.Collections.Generic;
namespace Game
{
    class UI
    {
        public static void WaitEnter(string message)
        {
          Console.WriteLine(message);
          while (Console.ReadKey(true).Key != ConsoleKey.Enter)
          {

          }
        }
    }
}