using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Blog");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Blog",
                columns: table => new
                {
                    CategoryId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                schema: "Blog",
                columns: table => new
                {
                    IdPost = table.Column<Guid>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 60, nullable: false),
                    Description = table.Column<string>(maxLength: 1500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.IdPost);
                });

            migrationBuilder.CreateTable(
                name: "TBL_Comment",
                schema: "Blog",
                columns: table => new
                {
                    IdComment = table.Column<Guid>(nullable: false),
                    Message = table.Column<string>(maxLength: 140, nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_Comment", x => x.IdComment);
                });

            migrationBuilder.CreateTable(
                name: "TBL_User",
                schema: "Blog",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_User", x => x.IdUser);
                });

            migrationBuilder.InsertData(
                schema: "Blog",
                table: "Post",
                columns: new[] { "IdPost", "CreationDate", "Description", "Title" },
                values: new object[,]
                {
                    { new Guid("680007b7-9d3a-4f47-83a0-aa6620893917"), new DateTime(2019, 10, 17, 14, 1, 46, 326, DateTimeKind.Local).AddTicks(2631), "Outra string", "Aula de docker" },
                    { new Guid("f2bbe729-2f4b-49db-ad1f-c74da8400861"), new DateTime(2019, 10, 17, 14, 1, 46, 332, DateTimeKind.Local).AddTicks(5764), "GoF e a melhor equipe que tem", "Equipe Gang of Five" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category",
                schema: "Blog");

            migrationBuilder.DropTable(
                name: "Post",
                schema: "Blog");

            migrationBuilder.DropTable(
                name: "TBL_Comment",
                schema: "Blog");

            migrationBuilder.DropTable(
                name: "TBL_User",
                schema: "Blog");
        }
    }
}
