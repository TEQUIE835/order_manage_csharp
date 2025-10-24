using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using orderManage.Application.Services;

namespace orderManage.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CustomerService>();
        services.AddScoped<OrderStatusService>();
        services.AddScoped<ProductService>();
        services.AddScoped<OrderService>();
        services.AddScoped<OrderDetailService>();
        
        return services;
    }
}