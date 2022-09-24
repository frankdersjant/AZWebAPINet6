namespace FunctionAppNetSix.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ShoppingCartItem(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
