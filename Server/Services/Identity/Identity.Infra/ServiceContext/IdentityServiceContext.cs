using Identity.Domain.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infra.ServiceContext
{
    public class IdentityServiceContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public IdentityServiceContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Address>(entity => {
                entity.HasOne(appuser => appuser.User)
                    .WithMany(appuser => appuser.Address)
                    .HasForeignKey(add => add.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            foreach (var entityType in builder.Model.GetEntityTypes()) {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet")) {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }
    }
}