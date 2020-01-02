using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class BlogAPI : Migration
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
                    { new Guid("3e0e738a-6c38-4df1-a42a-0e1ad2e0ce79"), new DateTime(2019, 10, 17, 10, 51, 12, 846, DateTimeKind.Local).AddTicks(763), "Outra string", "Aula de docker" },
                    { new Guid("eb4bd2c0-dd33-4b74-8286-4915e6798fff"), new DateTime(2019, 10, 17, 10, 51, 12, 850, DateTimeKind.Local).AddTicks(9827), "GoF e a melhor equipe que tem", "Equipe Gang of Five" },
                    { new Guid("0961e950-c2eb-4bda-a3af-8ada74de8506"), new DateTime(2019, 10, 17, 10, 51, 12, 850, DateTimeKind.Local).AddTicks(9922), "GoF e a melhor equipe que tem", "Equipe Gang of Five" },
                    { new Guid("59dc189a-564e-49d0-8d59-51b8642373ca"), new DateTime(2019, 10, 17, 10, 51, 12, 850, DateTimeKind.Local).AddTicks(9934), "Prometemos entregar o banco", "Equipe que prometeu" }
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
