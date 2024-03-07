using Microsoft.Extensions.DependencyInjection;

namespace PrivateChat.Infrastructure
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddChatProcessor(this IServiceCollection services)
        {
            return services;
        }
    }
}