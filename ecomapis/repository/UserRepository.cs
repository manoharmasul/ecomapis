using Dapper;
using productcrudforangular.context;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;
using System.Data;
using static productcrudforangular.Model.User;

namespace productcrudforangular.repository
{
    public class UserRepository:IUserRepository
    {
        private readonly DapperContext context;
        public UserRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> AddNewUser(User user)
        {
            var query = @"insert into tblUser (UserName,EmailId) values(@UserName,@EmailId);SELECT CAST(SCOPE_IDENTITY() as int);";
            using (var connection = context.CreateConnection())
            {
                var result = await connection.QuerySingleOrDefaultAsync<int>(query, user);
                return result;
            }
        }

        public async Task<int> AddNewUserManually(UserModel user)
        {
            var query = @"insert into tblUser(
                            EmpId,UserName,EmailId,PhoneNo,Password,CreatedBy,CreatedDate	
                           ,IsDeleted
                            )
                            values
                            (
                            @EmpId,@UserName,@EmailId,@PhoneNo,@Password,@CreatedBy,@CreatedDate,0
                            )";
            using(var con=context.CreateConnection())
            {
                var result=await con.ExecuteAsync(query,user);
                return result;
            }
        }

        public Task<int> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetAllUsers(string? SearchText)
        {
            if(SearchText == null)
            {
                SearchText = "";
            }
            var query = @"select * from tblUser where UserName 
                        like '%'+@SearchText+'%' or EmailId like '%'+@SearchText+'%'
                        or PhoneNo like '%'+@SearchText+'%'";
            using(var con=context.CreateConnection())
            {
                var result=await con.QueryAsync<UserModel>(query, new {SearchText=SearchText});
                return result.ToList();
            }
        }

        public Task<UserModel> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<LoginData> Login(LogInModel login)
        {
            var query = @"select u.Id,UserName,case when RoleId=0 or RoleId is null then 0
                        else RoleId 
                        end as RoleId
                        from tblUser u
                        left join tblEmployee e on
                        u.EmpId=e.Id  where UserName=@UserName and u.Password=@Password";
            using(var connection = context.CreateConnection())
            {
                var result=await connection.QueryFirstOrDefaultAsync<LoginData>(query, login);
                return result;
            }
        }

        public async Task<int> SendOtp(sendotp sendotp)
        {
            var query = @"insert into tblOtp(Otp,PhoneNo,UserId,CreatedDateTime)values(@Otp,@PhoneNo,@UserId,GETDATE());SELECT CAST(SCOPE_IDENTITY() as int);";
            var procOtp = "Sp_GenerateOtp";
            int result = 0;
            var instanceId = "instance139250";
            var token = "4ty7bnqj17gf2zxx";
            var to = $"whatsapp:+91{sendotp.PhoneNo}";


            using (var client = new HttpClient())
            {
            
                var url = $"https://api.ultramsg.com/{instanceId}/messages/chat";
                Random random = new Random();
                int otp = random.Next(1000, 10000);
                var message = $"{otp} This is the one time otp for Ifarm application registration.";
                var content = new FormUrlEncodedContent(new[]
                  {
                new KeyValuePair<string, string>("token", token),
                new KeyValuePair<string, string>("to", to),
                new KeyValuePair<string, string>("body", message)
                });
                sendotp.Otp=otp.ToString();
                using (var connection = context.CreateConnection())
                {
                    
                    result = await connection.QuerySingleAsync<int> (query,sendotp);
                }
                if (result > 0)
                {
                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    return result;
                }
                return result;
            }
            }

        public async Task<int> SetPassword(SetPassword password)
        {
            var query = @"update tblUser set Password=@Password where Id=@UserId";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query,password);
                return result;
            }
        }

        public async Task<int> UpdateNewUser(UserModel user)
        {
            var query = @"update tblUser set	
                            EmpId=@EmpId	
                            ,UserName=@UserName	
                            ,EmailId=@EmailId
                            ,PhoneNo=@PhoneNo	
                            ,Password=@Password		
                            ,ModifiedBy=@ModifiedBy	
                            ,ModifiedDate=@ModifiedDate	
                            where Id=@Id";
            using(var conn=context.CreateConnection())
            {
                var result=await conn.ExecuteAsync(query,user);
                return result;
            }
        }

        public Task<int> UpdateUser(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<Optvalidationmsg> VerifyOtp(sendotp sendotp)
        {
            var query = @"SELECT 
                       case 
                       when DATEDIFF(SECOND,(select top 1 CreatedDateTime from tblOtp where UserId=@UserId and Otp=@Otp order by id desc),GETDATE())>50
                       then 'not valid'
                       when DATEDIFF(SECOND,(select top 1 CreatedDateTime from tblOtp where UserId=@UserId and Otp=@Otp order by id desc),GETDATE())<=50
                       then 'verified'
                       else 'otp is incorrect'
                       end as validationmsg ";
            var queryphone = @"update tblUser set PhoneNo=@PhoneNo where Id=@UserId";
            using (var connection=context.CreateConnection())
            {
                var result=await connection.QueryFirstOrDefaultAsync<Optvalidationmsg>(query,sendotp);
                var result1=await connection.ExecuteAsync(queryphone,sendotp);

                return result;
            }
        }
    }
}
