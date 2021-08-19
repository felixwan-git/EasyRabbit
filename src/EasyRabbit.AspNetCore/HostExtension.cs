using EasyRabbit.Utils;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace EasyRabbit.AspNetCore
{
    public static class HostExtension
    {
        public static IHost UseEasyRabbit(this IHost host)
        {
            ServiceProviderObjectContainer.Provider = host.Services;
            var objectaContainer = host.Services.GetService<IObjectContainer>();
            var builder = host.Services.GetService<RabbitMQBuilder>();
            builder.RegisterObjectContainer(objectaContainer);
            builder.Start();

            return host;
        }
    }
}