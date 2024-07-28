using Application.Configuration.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration.Extensions;
public static class ConfigurationLoaderExtensions
{
    public static void LoadConfigLoader(this IServiceProvider services)
    {
       RoleConfigurationManager.LoadRoles();
    }
}
