using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace ASPNET5WebApi.Migrations
{
    public partial class InitMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Blog",
                columns: table => new
                {
                    BlogId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Name = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.BlogId);
                });
            migration.CreateTable(
                name: "Post",
                columns: table => new
                {
                    BlogId = table.Column(type: "int", nullable: false),
                    Comment = table.Column(type: "nvarchar(max)", nullable: true),
                    PostId = table.Column(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGeneration", "Identity"),
                    Title = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.PostId);
                    table.ForeignKey(
                        name: "FK_Post_Blog_BlogId",
                        columns: x => x.BlogId,
                        referencedTable: "Blog",
                        referencedColumn: "BlogId");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Blog");
            migration.DropTable("Post");
        }
    }
}
