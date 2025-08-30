using Dapper;
using productcrudforangular.context;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.repository
{
    public class ProductAsyncRepository:IProductAsyncRepository
    {
        private readonly DapperContext context;
        public ProductAsyncRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> AddNewProduct(ProductModel product)
        {
            int res = 0;
            var query = "insert into tblProducts(ProductName,Price,CategoryId) values (@ProductName,@Price,@CategoryId);SELECT CAST(SCOPE_IDENTITY() as int);";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.QuerySingleOrDefaultAsync<int>(query,product);
                res = result;
                return res;
            }
        }
       
        public async Task<int> DeleteProduct(int Id)
        {
            var query = "delete from tblProducts where Id=@Id";
            using(var connection=context.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, new { Id = Id });
                return result;
            }
        }

        public async Task<ProductModel> GetProductById(int Id)
        {
            var query = "select * from tblProducts where Id=@Id";
            using (var connection=context.CreateConnection())
            {
                var result=await connection.QueryFirstOrDefaultAsync<ProductModel>(query, new {Id=Id});
                return result;
            }
        }

        public async Task<List<GetProductModel>> GetProductducts(string? SearchText)
        {
            if(SearchText == null)
            {
                SearchText = "";
            }
            var query = @"select p.Id,p.ProductName,p.Price,p.CategoryId,c.CategoryName from tblProducts p
                        inner join tblCategory c on p.CategoryId=c.Id
                        where ProductName like '%'+@SearchText+'%' or c.CategoryName=@SearchText or @SearchText=''";
            using (var connections=context.CreateConnection())
            {
                var result = await connections.QueryAsync<GetProductModel>(query, new {SearchText=SearchText});
                return result.ToList();
            }
        }

        public async Task<List<ProductListModel>> GetProductlist(string? SearchText)
        {
            if(SearchText==null)
            {
                SearchText = "";
            }
            var query = @"select p.Id,ProductName,Price,CategoryId,
                            ImageName,ImagePath from tblProducts p
                            inner join 
                             tblProductImages i on p.Id=i.ProductId 
							 inner join tblCategory c on p.CategoryId=c.Id where
                              p.ProductName like '%'+@SearchText+'%'  or c.CategoryName like '%'+@SearchText+'%' or @SearchText=''";
            using(var connection=context.CreateConnection())
            { 
               var result=await connection.QueryAsync<ProductListModel>(query, new {SearchText=SearchText});
                return result.ToList();
            }

        }

        public async Task<int> UpdateProduct(ProductModel product)
        {
            var query = "update tblProducts set ProductName=@ProductName,Price=@Price,CategoryId=@CategoryId where Id=@Id";
            using(var conn=context.CreateConnection())
            {
                var result=await conn.ExecuteAsync(query,product);
                return result;
            }
        }
    }
}
