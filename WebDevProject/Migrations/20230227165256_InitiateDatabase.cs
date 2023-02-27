using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebDevProject.Migrations
{
    /// <inheritdoc />
    public partial class InitiateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    FormId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false),
                    Callback = table.Column<bool>(type: "bit", nullable: false),
                    CallbackAvailableMonday = table.Column<bool>(type: "bit", nullable: false),
                    CallbackAvailableTuesday = table.Column<bool>(type: "bit", nullable: false),
                    CallbackAvailableWednesday = table.Column<bool>(type: "bit", nullable: false),
                    CallbackAvailableThursday = table.Column<bool>(type: "bit", nullable: false),
                    CallbackAvailableFriday = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.FormId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
