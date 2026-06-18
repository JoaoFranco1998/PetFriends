using Microsoft.EntityFrameworkCore;

namespace PetFriends.Infrastructure.Persistence;

public sealed class PetFriendsDbContext : DbContext
{
    public PetFriendsDbContext(
        DbContextOptions<PetFriendsDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(
        ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(PetFriendsDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}