using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Memberships.Application.Abstractions.Persistence;
using Memberships.Infrastructure.Persistence;
using Memberships.Infrastructure.Persistence.Repositories;

namespace Memberships.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<MembershipsDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IMemberRepository, MemberRepository>();


        return services;
    }
}
