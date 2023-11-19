using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SEP.User.Registare.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class changeType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "User",
                type: "varchar(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(320)",
                oldMaxLength: 320);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "char(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(13)",
                oldMaxLength: 13);

            migrationBuilder.AlterColumn<string>(
                name: "EmailAddress",
                table: "User",
                type: "char(320)",
                maxLength: 320,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(320)",
                oldMaxLength: 320);
        }
    }
}
