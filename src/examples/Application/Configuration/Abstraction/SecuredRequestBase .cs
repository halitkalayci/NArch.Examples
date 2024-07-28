using Application.Configuration.Services;
using NArchitecture.Core.Application.Pipelines.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Configuration.Abstraction;
public abstract class SecuredRequestBase : ISecuredRequest
{
    public virtual string[] Roles => RoleConfigurationManager.GetRolesForCommand(GetCommandName());

    protected string GetCommandName()
    {
        return GetType().Name;
    }
}