using FunctionAppNetSix.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(s =>
    {
        s.AddScoped<IShoppingCartService, ShoppingCartService>();
    })
    .Build();
    

host.Run();
