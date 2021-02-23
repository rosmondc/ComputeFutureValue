using Microsoft.EntityFrameworkCore.Migrations;

namespace ComputeFutureValue.Api.Migrations
{
    public partial class InitialDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PresentValue = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    LowerBoundInterestRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    UpperBoundInterestRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    IncrementalRate = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Maturity = table.Column<int>(type: "int", nullable: false),
                    FutureValue = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceHistoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Histories_InvoiceHistoryId",
                        column: x => x.InvoiceHistoryId,
                        principalTable: "Histories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_InvoiceHistoryId",
                table: "Users",
                column: "InvoiceHistoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Histories");
        }
    }
}
