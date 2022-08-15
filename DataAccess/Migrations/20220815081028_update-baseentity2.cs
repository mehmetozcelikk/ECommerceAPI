using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class updatebaseentity2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Products",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Products",
                newName: "CreateDate");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "ProductCategories",
                newName: "UpdateDate");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "ProductCategories",
                newName: "CreateDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "Products",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Products",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "UpdateDate",
                table: "ProductCategories",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "ProductCategories",
                newName: "EndDate");
        }
    }
}
