using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityACS.Data.DataContext.FluentConfigurations;

public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<Guid>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<Guid>> builder)
    {
        builder.HasData(new List<IdentityUserRole<Guid>>()
        {
            new()
            {
                RoleId = new Guid("5890b8ca-a2fd-48e4-a9b7-9e1ba1bd4b9f"),
                UserId = new Guid("4d82beb4-5e7b-48e6-b084-5bdc485bc1e7")
            }
        });
    }
}