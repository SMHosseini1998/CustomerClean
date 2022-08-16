using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CustomerClean.Infrastructure.Migrations
{
    public partial class initt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "province",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_province", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Services_tbl",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Service_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services_tbl", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    province_id = table.Column<int>(type: "int", nullable: false),
                    county_id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.id);
                    table.ForeignKey(
                        name: "FK_city_province_province_id",
                        column: x => x.province_id,
                        principalTable: "province",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Main_Form_tbl",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sys_Id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State_Id = table.Column<int>(type: "int", nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Services_Id = table.Column<int>(type: "int", nullable: false),
                    Gride_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meli_Image_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Guarantee_Image_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Main_Form_tbl", x => x.id);
                    table.ForeignKey(
                        name: "FK_Main_Form_tbl_city_City_Id",
                        column: x => x.City_Id,
                        principalTable: "city",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Main_Form_tbl_Services_tbl_Services_Id",
                        column: x => x.Services_Id,
                        principalTable: "Services_tbl",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_city_province_id",
                table: "city",
                column: "province_id");

            migrationBuilder.CreateIndex(
                name: "IX_Main_Form_tbl_City_Id",
                table: "Main_Form_tbl",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Main_Form_tbl_Services_Id",
                table: "Main_Form_tbl",
                column: "Services_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Main_Form_tbl");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "Services_tbl");

            migrationBuilder.DropTable(
                name: "province");
        }
    }
}
