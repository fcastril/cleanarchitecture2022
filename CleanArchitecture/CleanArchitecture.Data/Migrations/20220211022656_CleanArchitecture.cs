using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Data.Migrations
{
    public partial class CleanArchitecture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionSecurity_Option_OptionId",
                table: "OptionSecurity");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionSecurity_Profile_ProfileId",
                table: "OptionSecurity");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Companies_CompanyId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Users_UserCreatedId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_Profile_Users_UserUpdatedId",
                table: "Profile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyProfile_Companies_CompanyId",
                table: "UserCompanyProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyProfile_Profile_ProfileId",
                table: "UserCompanyProfile");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyProfile_Users_UserId",
                table: "UserCompanyProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompanyProfile",
                table: "UserCompanyProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profile",
                table: "Profile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionSecurity",
                table: "OptionSecurity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Option",
                table: "Option");

            migrationBuilder.RenameTable(
                name: "UserCompanyProfile",
                newName: "UserCompanyProfiles");

            migrationBuilder.RenameTable(
                name: "Profile",
                newName: "Profiles");

            migrationBuilder.RenameTable(
                name: "OptionSecurity",
                newName: "OptionSecurities");

            migrationBuilder.RenameTable(
                name: "Option",
                newName: "Options");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyProfile_UserId",
                table: "UserCompanyProfiles",
                newName: "IX_UserCompanyProfiles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyProfile_ProfileId",
                table: "UserCompanyProfiles",
                newName: "IX_UserCompanyProfiles_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyProfile_CompanyId",
                table: "UserCompanyProfiles",
                newName: "IX_UserCompanyProfiles_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_UserUpdatedId",
                table: "Profiles",
                newName: "IX_Profiles_UserUpdatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_UserCreatedId",
                table: "Profiles",
                newName: "IX_Profiles_UserCreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Profile_CompanyId",
                table: "Profiles",
                newName: "IX_Profiles_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_OptionSecurity_ProfileId",
                table: "OptionSecurities",
                newName: "IX_OptionSecurities_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_OptionSecurity_OptionId",
                table: "OptionSecurities",
                newName: "IX_OptionSecurities_OptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompanyProfiles",
                table: "UserCompanyProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionSecurities",
                table: "OptionSecurities",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Options",
                table: "Options",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionSecurities_Options_OptionId",
                table: "OptionSecurities",
                column: "OptionId",
                principalTable: "Options",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionSecurities_Profiles_ProfileId",
                table: "OptionSecurities",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profiles_Companies_CompanyId",
                table: "Profiles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_UserCompanyProfiles_Companies_CompanyId",
                table: "UserCompanyProfiles",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyProfiles_Profiles_ProfileId",
                table: "UserCompanyProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OptionSecurities_Options_OptionId",
                table: "OptionSecurities");

            migrationBuilder.DropForeignKey(
                name: "FK_OptionSecurities_Profiles_ProfileId",
                table: "OptionSecurities");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Companies_CompanyId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserCreatedId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_Profiles_Users_UserUpdatedId",
                table: "Profiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyProfiles_Companies_CompanyId",
                table: "UserCompanyProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyProfiles_Profiles_ProfileId",
                table: "UserCompanyProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCompanyProfiles_Users_UserId",
                table: "UserCompanyProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompanyProfiles",
                table: "UserCompanyProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Profiles",
                table: "Profiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OptionSecurities",
                table: "OptionSecurities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Options",
                table: "Options");

            migrationBuilder.RenameTable(
                name: "UserCompanyProfiles",
                newName: "UserCompanyProfile");

            migrationBuilder.RenameTable(
                name: "Profiles",
                newName: "Profile");

            migrationBuilder.RenameTable(
                name: "OptionSecurities",
                newName: "OptionSecurity");

            migrationBuilder.RenameTable(
                name: "Options",
                newName: "Option");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyProfiles_UserId",
                table: "UserCompanyProfile",
                newName: "IX_UserCompanyProfile_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyProfiles_ProfileId",
                table: "UserCompanyProfile",
                newName: "IX_UserCompanyProfile_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserCompanyProfiles_CompanyId",
                table: "UserCompanyProfile",
                newName: "IX_UserCompanyProfile_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_UserUpdatedId",
                table: "Profile",
                newName: "IX_Profile_UserUpdatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_UserCreatedId",
                table: "Profile",
                newName: "IX_Profile_UserCreatedId");

            migrationBuilder.RenameIndex(
                name: "IX_Profiles_CompanyId",
                table: "Profile",
                newName: "IX_Profile_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_OptionSecurities_ProfileId",
                table: "OptionSecurity",
                newName: "IX_OptionSecurity_ProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_OptionSecurities_OptionId",
                table: "OptionSecurity",
                newName: "IX_OptionSecurity_OptionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompanyProfile",
                table: "UserCompanyProfile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Profile",
                table: "Profile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OptionSecurity",
                table: "OptionSecurity",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Option",
                table: "Option",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OptionSecurity_Option_OptionId",
                table: "OptionSecurity",
                column: "OptionId",
                principalTable: "Option",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OptionSecurity_Profile_ProfileId",
                table: "OptionSecurity",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Companies_CompanyId",
                table: "Profile",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Users_UserCreatedId",
                table: "Profile",
                column: "UserCreatedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Profile_Users_UserUpdatedId",
                table: "Profile",
                column: "UserUpdatedId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyProfile_Companies_CompanyId",
                table: "UserCompanyProfile",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyProfile_Profile_ProfileId",
                table: "UserCompanyProfile",
                column: "ProfileId",
                principalTable: "Profile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCompanyProfile_Users_UserId",
                table: "UserCompanyProfile",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
