using MechanicShop.Domain.Employees;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MechanicShop.Infrastructure.Data.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
      // IsClustered is a property that determines whether the primary key of the table is clustered or not.
      //  A clustered index determines the physical order of data in the table, 
      // and there can be only one clustered index per table. By default,
      //  primary keys are clustered, but in this case,
      //  we are specifying that the primary key for the Employee entity should not be clustered.
      //  This can be useful for performance reasons, 
      // especially if you have a large number of records and want to optimize certain queries.
        builder.HasKey(e => e.Id).IsClustered(false);

        builder.Property(e => e.FirstName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(e => e.LastName)
               .IsRequired()
               .HasMaxLength(50);

        builder.Property(e => e.Role).HasConversion<string>().IsRequired();
    }
}