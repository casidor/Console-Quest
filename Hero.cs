using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.ServerSentEvents;
using System.Threading;
namespace Game
{
    public class Hero
    {
        public List<Item> Inventory;
        public string Name;
        public int Level;
        public int MaxHP;
        public int HP;
        public int ATK;
        public int EXP;
        public int MaxEXP;
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
        public void ShowStats()
        {
        Console.WriteLine("----------------------");
        Console.WriteLine($"Ім'я героя: {Name}");
        Console.WriteLine($"Рівень героя: {Level}");
        Console.WriteLine($"Досвід героя: {EXP}/{MaxEXP}");
        Console.WriteLine($"Здоров'я героя:{HP}/{MaxHP}");
        Console.WriteLine($"Сила героя: {ATK}");
        }
        public void GainEXP(int expGained)
        {
            EXP += expGained;
            Console.WriteLine("-----------------");
            Console.WriteLine($"Ви отримали {expGained} досвіду!");
            if(EXP >= MaxEXP)
            {
                Levelup();
            }
        }
        public void Levelup()
        {
        Level ++; 
        MaxHP += 20;
        ATK += 5;
        HP = MaxHP;
        EXP -= MaxEXP;
        MaxEXP += 50;
        Console.WriteLine("-----------------");
        Console.WriteLine($"Рівень підвищено! Ваші характеристики тепер:");
        Console.WriteLine($"Ваш рівень здоров'я {HP}/{MaxHP}");
        Console.WriteLine($"Сила героя: {ATK}");
        }
        public void FindLoot()
        {
        Item newItem = Items.IronSword;
        Inventory.Add(newItem);
        Console.WriteLine($"Ви знайшли: {newItem.Name} (Сила: {newItem.Value})");
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