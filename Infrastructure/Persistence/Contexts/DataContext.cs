using Application.Services;
using Domain.Entities.common;
using Domain.Entities.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class DataContext : IdentityDbContext<CustomUser, CustomRole, int, CustomUserClaim, CustomUserRole, CustomUserLogin, CustomRoleClaim, CustomUserToken>
    {
        private readonly IIdentityService _identityService;

        public DataContext(DbContextOptions options, IIdentityService identityService)
            : base(options)
        {
            _identityService = identityService;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //var userId = identityService.UserId;
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        //entry.Entity.CreatedBy = userId;
                        break;
                    //case EntityState.Modified:
                    //    entry.Property(m => m.CreatedAt).IsModified = false;
                    //    entry.Property(m => m.CreatedBy).IsModified = false;
                    //    entry.Entity.ModifiedAt = DateTime.UtcNow;
                    //    //entry.Entity.ModifiedBy = userId;
                    //    break;
                    //case EntityState.Deleted:
                    //    entry.Property(m => m.CreatedAt).IsModified = false;
                    //    entry.Property(m => m.CreatedBy).IsModified = false;
                    //    entry.Property(m => m.ModifiedAt).IsModified = false;
                    //    entry.Property(m => m.ModifiedBy).IsModified = false;
                    //    entry.Entity.DeletedAt = DateTime.UtcNow;
                    //    //entry.Entity.DeletedBy = userId;
                    //    entry.State = EntityState.Modified;
                    //    break;
                    default:
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
