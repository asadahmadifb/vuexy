using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Models;

namespace AspnetCoreMvcStarter.Data
{
    public class AspnetCoreMvcStarterContext : DbContext
    {
        public AspnetCoreMvcStarterContext (DbContextOptions<AspnetCoreMvcStarterContext> options)
            : base(options)
        {
        }
        public DbSet<AspnetCoreMvcStarter.Models.Transactions> Transactions { get; set; } = default!;
    }
}
