using Items;
namespace Inventory
{
    class Inventory
    {
        public enum SortType { ByType, ByName, ByCount }
        ItemStack?[] _slots;
        public int MaxSlots;
        public Inventory(int maxSlots)
        {
            MaxSlots = maxSlots;
            _slots = new ItemStack?[maxSlots];
        }
        public bool Add(Item item, int amount = 1)
        {
            foreach (ItemStack? slot in _slots)
            {
                if (slot == null) continue;
                if (slot.Item.ID == item.ID && !slot.IsFull)
                {
                    int rest = slot.Add(amount);
                    if (rest == 0)
                    {
                        return true;
                    }
                    else
                    {
                        amount = rest;
                    }
                }
            }
            while (amount > 0)
            {
                bool found = false;
                for (int i = 0; i < _slots.Length; i++)
                {
                    if (_slots[i] == null)
                    {
                        _slots[i] = new ItemStack(item, 1);
                        amount = _slots[i]!.Add(amount - 1);
                        found = true;
                        break;
                    }
                }
                if (!found) return false;
            }
            return true;
        }
        public bool Remove(Item item, int amount = 1)
        {
            for (int i = 0; i < _slots.Length; i++)
            {
                ItemStack? slot = _slots[i];
                if (slot == null) continue;
                if (slot.Item.ID == item.ID)
                {
                    if (item.IsQuestItem) return false;
                    else
                    {
                        slot.Remove(amount);
                        if (slot.Count == 0) _slots[i] = null;
                        return true;
                    }
                }
            }
            return false;
        }
        public IEnumerable<ItemStack> GetAll()
        {
            foreach (ItemStack? slot in _slots)
            {
                if (slot != null) yield return slot;
            }
        }
        public bool HasFreeSlot()
        {
            foreach (ItemStack? slot in _slots)
            {
                if (slot == null)
                {
                    return true;
                }
            }
            return false;
        }
        public void ExpandSlots(int amount)
        {
            MaxSlots += amount;
            Array.Resize(ref _slots, _slots.Length + amount);
        }
        private int GetTypePriority(ItemStack itemStack)
        {
            if(itemStack.Item is WeaponItem) return 0;
            if(itemStack.Item is HealItem) return 1;
            //if(itemStack.Item is FoodItem) return 2;
            return 3;
        }
        public void Sort(SortType sortType)
        {
            switch (sortType)//TODO: Add other sort types
            {
                case SortType.ByType:
                    List<ItemStack> sorted = new List<ItemStack>(GetAll());
                    sorted.Sort((a, b) => GetTypePriority(a) - GetTypePriority(b));
                    Array.Clear(_slots, 0, _slots.Length);
                    for (int i = 0; i < sorted.Count; i++)
                    {
                        _slots[i] = sorted[i];
                    }
                    break;
            }
        }
    }
}