using Dapper;
using productcrudforangular.context;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.repository
{
    public class CommonDropdownRepository:ICommondropdownasync
    {
        private readonly DapperContext context;
        public CommonDropdownRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<List<CategoryModel>> GetCategory()
        {
            var query = @"select * from tblCategory";
            using(var con=context.CreateConnection())
            {
                var result=await con.QueryAsync<CategoryModel>(query);
                return result.ToList();
            }
        }

        public async Task<List<CityModel>> GetCity(int TalukaId)
        {
            var query = @"select * from tblCity where TalukaId=@TalukaId";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.QueryAsync<CityModel>(query, new { TalukaId=TalukaId});
                return result.ToList();
            }
        }

        public async Task<List<DeliveryDropModel>> GetDeliveryBoyes(int UserId)
        {
            var query = @"select u.Id,u.UserName as DeliveryBoyName from tblShopEmpAssign sea
                    inner join tblEmployee e on sea.EmpId=e.Id
                    inner join tblEmployeType et on e.RoleId=et.Id
                    inner join tblUser u on u.EmpId=e.Id
                    inner join  tblShopDetails sd 
                    on sd.Id=sea.ShopId
                    where et.EmpRole='Delivery Boy' 
                    and sea.ShopId=(select ShopId from tblShopEmpAssign 
                    where EmpId=(select EmpId from tblUser
                    where Id=@UserId))";
            using(var conn=context.CreateConnection())
            {
                var result=await conn.QueryAsync<DeliveryDropModel>(query, new { UserId=UserId});
                return result.ToList();
            }
        }

        public async Task<List<DistrictModel>> GetDistrict(int StateId)
        {
            var query = @"select * from tblDistrict where StateId=@StateId";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.QueryAsync<DistrictModel>(query, new {StateId=StateId});
                return result.ToList();
            }
        }

        public async Task<List<EmployeeRoleModel>> GetEmployeeRole()
        {
            var query = @"select * from tblEmployeType";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.QueryAsync<EmployeeRoleModel>(query);
                return result.ToList();
            }
        }

        public async Task<List<OrderstutsDropModel>> GetOrderstutsDrop()
        {
            var query = @"select * from tblOrderStatus";
            using(var con=context.CreateConnection())
            {
                var result=await con.QueryAsync<OrderstutsDropModel>(query);
                return result.ToList();
            }
        }

        public async Task<List<ShopDropModel>> GetShopDrop()
        {
            var query = @"select s.Id,ShopeName+' '+c.TalukaName as ShopeName from tblShopDetails s
                        inner join tblTaluka c
                        on s.TalukaId=c.Id";
            using(var con=context.CreateConnection())
            {
                var result= await con.QueryAsync<ShopDropModel>(query);
                return result.ToList();
            }
        }

        public async Task<List<StateModel>> GetState()
        {
            var query = @"select * from tblState";
            using(var conn=context.CreateConnection())
            {
                 var result=await conn.QueryAsync<StateModel>(query);
                return result.ToList();
            }
        }

        public async Task<List<TalukaModel>> GetTaluka(int DistId)
        {
            var query = @"select * from tblTaluka where DistId=@DistId";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.QueryAsync<TalukaModel>(query, new {DistId=DistId});
                return result.ToList(); 
            }
        }
    }
}
