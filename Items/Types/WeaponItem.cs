using Game;

namespace Items
{
    public class WeaponItem : Item, IEquippable
    {
        public int ATKBonus {get; private set;}
        public WeaponItem(string name, int atkBonus)
        {
            Name = name;
            ATKBonus = atkBonus;
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