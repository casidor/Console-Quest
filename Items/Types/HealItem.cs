using Game;

namespace Items
{
    class HealItem : Item, IUsable
    {
        public int HealAmount { get; private set; }
        public HealItem(string name, string Id, int healAmount)
        {
            Name = name;
            ID = Id;
            HealAmount = healAmount;
            MaxStackSize = 10;
        }
        bool IUsable.Use(Game.Hero hero)
        {
            return hero.Heal(HealAmount);
        }
    }
}