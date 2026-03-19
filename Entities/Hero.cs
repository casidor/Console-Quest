using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Threading;
namespace Game
{
    public class Hero : Creature
    {
        public List<Item> Inventory;
        public int Level{ get; private set; }
        public int ATK{ get; private set; }
        public int EXP{ get; private set; }
        public int MaxEXP{ get; private set; }
        public int UsesLeft = 0;
        public event Action? OnLevelUP;
        public event Action<int>? OnEXPGained;
        public event Action<bool, int>? OnHealed;
        public Hero(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.MaxHP = 100;
            this.HP = 100;
            this.ATK = 10;
            this.EXP = 0;
            this.MaxEXP = 100;
            this.Inventory = new List<Item>() {Items.RustySword, Items.Apple, Items.SmallHeal};
        }
        public bool GainEXP(int expGained)
        {
            EXP += expGained;
            OnEXPGained?.Invoke(expGained);
            bool leveledUp = false;
            while(EXP >= MaxEXP)
            {
                Levelup();
                leveledUp = true;
            }
            return leveledUp;
        }
        private void Levelup()
        {
        Level ++; 
        MaxHP += 20;
        ATK += 5;
        HP = MaxHP;
        EXP -= MaxEXP;
        MaxEXP += 50;
        OnLevelUP?.Invoke();
        }
        public bool Heal(int HealAmount)
        {
            if( HP == MaxHP)
            {
                OnHealed?.Invoke(false, HealAmount);
                return false;
            }
            else
            {
                HP += HealAmount;
                OnHealed?.Invoke(true, HealAmount);
                return true;
            }
        }
        public void FindLoot()
        {
            List<LootEntry> loot = new List<LootEntry>
            {
                new LootEntry(Items.Apple, 40),
                new LootEntry(Items.SmallHeal, 30),
                new LootEntry(Items.IronSword, 10),
                new LootEntry(null, 20)
            };
            int TotalWeight = 0;
            foreach(LootEntry entry in loot)
            {
                TotalWeight += entry.Weight;
            }
            Random rnd = new Random();
            int choice = rnd.Next(1, TotalWeight);
            foreach(LootEntry entry in loot)
            {
                choice -= entry.Weight;
                if(choice <= 0)
                {
                    Item? newItem = entry.item;
                    if(newItem != null)
                    {
                        Inventory.Add(newItem);
                        Console.WriteLine($"Ви знайшли: {newItem.Name} (Сила: {newItem.Value})");
                        Thread.Sleep(1000);  
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Ящик порожній. Спробуйте ще :)");
                        Thread.Sleep(2000);
                        break;
                    }
                }
            }
        }
        public bool UseItem(Item item)
        {
            if(item.Type == ItemType.Heal || item.Type == ItemType.Food)
            {
                if(HP == MaxHP)
                {
                Console.WriteLine("Ви вже повністю здорові!"); 
                Thread.Sleep(1000);
                return false;
                }
                else
                {
                    HP = Math.Min(HP + item.Value, MaxHP);
                    Console.WriteLine($"Ви відновили {item.Value} здоров'я!");
                    Console.WriteLine($"Ваш рівень здоров'я {HP}/{MaxHP}");
                    Inventory.Remove(item);
                    Thread.Sleep(1000);
                    return true;
                }
            }
            else
            {
                Console.WriteLine("Ви не можете це використати зараз");
                Thread.Sleep(1000);
                return false;
            }
        }
    }
}