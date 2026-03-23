using Game;
using Items;
namespace Inventory
{
    class InventoryLogic
    {
        public bool UseItem(Hero hero, Inventory inventory, ItemStack stack)
        {
            if( stack.Item is IUsable usable)
            {
                var result = usable.Use(hero);
                if (result)
                {
                    return inventory.Remove(stack.Item, 1);  
                }
                return false;
            }
            return false;
        }
        public IEnumerable<ItemStack> GetUsableInBattle(Inventory inventory)
        {
            foreach( var stack in inventory.GetAll())
            {
                if(stack.Item is HealItem) yield return stack;
            }
        }
    }
}