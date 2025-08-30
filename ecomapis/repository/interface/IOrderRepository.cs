using productcrudforangular.Model;

namespace productcrudforangular.repository.Interface
{
    public interface IOrderRepository
    {
        Task<int> AddProduct(OrderModel order);
        Task<int> UpdateProduct(OrderModel order);
        Task<int> UpdateShop();
        Task<int> DeleteProduct(int Id);
        Task<OrderModel> GetProductById(int Id);
        Task<List<OrderModel>> GetAllOrders();
        Task<List<UserOderModel>> GetAllOrdersByUserId(int UserId);
        Task<List<OrderlistModel>> GetAllOrdersShops(int UserId);
        Task<List<OrderUpdatesModel>> GetOrderUpdates(int UserId);
        Task<int> AssingOrder(AssingOrderModel assingOrder);
        Task<int> UpdateAssingOrder(AssingOrderModel assingOrder);
        Task<int> UpdateOrderStatus(UpdateOrderModel update);
        Task<int> SendOrderOtp(sendOrderotpModal OrdId);
    }
}
