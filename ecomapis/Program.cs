using productcrudforangular.context;
using productcrudforangular.repository.Interface;
using productcrudforangular.repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});
// Add services to the container.
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddHostedService<ShopUpdateService>();

builder.Services.AddSingleton<IProductAsyncRepository, ProductAsyncRepository>();
builder.Services.AddSingleton<IEmployeeAsyncRepository, EmployeeAsyncRepository>();
builder.Services.AddSingleton<ICommondropdownasync, CommonDropdownRepository>();
builder.Services.AddSingleton<IUploadImageAsync, UplodImageAsync>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IShopRepositoryAsync, ShopAsyncRepository>();
builder.Services.AddSingleton<IAssignEmpShopRepository, AssignEmpShopRepository>();
builder.Services.AddSingleton<ICartRepositoryAsync, CartRepositoryAsync>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

app.Run();
