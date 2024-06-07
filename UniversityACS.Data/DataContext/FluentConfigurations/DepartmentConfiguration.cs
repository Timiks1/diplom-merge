using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityACS.Core.Entities;

namespace UniversityACS.Data.DataContext.FluentConfigurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasMany(x => x.Members)
            .WithOne(x => x.Department)
            .HasForeignKey(x => x.DepartmentId);
        
        builder.HasOne(x => x.HeadOfDepartment).WithMany().HasForeignKey(x => x.HeadOfDepartmentId);
    }
}