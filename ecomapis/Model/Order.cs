using DocumentFormat.OpenXml.Drawing.Charts;

namespace productcrudforangular.Model
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string DeliveryAddress { get; set; }
        public string OrderLocation { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public int Qty { get; set; }

        public int CreatedBy { get; set; }
        public int OrderStatus { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class OrderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string DeliveryAddress { get; set; }
        public string OrderLocation { get; set; }
        public string EmailId { get; set; }
        public string PhoneNo { get; set; }
        public int Qty { get; set; }
        public decimal TotalAmmount { get; set; }
        public int CreatedBy { get; set; }
        public int OrderStatus { get; set; }
        public int StateId { get; set; }
        public int DistId { get; set; }
        public int TalukaId { get; set; }
        public int CityId { get; set; }
        public DateTime CreatedDate { get; set; }

        public bool IsDeleted { get; set; }
    }
    public class UserOderModel
    {
        public int Id { get; set; }
        public string DeliveryAddress { get; set; }
        public string ProductName { get; set; }
        public string PhoneNo { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatus { get; set; }
        public int Qty { get; set; }
        public string ImageName { get; set; }
        public byte[] ImagePath { get; set; }
        public decimal TotalAmmount { get; set; }
    }
    public class OrderlistModel
    {
        public int Id { get; set; }
        public int ShopId { get; set; }
        public string ShopeName { get; set; }
        public string ProductName { get; set; }
        public int DeliveryBoyId { get; set; }
        public string DeliveryBoy { get; set; }
    }
    public class AssingOrderModel
    {
        public int Id { get; set; }
        public int OrdId { get; set; }
        public int UserId { get; set; }
        public DateTime AssignedDate { get; set; }
        public int AssignedBy { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class OrderUpdatesModel
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public string DeliveryAddress { get; set; }
        public string PhoneNo { get; set; }
        public int Qty { get; set; }
        public int OrderStatusId { get; set; }
        public string OrderStatus { get; set; }
    }
    public class UpdateOrderModel
    {
        public int Id { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int OrderStatus { get; set; }
        public string DeliveryOtp { get; set; }
    }
    public class sendOrderotpModal
    {
       // public string? PhoneNo { get; set; }
        public int OrdId { get; set; }
       
    }
}
