using productcrudforangular.Model;
using static productcrudforangular.Model.User;

namespace productcrudforangular.repository.Interface
{
    public interface IUserRepository
    {
        Task<int> AddNewUser(User user);
        Task<int> AddNewUserManually(UserModel user);
        Task<int> UpdateUser(UserModel user);
        Task<int> UpdateNewUser(UserModel user);
        Task<int> DeleteUser(int id);
        Task<UserModel> GetUserById(int id);
        Task<int> SendOtp(sendotp sendotp);
        Task<Optvalidationmsg> VerifyOtp(sendotp sendotp);
        Task<LoginData> Login(LogInModel login);
        Task<List<UserModel>> GetAllUsers(string? SearchText);
        Task<int> SetPassword(SetPassword password);
    }
}
