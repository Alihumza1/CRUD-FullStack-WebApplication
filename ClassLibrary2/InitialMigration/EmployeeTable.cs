using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
namespace ClassLibrary2.InitialMigration
{
    [Migration(20230620000000)]
    public class EmployeeTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Employee");
        }

        public override void Up()
        {
            Create.Table("Employees")
                .WithColumn("Id").AsInt32().Identity()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("DepId").AsInt32().NotNullable()
                .ForeignKey("Department", "Depid")
                .WithColumn("Manager").AsString(100).NotNullable()
                .WithColumn("Cnic").AsString(14).NotNullable()
                .WithColumn("Age").AsInt32().NotNullable()
                .WithColumn("Salary").AsInt32().NotNullable();


        }
    }
}
