using Microsoft.Extensions.DependencyInjection;

namespace NPetrovich.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPetrovich(this IServiceCollection services)
        {
            return services.AddSingleton<IPetrovich, Petrovich>();
        }
    }
}