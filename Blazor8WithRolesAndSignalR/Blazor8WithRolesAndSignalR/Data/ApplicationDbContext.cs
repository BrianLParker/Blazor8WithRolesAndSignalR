using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Blazor8WithRolesAndSignalR.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        IdentityRole[] seededRoles =
        [
            new IdentityRole
            {
                Id = "9a9dbeda-c681-48db-b4a7-c79c5259bf94",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "d95f09c1-a166-434a-9207-24ec56f6e6c4"
            },
            new IdentityRole
            {
                Id = "19d34cdf-507b-4a2f-a5ab-66018c887db5",
                Name = "Moderator",
                NormalizedName = "MODERATOR",
                ConcurrencyStamp = "d95f09c1-a166-434a-9207-24ec56f6e6c4"
            }
        ];

        ApplicationUser[] seededUsers =
        [
            new ApplicationUser
            {
               Id = "9c3e219c-1e63-4628-9b08-bc76ef648729",
               UserName = "bob@bob.com",
               NormalizedUserName = "BOB@BOB.COM",
               Email ="bob@bob.com",
               NormalizedEmail = "BOB@BOB.COM",
               EmailConfirmed = true,
               PasswordHash = "AQAAAAIAAYagAAAAEERZ/Fm8OS2jn3C1ZFm4KVax9pjknE+7nkSEteI2VI/PTln2fbZQcJCpcYYhuYyPpg==",
               SecurityStamp = "HULL3RUQ53EXBH7OIQKBPSTDHHUJE36J",
               ConcurrencyStamp = "d95f09c1-a166-434a-9207-24ec56f6e6c4",
               LockoutEnabled = true
            },
            new ApplicationUser
            {
               Id = "9aec66ee-db18-499e-9b0d-24f2e100b882",
               UserName = "sally@sally.com",
               NormalizedUserName = "SALLY@SALLY.COM",
               Email ="sally@sally.com",
               NormalizedEmail = "SALLY@SALLY.COM",
               EmailConfirmed = true,
               PasswordHash = "AQAAAAIAAYagAAAAEERZ/Fm8OS2jn3C1ZFm4KVax9pjknE+7nkSEteI2VI/PTln2fbZQcJCpcYYhuYyPpg==",
               SecurityStamp = "HULL3RUQ53EXBH7OIQKBPSTDHHUJE36J",
               ConcurrencyStamp = "d95f09c1-a166-434a-9207-24ec56f6e6c4",
               LockoutEnabled = true
            },
            new ApplicationUser
            {
               Id = "e496845c-71bd-4517-afa9-81c8f59d83cc",
               UserName = "joe@joe.com",
               NormalizedUserName = "JOE@JOE.COM",
               Email ="joe@joe.com",
               NormalizedEmail = "JOE@JOE.COM",
               EmailConfirmed = true,
               PasswordHash = "AQAAAAIAAYagAAAAEERZ/Fm8OS2jn3C1ZFm4KVax9pjknE+7nkSEteI2VI/PTln2fbZQcJCpcYYhuYyPpg==",
               SecurityStamp = "HULL3RUQ53EXBH7OIQKBPSTDHHUJE36J",
               ConcurrencyStamp = "d95f09c1-a166-434a-9207-24ec56f6e6c4",
               LockoutEnabled = true
            }
        ];

        IdentityUserRole<string>[] seededUserRoles =
        [
            new IdentityUserRole<string>
            {
               RoleId = "19d34cdf-507b-4a2f-a5ab-66018c887db5",
               UserId = "9c3e219c-1e63-4628-9b08-bc76ef648729"
            },
            new IdentityUserRole<string>
            {
               RoleId = "19d34cdf-507b-4a2f-a5ab-66018c887db5",
               UserId = "9aec66ee-db18-499e-9b0d-24f2e100b882"
            },
            new IdentityUserRole<string>
            {
               RoleId = "9a9dbeda-c681-48db-b4a7-c79c5259bf94",
               UserId = "9c3e219c-1e63-4628-9b08-bc76ef648729"
            }
        ];

        var roleBuilder = builder.Entity<IdentityRole>();
        roleBuilder.HasData(seededRoles);

        var userBuilder = builder.Entity<ApplicationUser>();
        userBuilder.HasData(seededUsers);

        var userRoleBuilder = builder.Entity<IdentityUserRole<string>>();
        userRoleBuilder.HasData(seededUserRoles);
    }
}
