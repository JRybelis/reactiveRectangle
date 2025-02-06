using ReactiveRectangle.Api.Middleware;
using ReactiveRectangle.Contracts.Interfaces;
using ReactiveRectangle.Infrastructure.Interfaces;
using ReactiveRectangle.Infrastructure.IO;
using ReactiveRectangle.Services.Services;
using ReactiveRectangle.Services.Services.Validation;

namespace ReactiveRectangle.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure", "Data", "rectangle.json");
        services.AddSingleton<IJsonStorage>(new JsonStorage(jsonPath));
        services.AddScoped<IValidationService, ValidationService>();
        services.AddScoped<IRectangleService, RectangleService>();
        services.AddTransient<GlobalExceptionHandler>();
        
        return services;
    }
}