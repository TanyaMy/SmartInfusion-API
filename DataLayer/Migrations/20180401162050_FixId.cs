using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace DataLayer.Migrations
{
    public partial class FixId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Medicines_MedicineId",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Metrics",
                table: "Metrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "TreatmentId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "MetricsId",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "MedicineId",
                table: "Medicines");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Treatments",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Metrics",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Medicines",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Metrics",
                table: "Metrics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Medicines_MedicineId",
                table: "Treatments",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_Medicines_MedicineId",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Metrics",
                table: "Metrics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Metrics");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Medicines");

            migrationBuilder.AddColumn<int>(
                name: "TreatmentId",
                table: "Treatments",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "MetricsId",
                table: "Metrics",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "MedicineId",
                table: "Medicines",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Treatments",
                table: "Treatments",
                column: "TreatmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Metrics",
                table: "Metrics",
                column: "MetricsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medicines",
                table: "Medicines",
                column: "MedicineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_Medicines_MedicineId",
                table: "Treatments",
                column: "MedicineId",
                principalTable: "Medicines",
                principalColumn: "MedicineId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
