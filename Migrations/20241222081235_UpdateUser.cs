using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Testare_TravelingApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Activity_ActivityId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_NatureTrail_NatureTrailId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Restaurant_RestaurantId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_TouristAttraction_TouristAttractionId",
                table: "Review");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Activity_ActivityId",
                table: "Review",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "ActivityId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_NatureTrail_NatureTrailId",
                table: "Review",
                column: "NatureTrailId",
                principalTable: "NatureTrail",
                principalColumn: "NatureTrailId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Restaurant_RestaurantId",
                table: "Review",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Review_TouristAttraction_TouristAttractionId",
                table: "Review",
                column: "TouristAttractionId",
                principalTable: "TouristAttraction",
                principalColumn: "TouristAttractionId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Review_Activity_ActivityId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_NatureTrail_NatureTrailId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_Restaurant_RestaurantId",
                table: "Review");

            migrationBuilder.DropForeignKey(
                name: "FK_Review_TouristAttraction_TouristAttractionId",
                table: "Review");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Activity_ActivityId",
                table: "Review",
                column: "ActivityId",
                principalTable: "Activity",
                principalColumn: "ActivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_NatureTrail_NatureTrailId",
                table: "Review",
                column: "NatureTrailId",
                principalTable: "NatureTrail",
                principalColumn: "NatureTrailId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_Restaurant_RestaurantId",
                table: "Review",
                column: "RestaurantId",
                principalTable: "Restaurant",
                principalColumn: "RestaurantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Review_TouristAttraction_TouristAttractionId",
                table: "Review",
                column: "TouristAttractionId",
                principalTable: "TouristAttraction",
                principalColumn: "TouristAttractionId");
        }
    }
}
