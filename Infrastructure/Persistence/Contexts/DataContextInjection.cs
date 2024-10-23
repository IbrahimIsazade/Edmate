using Domain.Entities.Membership;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence.Contexts
{
    public static class DataContextInjections
    {
        public static IServiceCollection AddDataContext(this IServiceCollection services,
            Action<DbContextOptionsBuilder>? optionsAction = null,
            ServiceLifetime contextLifetime = ServiceLifetime.Scoped,
            ServiceLifetime optionsLifetime = ServiceLifetime.Scoped)
        {
            services.AddDbContext<DataContext>(optionsAction, contextLifetime, optionsLifetime);

            services.AddIdentityCore<CustomUser>()
                .AddRoles<CustomRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders()
                .AddErrorDescriber<ErrorDescriber>()
                .AddUserManager<UserManager<CustomUser>>()
                .AddSignInManager<SignInManager<CustomUser>>()
                .AddRoleManager<RoleManager<CustomRole>>();
            return services;
        }
    }
}
