using productcrudforangular.Model;

namespace productcrudforangular.repository.Interface
{
    public interface IProductAsyncRepository
    {
        Task<int> AddNewProduct(ProductModel product);
        Task<int> UpdateProduct(ProductModel product);
        Task<List<GetProductModel>> GetProductducts(string? SearchText);
        Task<List<ProductListModel>> GetProductlist(string? SearchText);
        Task<ProductModel> GetProductById(int Id);
        Task<int> DeleteProduct(int Id);
    }
}
