using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Models.CrowdFunding;

namespace AspnetCoreMvcStarter.Data
{
    public class AspnetCoreMvcStarterContext : DbContext
    {
        public AspnetCoreMvcStarterContext (DbContextOptions<AspnetCoreMvcStarterContext> options)
            : base(options)
        {
        }
        public DbSet<AspnetCoreMvcStarter.Models.Transactions> Transactions { get; set; } = default!;
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectView> ProjectViews { get; set; }
        public DbSet<ProjectInfo> ProjectInfos { get; set; }
        public DbSet<TextSegment> TextSegments { get; set; }
        public DbSet<QuestionHistory> QuestionHistories { get; set; }
        public DbSet<DashboardData> DashboardData { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UnderwritingByYear> UnderwritingByYears { get; set; }

  }
}
