using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionFlow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addbudgettoconstruction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Budget",
                table: "Construction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Budget",
                table: "Construction");
        }
    }
}
