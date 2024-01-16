using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolMaster.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiNicCOlName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "nvarchar(12)",
                table: "Students",
                newName: "Nic");

            migrationBuilder.AlterColumn<string>(
                name: "Nic",
                table: "Students",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nic",
                table: "Students",
                newName: "nvarchar(12)");

            migrationBuilder.AlterColumn<string>(
                name: "nvarchar(12)",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12,
                oldNullable: true);
        }
    }
}
