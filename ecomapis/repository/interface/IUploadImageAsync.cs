using productcrudforangular.Model;

namespace productcrudforangular.repository.Interface
{
    public interface IUploadImageAsync
    {
        Task<int> UploadImage(UploadImageModel model);
        Task<int> UploadProductImage(ProductImageModel model);
        Task<List<UploadImageModel>> GetAllImages();
    }
}
