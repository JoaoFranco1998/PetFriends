using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using PetFriends.Infrastructure.Persistence;

namespace PetFriends.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        string connectionString)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(
            connectionString);

        services.AddDbContext<PetFriendsDbContext>(
            options =>
            {
                options.UseNpgsql(connectionString);
            });

        return services;
    }
}