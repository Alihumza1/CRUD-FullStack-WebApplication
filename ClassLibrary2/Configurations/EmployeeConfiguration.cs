using ClassLibrary2.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.HasOne(o => o.Departments).WithMany(o => o.Employees).HasForeignKey(o => o.DepId);
            builder.Property(p => p.Id)
                .HasColumnName("ID")
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("Employee Name")
                .IsRequired();
            builder.Property(p => p.Manager)
                .HasColumnName("Manager")
                .IsRequired();
            builder.Property(p => p.Cnic)
                .HasColumnName("CNIC.no")
                .IsRequired();
            builder.Property(p => p.Age)
                .HasColumnName("Age")
                .IsRequired();
            builder.Property(p => p.Salary)
                .HasColumnName("Salary")
                .IsRequired();
        }
    }
}