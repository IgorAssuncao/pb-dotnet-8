using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Hortogram.Migrations
{
    public partial class AddFollowers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersFollowers",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    FollowerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey(name: "PK_User_Follower", columns: x => new { x.UserId, x.FollowerId });
                    table.ForeignKey(name: "FK_UserId", column: x => x.UserId, principalTable: "user", principalColumn: "Id");
                    table.ForeignKey(name: "FK_FollowerId", column: x => x.FollowerId, principalTable: "user", principalColumn: "Id");
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersFollowers");
        }
    }
}
