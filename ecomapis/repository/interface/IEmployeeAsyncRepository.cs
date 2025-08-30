using productcrudforangular.Model;

namespace productcrudforangular.repository.Interface
{
    public interface IEmployeeAsyncRepository
  {
        Task<int> AddEmployee(EmployeeModel employee);
        Task <int> UpdateEmployee(EmployeeModel employee);
        Task<int> DeleteEmployee(int Id);
        Task<EmployeeModel> GetEmployeeById(int Id);
        Task<List<EmployeeGetModel>> GetAllEmployee(string? SearchText);

  }
}
