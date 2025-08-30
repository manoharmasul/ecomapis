using Dapper;
using productcrudforangular.context;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.repository
{
    public class EmployeeAsyncRepository:IEmployeeAsyncRepository
    {
        private readonly DapperContext context;
        public EmployeeAsyncRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> AddEmployee(EmployeeModel employee)
        {
            var query = @"INSERT INTO dbo.tblEmployee
               (EmpName, EmailId, EmpPhoneNo, RoleId,
               CreatedBy, CreatedDate, IsDeleted)
                VALUES(@EmpName, @EmailId, @EmpPhoneNo, @RoleId,
            @CreatedBy, GetDate(), 0);";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query,employee);
                return result;
            }
        }

        public async Task<int> DeleteEmployee(int Id)
        {
            var query = @"UPDATE dbo.tblEmployee
                            SET    IsDeleted    = 1,
                                   ModifiedBy   = 1,
                                   ModifiedDate = GETUTCDATE()
                            WHERE  Id = @Id  AND IsDeleted = 0";
            using(var connection = context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query, new {Id=Id});
                return result;
            }
        }

        public async Task<List<EmployeeGetModel>> GetAllEmployee(string? SearchText)
        {
            if(SearchText == null)
            {
                SearchText = "";
            }
            var query = @"select e.Id,EmpName,EmailId	
                            ,EmpPhoneNo,RoleId,e.CreatedBy,
                            e.CreatedDate,e.ModifiedBy,
                            e.ModifiedDate,e.IsDeleted,et.emprole,
                            sd.ShopeName+' '+c.TalukaName as ShopeName,sd.Id as ShopId,
							aea.Id as AssignId
                            from tblEmployee e
                            inner join tblEmployeType et
                            on e.RoleId= et.id
                            left join tblShopEmpAssign aea
                            on aea.EmpId=e.Id
                            left join tblShopDetails sd
                            on aea.ShopId=sd.Id
                            left join tblTaluka c on sd.TalukaId=c.Id
                            where 
                            (EmpName like '%'+@SearchText+'%' 
                            or EmpPhoneNo like '%'+@SearchText+'%' 
                            or EmpRole like '%'+@SearchText+'%' or 
                            EmailId like '%'+@SearchText+'%')
                            or @SearchText=''";
            using(var connection= context.CreateConnection())
            {
                var result=await connection.QueryAsync<EmployeeGetModel>(query, new {SearchText=SearchText});
                return result.ToList();
            }
        }

        public async Task<EmployeeModel> GetEmployeeById(int Id)
        {
            var query = @"SELECT *
                        FROM   dbo.tblEmployee
                        WHERE  Id = @Id  AND IsDeleted = 0 order by Id";
            using(var connection = context.CreateConnection())
            {
                var result=await connection.QueryFirstOrDefaultAsync<EmployeeModel>(query, new {Id=Id});
                return result;
            }
        }

        public async Task<int> UpdateEmployee(EmployeeModel employee)
        {
            var query = @"UPDATE dbo.tblEmployee
                       SET    EmpName       = @EmpName,
                              EmailId       = @EmailId,
                              EmpPhoneNo    = @EmpPhoneNo,
                              RoleId        = @RoleId,
                              ModifiedBy    = @ModifiedBy,
                              ModifiedDate  = GETUTCDATE()
                              WHERE  Id = @Id   AND IsDeleted = 0";
            using(var connections=context.CreateConnection())
            {
                var result=await connections.ExecuteAsync(query,employee);
                return result;
            }
        }
    }
}
