using productcrudforangular.repository.Interface;

namespace productcrudforangular.repository
{
    public class ShopUpdateService : BackgroundService
    {
        private readonly ILogger<ShopUpdateService> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ShopUpdateService(IServiceProvider serviceProvider, ILogger<ShopUpdateService> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("OrderUpdateService running.");

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var orderRepo = scope.ServiceProvider.GetRequiredService<IOrderRepository>();
                    await orderRepo.UpdateShop();
                }

                await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
            }
        }
    }
}
