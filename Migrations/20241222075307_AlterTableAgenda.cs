using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Testare_TravelingApp.Migrations
{
    /// <inheritdoc />
    public partial class AlterTableAgenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Agenda",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NatureTrailId",
                table: "Agenda",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Agenda",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TouristAttractionId",
                table: "Agenda",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_ActivityId",
                table: "Agenda",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_NatureTrailId",
                table: "Agenda",
                column: "NatureTrailId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_RestaurantId",
                table: "Agenda",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_TouristAttractionId",
                table: "Agenda",
                column: "TouristAttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Activity_ActivityId",
                table: "Agenda",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_NatureTrail_NatureTrailId",
                table: "Agenda",
                column: "NatureTrailId",
                principalTable: "NatureTrail",
                principalColumn: "NatureTrailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_Restaurant_RestaurantId",
                table: "Agenda",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agenda_TouristAttraction_TouristAttractionId",
                table: "Agenda",
                column: "TouristAttractionId",
                principalTable: "TouristAttraction",
                principalColumn: "TouristAttractionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Activity_ActivityId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_NatureTrail_NatureTrailId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_Restaurant_RestaurantId",
                table: "Agenda");

            migrationBuilder.DropForeignKey(
                name: "FK_Agenda_TouristAttraction_TouristAttractionId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_ActivityId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_NatureTrailId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_RestaurantId",
                table: "Agenda");

            migrationBuilder.DropIndex(
                name: "IX_Agenda_TouristAttractionId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "NatureTrailId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Agenda");

            migrationBuilder.DropColumn(
                name: "TouristAttractionId",
                table: "Agenda");
        }
    }
}
