namespace productcrudforangular.Model
{
    public class CommonDropdown
    {
    }
    public class EmployeeRoleModel
    {
        public int Id { get; set; }
        public string EmpRole { get; set; }
    }
    public class StateModel
    {
        public int Id { get; set; }
        public string StateName { get; set; }
    }
    public class DistrictModel
    {
        public int Id { get; set; }
        public string DistrictName { get; set;}
    }
    public class TalukaModel
    {
        public int Id { get; set; }
        public string TalukaName { get; set; }
    }
    public class CityModel
    {
        public int Id { get; set; }
        public string CityName { get; set; }
    }
    public class CategoryModel
    {
        public int Id { get; set; } 
        public string CategoryName { get; set; } 
    }
    public class ShopDropModel
    {
        public int Id { get; set; }
        public string ShopeName { get; set; }
    }
    public class DeliveryDropModel
    {
        public int Id { get; set; }
        public string DeliveryBoyName { get;}
    }
    public class OrderstutsDropModel
    {
        public int Id { get; set; }
        public string OrderStatus { get; set; }
    }
}
