using bbBookstore.Models;

namespace bbBookstore.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmailAddress);

        Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole);
    }
}
