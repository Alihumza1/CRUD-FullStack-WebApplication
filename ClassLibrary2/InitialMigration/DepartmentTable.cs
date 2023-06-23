using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
namespace ClassLibrary2.InitialMigration
{
    [Migration(20230620000000)]
    public class DepartmentTable : Migration
    {
        public override void Down()
        {
            Delete.Table("Department");
        }

        public override void Up()
        {
            Create.Table("Department")
                .WithColumn("DepId").AsInt32().Identity().PrimaryKey()
                .WithColumn("Name").AsString(100).NotNullable()
                .WithColumn("HeadName").AsString(100).NotNullable()
                .WithColumn("Location").AsString(14).NotNullable();

           
        }

    }
}
