using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestMasterDetail.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "School",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_School", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SchoolId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Student_School_SchoolId",
                        column: x => x.SchoolId,
                        principalTable: "School",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "School 01" });

            migrationBuilder.InsertData(
                table: "School",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "School 02" });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 1, "Student 01", 1 });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 2, "Student 02", 2 });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Name", "SchoolId" },
                values: new object[] { 3, "Student 03", 2 });

            migrationBuilder.InsertData(
                table: "Pet",
                columns: new[] { "Id", "Name", "StudentId" },
                values: new object[,]
                {
                    { 1, "Pet 01", 1 },
                    { 2, "Pet 02", 1 },
                    { 3, "Pet 03", 2 },
                    { 4, "Pet 04", 2 },
                    { 5, "Pet 05", 3 },
                    { 6, "Pet 06", 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_StudentId",
                table: "Pet",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_SchoolId",
                table: "Student",
                column: "SchoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "School");
        }
    }
}
