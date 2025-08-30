using System.Xml.Schema;

namespace productcrudforangular.Model
{
   /* public class ProductductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public  decimal Price { get; set; }
        public int CategoryId { get; set; }
        
    }*/
    public class ProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

    }
    public class GetProductModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
    public class ProductImagesList
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public byte[] ImagePath { get; set; }
        public int ProductId { get; set; }

    }

    public class ProductListModel
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string ImageName { get; set; }
        public byte[] ImagePath { get; set; }

    }
}
