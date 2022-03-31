using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.EF.Migrations
{
    public partial class Add_TodoDetail_And_TodoComments_Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TodoComment",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    TodoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoComment_Todo_TodoId",
                        column: x => x.TodoId,
                        principalSchema: "App",
                        principalTable: "Todo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TodoDetail",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TodoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoDetail_Todo_TodoId",
                        column: x => x.TodoId,
                        principalSchema: "App",
                        principalTable: "Todo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoComment_TodoId",
                schema: "App",
                table: "TodoComment",
                column: "TodoId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoDetail_TodoId",
                schema: "App",
                table: "TodoDetail",
                column: "TodoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TodoComment",
                schema: "App");

            migrationBuilder.DropTable(
                name: "TodoDetail",
                schema: "App");
        }
    }
}
