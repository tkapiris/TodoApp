using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.EF.Migrations
{
    public partial class AddFinsihedIndexToTodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_My_Finished",
                table: "Todo",
                column: "Finished");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_My_Finished",
                table: "Todo");
        }
    }
}
