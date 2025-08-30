using Dapper;
using productcrudforangular.context;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.repository
{
    public class ShopAsyncRepository :IShopRepositoryAsync
    {
        private readonly DapperContext conetext;
        public ShopAsyncRepository(DapperContext conetext)
        {
            this.conetext = conetext;
        }

        public async Task<int> AddShop(Shop shop)
        {
            var query = @"Insert into tblShopDetails(ShopeName,StateId,DistId,TalukaId,CityId)
                         values(@ShopeName,@StateId,@DistId,@TalukaId,@CityId)";
            using(var con=conetext.CreateConnection())
            {
                var result=await con.ExecuteAsync(query,shop);
                return result;
            }
        }

        public async Task<int> DeleteShope(int Id)
        {
            var query = @"Delete tblShopDetails where Id=@Id";
            using(var con=conetext.CreateConnection())
            {
                var result = await con.ExecuteAsync(query, new { Id = Id });
                return result;
            }
        }

        public async Task<List<GetShopModel>> GetAllShop(string? SearchText)
        {
            if(SearchText == null)
            {
                SearchText = "";
            }
            var query = @"select sh.Id,sh.ShopeName,s.Id as StateId,s.StateName,
                        d.Id DistId,d.DistrictName,t.Id as TalukaId,t.TalukaName,
                        c.Id as CityId,c.CityName from tblShopDetails sh
                        inner join tblState s on  sh.StateId=s.Id
                        inner join tblDistrict d on sh.DistId=d.Id
                        inner join tblTaluka t on sh.TalukaId=t.Id
                        left join tblCity c on sh.CityId=c.Id
						where s.StateName like '%'+@SearchText+'%'
						or StateName like '%'+@SearchText+'%'
						or DistrictName like '%'+@SearchText+'%'
						or TalukaName like '%'+@SearchText+'%'
						or CityName like '%'+@SearchText+'%'
                        ";
            using(var con=conetext.CreateConnection())
            {
                var result=await con.QueryAsync<GetShopModel>(query, new {SearchText=SearchText});
               return result.ToList();
            }
        }

        public async Task<Shop> GetShopById(int Id)
        {
            var query = @"select * from tblShopDetails where Id=@Id";
            using(var con = conetext.CreateConnection())
            {
                var result=await con.QueryFirstOrDefaultAsync<Shop>(query, new {Id=Id});
                return result;
            }
        }

        public async Task<int> UpdateShop(Shop shop)
        {
            var query = @"update tblShopDetails set ShopeName=@ShopeName,StateId=@StateId,
                   DistId=@DistId,TalukaId=@TalukaId,CityId=@CityId where Id=@Id";
            using(var con = conetext.CreateConnection())
            {
                var result=await con.ExecuteAsync(query, shop);
                return result;
            }
        }
    }
}
