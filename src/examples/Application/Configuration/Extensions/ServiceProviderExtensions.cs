using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration.Extensions;
public static class ServiceProviderExtensions
{
    private static IServiceProvider _serviceProvider;

    public static void SetServiceProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public static IServiceProvider GetServiceProvider()
    {
        if (_serviceProvider == null)
        {
            throw new InvalidOperationException("ServiceProvider is not set.");
        }
        return _serviceProvider;
    }
}
