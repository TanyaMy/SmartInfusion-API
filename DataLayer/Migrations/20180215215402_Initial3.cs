using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLayer.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_DiseaseHistories_DiseaseHistoryId1",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_DiseaseHistoryId1",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "DiseaseHistoryId1",
                table: "Treatments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DiseaseHistoryId1",
                table: "Treatments",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_DiseaseHistoryId1",
                table: "Treatments",
                column: "DiseaseHistoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_DiseaseHistories_DiseaseHistoryId1",
                table: "Treatments",
                column: "DiseaseHistoryId1",
                principalTable: "DiseaseHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
