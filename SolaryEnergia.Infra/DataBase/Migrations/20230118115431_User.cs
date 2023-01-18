using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SolaryEnergia.Infra.DataBase.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "VARCHAR(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "Password",
                oldMaxLength: 64);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Role",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 2,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "Password",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(64)",
                oldMaxLength: 64);
        }
    }
}
