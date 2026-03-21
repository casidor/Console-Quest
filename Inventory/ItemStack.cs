using Items;
namespace Inventory
{
    class ItemStack
    {
        public Item Item { get; protected set; }
        private int _count;
        public int Count
        {
            get => _count;
            private set => _count = Math.Clamp(value, 0, Item.MaxStackSize);
        }
        public bool IsFull => Count >= Item.MaxStackSize;
        public ItemStack(Item item, int amount = 1)
        {
            Item = item;
            Count = amount;
        }
        public int Add(int amount)
        {
            int available =  Item.MaxStackSize - Count;
            if(amount <= available)
            {
                Count += amount;
                return 0;
            }
            else
            {
                Count += available;
                int rest = amount - available;
                return rest;
            }
        }
        public int Remove(int amount)
        {
            if(Count >= amount)
            {
                Count -= amount;
                return amount;
            }
            else
            {
                int removed = Count;
                Count = 0;
                return removed;
            }
        }
    }
}