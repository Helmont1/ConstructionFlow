using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConstructionFlow.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addfieldsactivity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ActivityName",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Activity",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UsedMaterial",
                table: "Activity",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WastedMaterial",
                table: "Activity",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActivityName",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "UsedMaterial",
                table: "Activity");

            migrationBuilder.DropColumn(
                name: "WastedMaterial",
                table: "Activity");
        }
    }
}
