using Game;

namespace Items
{
    class HealItem : Item, IUsable
    {
        public int HealAmount { get; private set; }
        public HealItem(string name, int healAmount)
        {
            Name = name;
            HealAmount = healAmount;
        }
        bool IUsable.Use(Game.Hero hero)
        {
            return hero.Heal(HealAmount);
        }
    }
}