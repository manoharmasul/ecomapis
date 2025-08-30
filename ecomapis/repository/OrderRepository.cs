using Dapper;
using productcrudforangular.context;
using productcrudforangular.Model;
using productcrudforangular.repository.Interface;

namespace productcrudforangular.repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly DapperContext context;
        public OrderRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> AddProduct(OrderModel order)
        {
            var query = @"INSERT INTO tblOrder (
                                            UserId,
                                            ProductId,
                                            EmailId,
                                            PhoneNo,
                                            DeliveryAddress,
                                            OrderLocation,
                                            Qty,
                                            TotalAmmount,
                                            StateId,
                                            DistId,
                                            TalukaId,
                                            CityId,
                                            CreatedBy,
                                            OrderStatus,
                                            CreatedDate,
                                            IsDeleted
                                        )
                                        VALUES (
                                            @UserId,
                                            @ProductId,
                                            @EmailId,
                                            @PhoneNo,
                                            @DeliveryAddress,
                                            @OrderLocation,
                                            @Qty,
                                            @TotalAmmount,
                                            @StateId,
                                            @DistId,
                                            @TalukaId,
                                            @CityId,
                                            @CreatedBy,
                                            @OrderStatus,
                                            @CreatedDate,
                                            @IsDeleted             
                                        );";
            using(var connection=context.CreateConnection())
            {
                var result=await connection.ExecuteAsync(query,order);
                return result;
            }
        }

        public async Task<int> AssingOrder(AssingOrderModel assingOrder)
        {
            var query = @"insert into tblAssignOrder(
                    OrdId,UserId,AssignedDate,AssignedBy,CreatedBy,
                    CreatedDate,ModifiedBy,ModifiedDate,IsDeleted ) 
                    values
                    (
                     @OrdId,@UserId,@AssignedDate,@AssignedBy,@CreatedBy	 
                    ,@CreatedDate,@ModifiedBy,@ModifiedDate,0 
                    )";
           var queryupdatestatus = @"update tblOrder set OrderStatus=1 where Id=@OrdId";
            using (var con=context.CreateConnection())
            {
                var result=await con.ExecuteAsync(query,assingOrder);
                var result1 = await con.ExecuteAsync(queryupdatestatus, new { OrdId = assingOrder.OrdId });
                return result;
            }
        }

        public Task<int> DeleteProduct(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<OrderModel>> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserOderModel>> GetAllOrdersByUserId(int UserId)
        {
            var query = @"select o.Id,DeliveryAddress,p.ProductName,
						case when os.Id is null then 'Pending'
						else
						os.OrderStatus
						end as OrderStatus,
						case when os.Id is null then 0 else
						os.Id end as OrderStatusId,
                        o.PhoneNo,o.Qty,i.ImageName,ImagePath,o.TotalAmmount from tblOrder o
                        inner join 
                        tblProducts p
                         on o.ProductId=p.Id
                         left join tblShopDetails s
                         on o.ShopId=s.Id
						 inner join tblProductImages i
						 on i.ProductId=p.Id
						 left join tblOrderStatus os on os.Id=o.OrderStatus
                         where o.UserId=@UserId";
            using(var con=context.CreateConnection())
            {
                var result=await con.QueryAsync<UserOderModel>(query, new {UserId=UserId});
                return result.ToList();
            }
        }

        public async Task<List<OrderlistModel>> GetAllOrdersShops(int UserId)
        {
            var query = @" declare @ShopId int
                            Declare @RoleId int=0
                            select @ShopId=ShopId,@RoleId=e.RoleId from tblUser u
                            inner join 
                             tblEmployee
                            e on u.EmpId=e.Id
                            inner join
                             tblShopEmpAssign s on e.Id=s.EmpId
                             where u.Id=@UserId
							 if(@RoleId=1)
							  begin
							  set @ShopId=0
							 end
                            select o.Id,p.ProductName,s.Id as ShopId,
                        s.ShopeName+' '+c.TalukaName as ShopeName,ui.Id as DeliveryBoyId,  
						ui.UserName as DeliveryBoy
						from tblOrder o
                        inner join tblShopDetails s
                        on o.ShopId=s.Id
                        inner join tblProducts p
                        on o.ProductId=p.Id
                        inner join tblTaluka c
                        on c.Id=s.TalukaId
						left join tblAssignOrder ao
						on ao.OrdId=o.Id
						left join tblUser ui
						on ui.Id=ao.UserId
                        where ShopId=@ShopId or @ShopId=0";
            using(var con = context.CreateConnection())
            {
                var result=await con.QueryAsync<OrderlistModel>(query,new {UserId=UserId});
                return result.ToList();
            }
        }

        public async Task<List<OrderUpdatesModel>> GetOrderUpdates(int UserId)
        {
            var query = @"select o.Id as OrderId,ao.UserId,
                            DeliveryAddress,o.PhoneNo,Qty,o.OrderStatus as OrderStatusId,
                            case when o.OrderStatus=0 then 'Pending'
                            else os.OrderStatus
                            end as OrderStatus
                            from tblAssignOrder ao
                            inner join tblOrder o on ao.OrdId=o.Id
                            inner join tblUser u on u.Id=ao.UserId
                            left  join tblOrderStatus os on o.OrderStatus=os.Id
                            where ao.UserId=@UserId";
            using(var con=context.CreateConnection())
            {
                var result=await con.QueryAsync<OrderUpdatesModel>(query, new {UserId=UserId});

                return result.ToList();
            }
        }

        public Task<OrderModel> GetProductById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> SendOrderOtp(sendOrderotpModal OrdId)
        {
            var query = @"insert into tblOrderOtp(OrdId,Otp,CreatedDateTime)
                values(@OrdId,@otp,GetDate())";
            var procOtp = "Sp_GenerateOtp";
            int result = 0;
            var instanceId = "instance139250";
            ///"htps://api.ultramsg.com/instance139250/"
            var token = "4ty7bnqj17gf2zxx";
            
           


            using (var client = new HttpClient())
            {
                string number = "";
                var url = $"https://api.ultramsg.com/{instanceId}/messages/chat";

                Random random = new Random();
                int otp = random.Next(1000, 10000);
                var message = $"{otp} This is the one time otp for your order delivery.";
                
               // sendotp.Otp = otp.ToString();
                using (var connection = context.CreateConnection())
                {
                    result = await connection.ExecuteAsync(query, new { OrdId = OrdId.OrdId, otp = otp });
                     number=await connection.QueryFirstOrDefaultAsync<string>("select PhoneNo from tblOrder where Id=@Id", new {Id=OrdId.OrdId});

                    //result = await connection.QuerySingleAsync<int>(query, sendotp);
                }
                 var to = $"whatsapp:+91{number}";
                var content = new FormUrlEncodedContent(new[]
                  {
                new KeyValuePair<string, string>("token", token),
                new KeyValuePair<string, string>("to", to),
                new KeyValuePair<string, string>("body", message)
                });
                if (result > 0)
                {
                    var response = await client.PostAsync(url, content);
                    var responseString = await response.Content.ReadAsStringAsync();
                    return otp;
                }
                return result;
            }
        }

        public async Task<int> UpdateAssingOrder(AssingOrderModel assingOrder)
        {
            var query = @"update tblAssignOrder set UserId=@UserId,
                        AssignedBy=@AssignedBy,
                        ModifiedBy=@ModifiedBy,
                        ModifiedDate=@ModifiedDate 
                        where OrdId=@OrdId";
            using(var con=context.CreateConnection())
            {
                var result = await con.ExecuteAsync(query, assingOrder);
                return result;
            }
        }

        public async Task<int> UpdateOrderStatus(UpdateOrderModel update)
        {
            var query = @"update tblOrder set OrderStatus=@OrderStatus,DeliveryOtp=@DeliveryOtp,
                          ModifiedBy=@ModifiedBy,ModifiedDate=@ModifiedDate where Id=@Id";
            using(var con=context.CreateConnection())
            {
                if (update.OrderStatus ==3)
                {


                    var ores = await con.QueryFirstOrDefaultAsync<int>(@"SELECT top 1
                                            CASE 
                                                WHEN DATEDIFF(SECOND, CreatedDateTime, GETDATE()) < 60 THEN 1 
                                        		When DATEDIFF(SECOND, CreatedDateTime, GETDATE()) > 60 THEN 0
                                        		
                                                ELSE 0
                                            END AS diff
                                        FROM tblOrderOtp
                                        WHERE ordId = @ordId and Otp=@Otp order by Id desc;", new { ordId = update.Id, Otp=update.DeliveryOtp });
                    if (ores == null || ores == 0)
                    {
                        return 0;
                    }
                }
                var result=await con.ExecuteAsync(query, update);
                return result;
            }
        }

        public Task<int> UpdateProduct(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public async Task<int> UpdateShop()
        {
            var query = @"UPDATE t1
                        SET t1.ShopId = t2.Id
                        FROM tblOrder t1
                        INNER JOIN tblShopDetails t2 ON t1.StateId = t2.StateId
                        and t1.DistId=t2.DistId and  t1.TalukaId=t2.TalukaId
                        --and t1.CityId=t2.CityId";
            using(var con=context.CreateConnection())
            {
                var result=await con.ExecuteAsync(query);
                return result;
            }
        }
    }
}
