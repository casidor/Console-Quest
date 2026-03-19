using Game;
namespace Items
{
    public interface IEquippable
    {
            void Equip(Hero hero);
            void Unequip(Hero hero);
    }
}