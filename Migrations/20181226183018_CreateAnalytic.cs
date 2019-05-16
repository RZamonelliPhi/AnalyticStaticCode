using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticStaticCode.Migrations
{
    public partial class CreateAnalytic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnalyticProject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticProject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnalyticReport",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticReport", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnalyticReportAux",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuildNumber = table.Column<string>(nullable: true),
                    DateAnalyticReportAux = table.Column<DateTime>(nullable: false),
                    XmlInfo = table.Column<string>(type: "xml", nullable: true),
                    AnalyticReportId = table.Column<int>(nullable: false),
                    AnalyticProjectId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticReportAux", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalyticReportAux_AnalyticProject_AnalyticProjectId",
                        column: x => x.AnalyticProjectId,
                        principalTable: "AnalyticProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalyticReportAux_AnalyticReport_AnalyticReportId",
                        column: x => x.AnalyticReportId,
                        principalTable: "AnalyticReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnalyticData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Section = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    AnalyticReportAuxId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalyticData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalyticData_AnalyticReportAux_AnalyticReportAuxId",
                        column: x => x.AnalyticReportAuxId,
                        principalTable: "AnalyticReportAux",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalyticData_AnalyticReportAuxId",
                table: "AnalyticData",
                column: "AnalyticReportAuxId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalyticReportAux_AnalyticProjectId",
                table: "AnalyticReportAux",
                column: "AnalyticProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalyticReportAux_AnalyticReportId",
                table: "AnalyticReportAux",
                column: "AnalyticReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalyticData");

            migrationBuilder.DropTable(
                name: "AnalyticReportAux");

            migrationBuilder.DropTable(
                name: "AnalyticProject");

            migrationBuilder.DropTable(
                name: "AnalyticReport");
        }
    }
}
