using productcrudforangular.Model;

namespace productcrudforangular.repository.Interface
{
    public interface ICartRepositoryAsync
    {
        Task<int> AddToCart(CartModel cart);
        //Task<int> Update(CartModel cart);
        Task<int> RemoveCart(int Id);
        Task<List<GetCartModel>> GetAllCart(int UserId);
        Task<CartModel> GetById(int Id);
    }
}
