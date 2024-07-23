﻿using NArchitecture.Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Brand : Entity<Guid>
{
    public required string Name { get; set; }
    public string? LogoUrl { get; set; }
}

