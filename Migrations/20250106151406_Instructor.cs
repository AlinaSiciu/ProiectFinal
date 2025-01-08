using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProiectFinal.Migrations
{
    /// <inheritdoc />
    public partial class Instructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstructorID",
                table: "Cal",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cal_InstructorID",
                table: "Cal",
                column: "InstructorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cal_Instructor_InstructorID",
                table: "Cal",
                column: "InstructorID",
                principalTable: "Instructor",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cal_Instructor_InstructorID",
                table: "Cal");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropIndex(
                name: "IX_Cal_InstructorID",
                table: "Cal");

            migrationBuilder.DropColumn(
                name: "InstructorID",
                table: "Cal");
        }
    }
}
