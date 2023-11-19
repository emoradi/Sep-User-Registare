using Microsoft.EntityFrameworkCore.Migrations;
using SEP.User.Registare.Domain.Models.Users.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEP.User.Registare.Persistance.Migrations
{
    public  class Miration01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE DATABASE SEP;");
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(320)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(13)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });
            migrationBuilder.CreateIndex(
               name: "IX_Users_Email",
               table: "Users",
               column: "EmailAddress",
               unique: true);
        }
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
            migrationBuilder.Sql("DROP DATABASE SEP;");

        }
    }
}
