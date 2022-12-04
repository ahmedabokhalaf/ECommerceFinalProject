using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITI.ElectroDev.Models.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_Category_Cat_Id",
                table: "Brand");

            migrationBuilder.RenameColumn(
                name: "Cat_Id",
                table: "Brand",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Brand_Cat_Id",
                table: "Brand",
                newName: "IX_Brand_CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_Category_CategoryId",
                table: "Brand",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brand_Category_CategoryId",
                table: "Brand");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Brand",
                newName: "Cat_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Brand_CategoryId",
                table: "Brand",
                newName: "IX_Brand_Cat_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brand_Category_Cat_Id",
                table: "Brand",
                column: "Cat_Id",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
