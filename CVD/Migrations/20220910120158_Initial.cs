using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CVD.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    department_id = table.Column<int>(type: "integer", nullable: false),
                    chief_id = table.Column<int>(type: "integer", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    salary = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.id);
                    table.ForeignKey(
                        name: "FK_employee_department_department_id",
                        column: x => x.department_id,
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "department",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "D1" },
                    { 2, "D2" },
                    { 3, "D3" }
                });

            migrationBuilder.InsertData(
                table: "employee",
                columns: new[] { "id", "chief_id", "department_id", "name", "salary" },
                values: new object[,]
                {
                    { 1, 5, 1, "John", 100 },
                    { 2, 5, 1, "Misha", 600 },
                    { 3, 6, 2, "Eugen", 300 },
                    { 4, 6, 2, "Tolya", 400 },
                    { 5, 7, 3, "Stepan", 500 },
                    { 6, 7, 3, "Alex", 1000 },
                    { 7, null, 3, "Ivan", 1100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_employee_department_id",
                table: "employee",
                column: "department_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "department");
        }
    }
}
