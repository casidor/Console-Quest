using Game;
namespace UI
{
    public class HeroUI
    {
        private readonly Hero _hero;
        public HeroUI(Hero hero)
        {
            _hero = hero;
            hero.OnLevelUP += ShowLevelUP;
            hero.OnEXPGained += ShowEXPGained;
            hero.OnHealed += ShowHealed;
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
        public void ShowLevelUP()
        {
        Console.WriteLine("-----------------");
        Console.WriteLine($"Рівень підвищено! Ваші характеристики тепер:");
        Console.WriteLine($"Ваш рівень здоров'я {_hero.HP}/{_hero.MaxHP}");
        Console.WriteLine($"Сила героя: {_hero.ATK}");
        }
        public void ShowHealed(bool success, int HealAmount)
        {
            if (success)
            {
                Console.WriteLine($"Ви відновили {HealAmount} здоров'я!");
                Console.WriteLine($"Ваш рівень здоров'я {_hero.HP}/{_hero.MaxHP}");
                Thread.Sleep(1000);
            }
            else
            {
                Console.WriteLine("Ви вже повністю здорові!");
                Thread.Sleep(1000);
            }
        }
    }
}