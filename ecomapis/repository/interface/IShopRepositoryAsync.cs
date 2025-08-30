using productcrudforangular.Model;

namespace productcrudforangular.repository.Interface
{
    public interface IShopRepositoryAsync
    {
        Task<int> AddShop(Shop shop);
        Task<int> UpdateShop(Shop shop);
        Task<Shop> GetShopById(int Id);
        Task<List<GetShopModel>> GetAllShop(string? SearchText);
        Task<int> DeleteShope(int Id);
    }
}
