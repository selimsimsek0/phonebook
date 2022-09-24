using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PhoneBook.Report.Data.Migrations
{
    public partial class intialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    Location = table.Column<string>(type: "varchar(255)", nullable: false),
                    PersonCount = table.Column<double>(type: "double precision", nullable: false),
                    PhoneNumberCount = table.Column<double>(type: "double precision", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationReports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationReportRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "gen_random_uuid()"),
                    CreationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentType = table.Column<int>(type: "int", nullable: false),
                    DocumentPath = table.Column<string>(type: "varchar(500)", nullable: true),
                    DocumentName = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationReportRequests", x => x.Id);
                    table.ForeignKey(
                        name: "locationreportrequest_locationreport_reportid_fk",
                        column: x => x.ReportId,
                        principalTable: "LocationReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationReportRequests_ReportId",
                table: "LocationReportRequests",
                column: "ReportId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationReportRequests");

            migrationBuilder.DropTable(
                name: "LocationReports");
        }
    }
}
