namespace GameAPI.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; private set; }

        private Item() { }

        public Item(string name)
        {
            Name = name;
        }
    }
}
