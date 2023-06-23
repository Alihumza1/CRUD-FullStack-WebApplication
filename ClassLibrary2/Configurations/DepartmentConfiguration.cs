using ClassLibrary2.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Departments");
            builder.HasKey(o => o.Depid);
            builder.Property(p => p.Depid)
                .HasColumnName("Department ID")
                .IsRequired();
            builder.Property(p => p.Name)
                .HasColumnName("Department Name")
                .IsRequired();
            builder.Property(p => p.HeadName)
              .HasColumnName("Head Name")
              .IsRequired();
            builder.Property(p => p.Location)
                 .HasColumnName("Department Location ")
                 .IsRequired();     
        }
    }
}