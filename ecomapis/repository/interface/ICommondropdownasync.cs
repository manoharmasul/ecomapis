using productcrudforangular.Model;

namespace productcrudforangular.repository.Interface
{
    public interface ICommondropdownasync
    {
        Task<List<EmployeeRoleModel>> GetEmployeeRole();
        Task<List<StateModel>> GetState();
        Task<List<DistrictModel>> GetDistrict(int StateId);
        Task<List<TalukaModel>> GetTaluka(int DistId);
        Task<List<CityModel>> GetCity(int TalukaId);
        Task<List<CategoryModel>> GetCategory();
        Task<List<ShopDropModel>> GetShopDrop();
        Task<List<DeliveryDropModel>> GetDeliveryBoyes(int UserId);
        Task<List<OrderstutsDropModel>> GetOrderstutsDrop();
    }
}
