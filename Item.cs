using System;
using System.Collections;
using System.Collections.Generic;
namespace Game
{
    public enum ItemType {Weapon, Heal, Food}
    public class Item
    {
        public string Name;
        public int ID;
        public ItemType Type;
        public int Value;
        public Item(string name, int id, ItemType type, int value)
        {
            this.Name = name;
            this.ID = id;
            this.Type = type;
            this.Value = value;
        }
    }
    public static class Items
    {
        public static Item Apple => new Item("Яблуко", 301, ItemType.Food, 10);
        public static Item RustySword => new Item("Іржавий меч", 101, ItemType.Weapon, 5);
        public static Item SmallHeal => new Item("Маленьке зілля лікування", 201, ItemType.Heal, 20);
        public static Item IronSword => new Item("Залізний меч", 102, ItemType.Weapon, 10);
    }
}
