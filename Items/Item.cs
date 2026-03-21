namespace Items
{
    public abstract class Item
    {
        public string? Name {get; protected set;}
        public string? ID {get; protected set;}
        public int MaxStackSize {get; init;}
        public bool IsQuestItem {get; init;} = false;
    }
}