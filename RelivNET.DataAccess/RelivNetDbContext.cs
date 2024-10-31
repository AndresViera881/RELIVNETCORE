

using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace RelivNET.DataAccess
{
    public class RelivNetDbContext : DbContext
    {
        public RelivNetDbContext(DbContextOptions<RelivNetDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
