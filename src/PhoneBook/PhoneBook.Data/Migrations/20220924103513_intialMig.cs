using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Data.Migrations
{
    public partial class intialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Surname = table.Column<string>(type: "varchar(100)", nullable: false),
                    Company = table.Column<string>(type: "varchar(255)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactInfos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    PersonId = table.Column<Guid>(type: "uuid", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(30)", nullable: true),
                    MailAddress = table.Column<string>(type: "varchar(30)", nullable: true),
                    Location = table.Column<string>(type: "varchar(100)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactInfos", x => x.Id);
                    table.ForeignKey(
                        name: "contactinfos_persons_personid_fk",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfos_PersonId",
                table: "ContactInfos",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactInfos");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
