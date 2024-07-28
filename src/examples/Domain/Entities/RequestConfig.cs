using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class RequestConfig : Entity<Guid>
{
    public string RequestName { get; set; }
    public ICollection<RequestOperationClaim> RequestOperationClaims { get; set; }
}
