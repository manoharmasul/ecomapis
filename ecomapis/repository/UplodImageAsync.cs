using Dapper;
using productcrudforangular.context;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;
using System.ComponentModel.DataAnnotations;

namespace productcrudforangular.repository
{
    public class UplodImageAsync : IUploadImageAsync
    {
        private readonly DapperContext dapperContext;
        public UplodImageAsync(DapperContext dapperContext)
        {
            this.dapperContext = dapperContext;
        }

        public async Task<List<UploadImageModel>> GetAllImages()
        {
            var query = @"select * from tblUploadImage";
            using(var connection=dapperContext.CreateConnection())
            {
                var resul=await connection.QueryAsync<UploadImageModel>(query);
                return resul.ToList();
            }
        }

        public async Task<int> UploadImage(UploadImageModel model)
        {
            var query = @"insert into tblUploadImage(ImageName,ImagePath) values(@ImageName,@ImagePath)";
            using(var connection=dapperContext.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, model);
                return result;
            }
        }

        public async Task<int> UploadProductImage(ProductImageModel model)
        {
            var query = @"Insert into tblProductImages(ImageName,ImagePath,ProductId) values(@ImageName,@ImagePath,@ProductId);";
            using(var connection=dapperContext.CreateConnection())
            {
                var result = await connection.ExecuteAsync(query, model);

                return result;
            }
        }
    }
}
