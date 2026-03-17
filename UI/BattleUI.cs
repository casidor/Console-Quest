using System.Runtime.InteropServices.Marshalling;
using Battle;
namespace UI
{
    class BattleUI
    {
        public static void RenderStart(string enemyName) => Console.WriteLine($"На вас напав {enemyName}");
        public static void RenderStats(HeroDTO hero, EnemyDTO enemy)
        {
            Console.Clear();
            Console.WriteLine($"Ваш рівень здоров'я {hero.HP}/{hero.MaxHP}");
            Console.WriteLine($"Рівень здоров'я {enemy.Name}: {enemy.HP}/{enemy.MaxHP}");
        }
        public static BattleAction GetPlayerAction()
        {
            while (true)
            {
                Console.WriteLine("Оберіть дію: 1 - Атакувати | 2 - Посилена атака | 3 - Предмет | 4 - Втекти");
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "1": return BattleAction.Attack;
                    case "2": return BattleAction.HeavyAttack;
                    case "3": return BattleAction.UseItem;
                    case "4": return BattleAction.Escape;
                    default:
                        Console.WriteLine("Невідома дія. Спробуйте ще раз.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
        public static void RenderPlayerAction(ActionDTO dto)
        {
            switch (dto.ActionType)
            {
                case BattleAction.Attack:
                    Console.WriteLine($"Ви нанесли {dto.Damage} шкоди ворогу!");
                    Thread.Sleep(1000);
                    break;
                case BattleAction.HeavyAttack:
                    if (dto.IsCrit)
                    {
                        Console.WriteLine($"Критичний удар! Ви нанесли {dto.Damage} шкоди!");
                        Thread.Sleep(1000);
                    }
                    else
                    {
                        Console.WriteLine("Ви розмахнулися занадто сильно і промахнулися!");
                        Thread.Sleep(1000);
                    }
                    break;
                case BattleAction.Escape:
                    if (dto.IsEscapeSuccess)
                    {
                        Console.WriteLine("Вдалося! Ви втекли з поля бою!");
                    }
                    else
                    {
                        Console.WriteLine("Втекти не вдалося!");
                        Thread.Sleep(1000);
                    }
                    break;
            }
        }
        public static void RenderEnemyTurn(EnemyDTO enemy, ActionDTO dto)
        {
            Console.WriteLine($"{enemy.Name} завдав вам {dto.Damage} шкоди");
            Thread.Sleep(1000);
        }
        public static void RenderVictory() => Console.WriteLine("Ви перемогли!");
        public static void RenderDefeat() => Console.WriteLine("Ви загинули...");
    }
}