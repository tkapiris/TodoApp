using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApp.EF.Migrations
{
    public partial class AddedCommenterEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoDetail_Todo_TodoId",
                schema: "App",
                table: "TodoDetail");

            migrationBuilder.AddColumn<int>(
                name: "CommenterId",
                schema: "App",
                table: "TodoComment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Commenter",
                schema: "App",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commenter", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TodoComment_CommenterId",
                schema: "App",
                table: "TodoComment",
                column: "CommenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoComment_Commenter_CommenterId",
                schema: "App",
                table: "TodoComment",
                column: "CommenterId",
                principalSchema: "App",
                principalTable: "Commenter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoDetail_Todo_TodoId",
                schema: "App",
                table: "TodoDetail",
                column: "TodoId",
                principalSchema: "App",
                principalTable: "Todo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoComment_Commenter_CommenterId",
                schema: "App",
                table: "TodoComment");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoDetail_Todo_TodoId",
                schema: "App",
                table: "TodoDetail");

            migrationBuilder.DropTable(
                name: "Commenter",
                schema: "App");

            migrationBuilder.DropIndex(
                name: "IX_TodoComment_CommenterId",
                schema: "App",
                table: "TodoComment");

            migrationBuilder.DropColumn(
                name: "CommenterId",
                schema: "App",
                table: "TodoComment");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoDetail_Todo_TodoId",
                schema: "App",
                table: "TodoDetail",
                column: "TodoId",
                principalSchema: "App",
                principalTable: "Todo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
