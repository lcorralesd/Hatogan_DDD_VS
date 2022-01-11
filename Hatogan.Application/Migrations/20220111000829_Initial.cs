using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hatogan.Application.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Origins",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sexs",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    OriginId = table.Column<short>(type: "smallint", nullable: false),
                    SexId = table.Column<short>(type: "smallint", nullable: false),
                    StatusId = table.Column<short>(type: "smallint", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: false),
                    BirthWeight = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "date", nullable: false),
                    IncomeWeight = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    ActualWeight = table.Column<decimal>(type: "decimal(9,2)", precision: 9, scale: 2, nullable: false),
                    SireId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Inactive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Animals_DamId",
                        column: x => x.DamId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Animals_SireId",
                        column: x => x.SireId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Origins_OriginId",
                        column: x => x.OriginId,
                        principalTable: "Origins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Sexs_SexId",
                        column: x => x.SexId,
                        principalTable: "Sexs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Inactive", "Name" },
                values: new object[,]
                {
                    { 1, false, "Ternero" },
                    { 2, false, "Novilla Destete" },
                    { 3, false, "Maute Destete" },
                    { 4, false, "Novilla de Levante" },
                    { 5, false, "Maute de Levante" },
                    { 6, false, "Novilla Vientre" },
                    { 7, false, "Maute Ceba" },
                    { 8, false, "Vaca" },
                    { 9, false, "Toro" }
                });

            migrationBuilder.InsertData(
                table: "Origins",
                columns: new[] { "Id", "Inactive", "Name" },
                values: new object[,]
                {
                    { (short)1, false, "Propio" },
                    { (short)2, false, "Comprado" }
                });

            migrationBuilder.InsertData(
                table: "Sexs",
                columns: new[] { "Id", "Inactive", "Name" },
                values: new object[,]
                {
                    { (short)1, false, "Hembra" },
                    { (short)2, false, "Macho" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Inactive", "Name" },
                values: new object[,]
                {
                    { (short)1, false, "Activo" },
                    { (short)2, false, "Enfermo" },
                    { (short)3, false, "Muerto" },
                    { (short)4, false, "Enfermo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_DamId",
                table: "Animals",
                column: "DamId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_Number",
                table: "Animals",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_OriginId",
                table: "Animals",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SexId",
                table: "Animals",
                column: "SexId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SireId",
                table: "Animals",
                column: "SireId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_StatusId",
                table: "Animals",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Origins");

            migrationBuilder.DropTable(
                name: "Sexs");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
