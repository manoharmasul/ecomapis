using Dapper;
using productcrudforangular.context;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.repository
{
    public class CartRepositoryAsync :ICartRepositoryAsync
    {
        private readonly DapperContext context;
        public  CartRepositoryAsync(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> AddToCart(CartModel cart)
        {
            var query = @"insert into tblCart(	
                    ProductId,UserId,CreatedBy,CreatedDate	
                    ,ModifiedBy,ModifiedDate,IsDeleted
                    )
                    values(
                    @ProductId,@UserId,@CreatedBy	
                    ,@CreatedDate,@ModifiedBy,@ModifiedDate,0
                    )";
            using(var con=context.CreateConnection())
            {
                var result=await con.ExecuteAsync(query,cart);
                return result;
            }

        }

        public async Task<List<GetCartModel>> GetAllCart(int UserId)
        {
            var query = @"select c.Id,p.Id as ProductId,p.ProductName,p.Price,
                    pim.ImagePath,pim.ImageName,c.UserId from tblCart c
                    inner join tblProducts p
                    on c.ProductId=p.Id
                    inner join tblProductImages pim
                    on p.Id=pim.ProductId
                    where IsDeleted=0 and c.UserId=@UserId or @UserId=0";
            using(var con=context.CreateConnection())
            {
                var result=await con.QueryAsync<GetCartModel>(query, new {UserId=UserId});
                return result.ToList();
            }
        }

        public async Task<CartModel> GetById(int Id)
        {
            var query = @"Select * from tblCart where Id=@Id";
            using(var con=context.CreateConnection())
            {
                var result=await con.QueryFirstOrDefaultAsync<CartModel>(query, new {Id=Id});
                return result;
            }
        }

        public async Task<int> RemoveCart(int Id)
        {
            var query = @"Update tblCart set IsDeleted=1 where Id=@Id";
            using(var con=context.CreateConnection())
            {
                var result=await con.ExecuteAsync(query, new {Id});
                return result;
            }
        }
    }
}
