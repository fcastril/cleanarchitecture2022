using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserCreatedId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserUpdatedId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyProfiles_Users_UserId",
                table: "UserCompanyProfiles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserCompanyProfiles_UserId",
                table: "UserCompanyProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserCreatedId",
                table: "Profiles");

            migrationBuilder.DropIndex(
                name: "IX_Profiles_UserUpdatedId",
                table: "Profiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCompanyProfiles_UserId",
                table: "UserCompanyProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserCreatedId",
                table: "Profiles",
                column: "UserCreatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Profiles_UserUpdatedId",
                table: "Profiles",
                column: "UserUpdatedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserCreatedId",
                table: "Profiles",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Users_UserUpdatedId",
                table: "Profiles",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyProfiles_Users_UserId",
                table: "UserCompanyProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
