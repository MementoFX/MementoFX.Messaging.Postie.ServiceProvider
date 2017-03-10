using Microsoft.Extensions.DependencyInjection;
using System;

namespace Memento.Messaging.Postie.ServiceProvider
{
    public class ServiceProviderTypeResolver : ITypeResolver
    {
        public IServiceCollection Services { get; private set; }

        public ServiceProviderTypeResolver(IServiceCollection services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            Services = services;
        }

        public object Resolve(Type t)
        {
            var container = Services.BuildServiceProvider();
            return container.GetService(t);
        }
    }
}
