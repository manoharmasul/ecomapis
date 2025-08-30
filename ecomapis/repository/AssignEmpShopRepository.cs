using Dapper;
using productcrudforangular.context;
using productcrudforangular.Controllers;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.repository
{
    public class AssignEmpShopRepository:IAssignEmpShopRepository
    {
        private readonly DapperContext context;
        public AssignEmpShopRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<List<AssignShopEmpModel>> GetAssignEmpShop()
        {
            var query = @"select * from tblShopEmpAssign where IsDeleted=0";
            using(var con=context.CreateConnection())
            {
                var result=await con.QueryAsync<AssignShopEmpModel>(query);
                return result.ToList();
            }
        }

        public async Task<int> AssignEmpShopAsync(AssignShopEmpModel model)
        {
            var qeury = @"insert into tblShopEmpAssign
                        (ShopId,EmpId,CreatedBy,CreatedDate,
                        IsDeleted)
                        values
                        (@ShopId,@EmpId,@CreatedBy,
                        @CreatedDate,0)";
            using(var con=context.CreateConnection())
            {
                var result = await con.ExecuteAsync(qeury, model);
                return result;
            }
        }

        public async Task<AssignShopEmpModel> GetAssignEmpShopById(int Id)
        {
            var qeury = @"select * from tblShopEmpAssign where Id=@Id";
            using(var con=context.CreateConnection())
            {
                var result=await con.QueryFirstOrDefaultAsync<AssignShopEmpModel>(qeury, new {Id=Id});
                return result;
            }
        }

        public async Task<int> UpdateEmpShopAsync(AssignShopEmpModel model)
        {
            var query= @"Update tblShopEmpAssign set 
                        ShopId=@ShopId,EmpId=@EmpId,
                        CreatedBy=@CreatedBy,CreatedDate=@CreatedDate,
                        ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where Id=@Id";
            using(var con=context.CreateConnection())
            {
                var result=await con.ExecuteAsync(query, model);
                return result;
            }
        }
    }
}
