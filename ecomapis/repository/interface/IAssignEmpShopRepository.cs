using productcrudforangular.Controllers;
using productcrudforangular.Model;

namespace productcrudforangular.repository.Interface
{
    public interface IAssignEmpShopRepository
    {
        Task<int> AssignEmpShopAsync(AssignShopEmpModel model);
        Task<int> UpdateEmpShopAsync(AssignShopEmpModel model);
        Task<List<AssignShopEmpModel>> GetAssignEmpShop();
        Task<AssignShopEmpModel> GetAssignEmpShopById(int Id);
    }
}
