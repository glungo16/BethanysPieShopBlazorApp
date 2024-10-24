using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BethanysPieShopBlazorApi.Migrations
{
    /// <inheritdoc />
    public partial class testingSecrets5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobCategories_JobCategoryId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCategories",
                table: "JobCategories");

            migrationBuilder.RenameTable(
                name: "JobCategories",
                newName: "JobCategory");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCategory",
                table: "JobCategory",
                column: "JobCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobCategory_JobCategoryId",
                table: "Employees",
                column: "JobCategoryId",
                principalTable: "JobCategory",
                principalColumn: "JobCategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_JobCategory_JobCategoryId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobCategory",
                table: "JobCategory");

            migrationBuilder.RenameTable(
                name: "JobCategory",
                newName: "JobCategories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobCategories",
                table: "JobCategories",
                column: "JobCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_JobCategories_JobCategoryId",
                table: "Employees",
                column: "JobCategoryId",
                principalTable: "JobCategories",
                principalColumn: "JobCategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
