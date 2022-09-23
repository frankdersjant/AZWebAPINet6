using FunctionAppNetSix.Models;

namespace FunctionAppNetSix.Services
{
    public interface IShoppingCartService
    {
        IEnumerable<ShoppingCartItem> GetAll();
        ShoppingCartItem getById(int id);
        ShoppingCartItem Add(ShoppingCartItem item);
    }
}
