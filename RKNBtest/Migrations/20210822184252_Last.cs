using Microsoft.EntityFrameworkCore.Migrations;

namespace RKNBtest.Migrations
{
    public partial class Last : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Login",
                keyValue: "admin@gmail.com");

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Login",
                keyValue: "qwerty@gmail.com");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Persons",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Persons",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { "0", "admin@gmail.com", "12345", "admin" });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Login", "Password", "Role" },
                values: new object[] { "1", "qwerty@gmail.com", "55555", "user" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Login");
        }
    }
}
