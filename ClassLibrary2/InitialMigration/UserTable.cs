using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary2.InitialMigration
{
    [Migration(20230620000000)]
    public class UserTable : Migration
    {
        public override void Down()
        {
            Delete.Table("User");
        }

        public override void Up()
        {
            Create.Table("Users")
                .WithColumn("Id").AsInt32().Identity()
                .WithColumn("UserName").AsString(100).NotNullable()
                .WithColumn("Password").AsString(100).NotNullable();
        }
    }
}
