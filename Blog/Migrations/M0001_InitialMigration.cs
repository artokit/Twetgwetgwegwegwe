using System.ComponentModel.DataAnnotations.Schema;
using FluentMigrator;
namespace WebApplication6.Migrations;

[Migration(1)]
public class M0001_InitialMigration : Migration
{
    public override void Up()
    {
        Create.Table("Articles")
            .WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
            .WithColumn("Title").AsString().NotNullable()
            .WithColumn("Content").AsString()
            .WithColumn("PublishDate").AsDateTime();

        Create.Table("Comments")
            .WithColumn("Id").AsInt64().PrimaryKey().NotNullable()
            .WithColumn("UserId").AsInt64()
            .WithColumn("Content").AsString();
       
        Create.Table("User")
            .WithColumn("Id").AsInt64().NotNullable().Unique()
            .WithColumn("Username").AsString();

        Create.ForeignKey().FromTable("Comments").ForeignColumn("UserId").ToTable("User").PrimaryColumn("Id");
    }

    public override void Down()
    {
        Delete.Table("Articles");
        Delete.Table("Comments");
        Delete.Table("User");
    }
}