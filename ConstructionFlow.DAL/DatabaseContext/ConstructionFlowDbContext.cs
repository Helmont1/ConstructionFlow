using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConstructionFlow.DAL.Map;
using ConstructionFlow.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace ConstructionFlow.DAL.DatabaseContext
{
    public class ConstructionFlowDbContext : DbContext
    {
        public ConstructionFlowDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Construction> Construction { get; set; }
        public DbSet<ConstructionPhoto> ConstructionPhoto { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<DefaultActivity> DefaultActivity { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConstructionMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
