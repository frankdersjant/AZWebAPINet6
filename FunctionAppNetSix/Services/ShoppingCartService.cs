using FunctionAppNetSix.Models;

namespace FunctionAppNetSix.Services
{

    public class ShoppingCartService : IShoppingCartService
    {
        private List<ShoppingCartItem> lstshoppingCartItems = new List<ShoppingCartItem>();

        public ShoppingCartService()
        {
            Seed();
        }

        public ShoppingCartItem Add(ShoppingCartItem item)
        {
            lstshoppingCartItems.Add(item);
            return item;
        }

        public IEnumerable<ShoppingCartItem> GetAll()
        {
            return Seed();
        }

        public ShoppingCartItem getById(int id)
        {
            return lstshoppingCartItems.Find(i => i.Id == id);
        }

        private List<ShoppingCartItem> Seed()
        {
            ShoppingCartItem cartItem1 = new ShoppingCartItem(1, "Cheese", "Hey its cheese");
            ShoppingCartItem cartItem2 = new ShoppingCartItem(2, "Wine", "Hik");

            lstshoppingCartItems.Add(cartItem1);
            lstshoppingCartItems.Add(cartItem2);

            return lstshoppingCartItems;
        }
    }
}
