using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityACS.Core.Entities;

namespace UniversityACS.Data.DataContext.FluentConfigurations;

public class ApplicationRoleConfiguration : IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasData(new List<ApplicationRole>
        {
            new()
            {
                Id = new Guid("5890b8ca-a2fd-48e4-a9b7-9e1ba1bd4b9f"),
                Name = "Admin"
            },
            new()
            {
                Id = new Guid("f68b52f3-713e-48e7-968a-6be47c9ce300"),
                Name = "DepartHead"
            },
            new ()
            {
                Id = new Guid("1577fd47-47e9-4884-949d-c8932382631c"),
                Name = "Teacher"
            },
            new ()
            {
                Id = new Guid("77348823-4700-468b-a4ae-8ae52e99ee08"),
                Name = "Student"
            }
        });
    }
}