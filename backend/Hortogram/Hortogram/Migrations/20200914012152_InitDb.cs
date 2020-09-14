using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hortogram.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Lastname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true, type: "nvarchar(100)", maxLength: 100),
                    Password = table.Column<string>(nullable: true),
                    PhotoURL = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.UniqueConstraint(
                        name: "EMAIL_UNIQUE",
                        columns: table => new { table.Email }
                    );
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
