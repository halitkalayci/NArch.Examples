using Microsoft.Extensions.Caching.Distributed;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YamlDotNet.Core.Tokens;
using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Application.Services.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using MimeKit.Cryptography;
using Application.Configuration.Extensions;

namespace Application.Configuration.Services;
public static partial class RoleConfigurationManager
{
    private static readonly object LockObject = new();

    public static void LoadRoles()
    {

        IServiceProvider serviceProvider = ServiceProviderExtensions.GetServiceProvider();
        using (var scope = serviceProvider.CreateScope())
        {
            var scopedProvider = scope.ServiceProvider;
            IDistributedCache cache = scopedProvider.GetRequiredService<IDistributedCache>();
            IRequestConfigRepository requestConfigRepository = scopedProvider.GetRequiredService<IRequestConfigRepository>();
            lock (LockObject)
            {
                // Daha hızlı sonuç ve daha az maliyet için Databaseden redise yükle. 
                List<RoleConfiguration> requestConfigs = requestConfigRepository.Query()
                    .Include(i => i.RequestOperationClaims)
                    .ThenInclude(i => i.OperationClaim)
                    .Select(i => new RoleConfiguration()
                    {
                        CommandName = i.RequestName,
                        RequiredRoles = i.RequestOperationClaims.Select(j => j.OperationClaim.Name).ToArray()
                    })
                    .ToList();

                var configurationsInBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(requestConfigs));

                cache.Set("RoleConfigurations", configurationsInBytes);


            }
        }

    }

    public static string[] GetRolesForCommand(string commandName)
    {
        IServiceProvider serviceProvider = ServiceProviderExtensions.GetServiceProvider();
        IDistributedCache cache = serviceProvider.GetRequiredService<IDistributedCache>();
        var rolesConfigJson = cache.GetString("RoleConfigurations");
        if (string.IsNullOrEmpty(rolesConfigJson))
            return Array.Empty<string>();

        var rolesConfig = JsonSerializer.Deserialize<List<RoleConfiguration>>(rolesConfigJson);
        var config = rolesConfig?.FirstOrDefault(i => i.CommandName == commandName);

        if (config != null)
            return config.RequiredRoles;

        return Array.Empty<string>();
    }
}
