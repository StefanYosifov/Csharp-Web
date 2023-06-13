using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Contacts.Data.Migrations
{
    public partial class updateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContact_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContact");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContact_Contact_ContactId",
                table: "ApplicationUserContact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserContact",
                table: "ApplicationUserContact");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameTable(
                name: "ApplicationUserContact",
                newName: "ApplicationUserContacts");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserContact_ContactId",
                table: "ApplicationUserContacts",
                newName: "IX_ApplicationUserContacts_ContactId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserContacts",
                table: "ApplicationUserContacts",
                columns: new[] { "ApplicationUserId", "ContactId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContacts_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContacts",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContacts_Contacts_ContactId",
                table: "ApplicationUserContacts",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContacts_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContacts");

            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUserContacts_Contacts_ContactId",
                table: "ApplicationUserContacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApplicationUserContacts",
                table: "ApplicationUserContacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameTable(
                name: "ApplicationUserContacts",
                newName: "ApplicationUserContact");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationUserContacts_ContactId",
                table: "ApplicationUserContact",
                newName: "IX_ApplicationUserContact_ContactId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApplicationUserContact",
                table: "ApplicationUserContact",
                columns: new[] { "ApplicationUserId", "ContactId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContact_AspNetUsers_ApplicationUserId",
                table: "ApplicationUserContact",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUserContact_Contact_ContactId",
                table: "ApplicationUserContact",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
