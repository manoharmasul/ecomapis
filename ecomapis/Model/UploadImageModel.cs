namespace productcrudforangular.Model
{
    public class UploadImageModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public byte[] ImagePath { get; set; }
    }
    public class ProductImageModel
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public byte[] ImagePath { get; set; }
        public int ProductId { get; set; }
    }
    public class ImageUploadDto
    {
        public IFormFile ImageFile { get; set; }
    }

}
