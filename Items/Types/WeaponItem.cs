using Game;

namespace Items
{
    public class WeaponItem : Item, IEquippable
    {
        public int ATKBonus {get; private set;}
        public WeaponItem(string name, string Id, int atkBonus)
        {
            Name = name;
            ID = Id;
            ATKBonus = atkBonus;
            MaxStackSize = 1;
        }
        void IEquippable.Equip(Hero hero)
        {
            throw new NotImplementedException();
        }
        void IEquippable.Unequip(Hero hero)
        {
            throw new NotImplementedException();
        }
    }
}