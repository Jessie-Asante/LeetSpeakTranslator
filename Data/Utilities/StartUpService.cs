namespace StringConverter.Data.Utilities
{
    public class StartUpService : IHostedService
    {
        private IServiceProvider _serviceProvider;
        public StartUpService(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;
       
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var services = scope.ServiceProvider;

            var logger =services.GetRequiredService<ILogger<StartUpService>>();
            var environment = services.GetRequiredService<IWebHostEnvironment>();
             
            if (environment.IsDevelopment())
            {
                //Ensure databse is created
                var dbcontext = services.GetRequiredService<StringConverterDbContext>();
                await dbcontext.Database.EnsureCreatedAsync();
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
