using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CheckDotnetVersions.BackGroundServices;

namespace dotnet_check.Data
{
    public class dotnet_checkContext : DbContext
    {
        public dotnet_checkContext (DbContextOptions<dotnet_checkContext> options)
            : base(options)
        {
        }

        public DbSet<ReleasesIndex> ReleasesIndex { get; set; } = default!;
    }
}
