using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lab_medicine_api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERSON",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GENDER = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIRTH_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PHONE_NUMBER = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERSON", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DOCTORS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    EDUCATIONAL_INSTITUTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CRM_UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CLINICAL_SPECIALIZATION = table.Column<int>(type: "int", nullable: false),
                    STATUS_IN_SYSTEM = table.Column<int>(type: "int", nullable: false),
                    APPOINTMENT_COUNT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DOCTORS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DOCTORS_PERSON_ID",
                        column: x => x.ID,
                        principalTable: "PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NURSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    EDUCATIONAL_INSTITUTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COFEN_UF = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NURSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NURSES_PERSON_ID",
                        column: x => x.ID,
                        principalTable: "PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PATIENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    EMERGENCY_CONTACT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ALLERGIES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SPECIFIC_CARE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    INSURANCE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ATTENDANCE_STATUS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APPOINTMENT_COUNT = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PATIENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PATIENTS_PERSON_ID",
                        column: x => x.ID,
                        principalTable: "PERSON",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "APPOINTMENTS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PATIENT = table.Column<int>(type: "int", nullable: false),
                    ID_DOCTOR = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoctorModelId = table.Column<int>(type: "int", nullable: true),
                    PatientModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPOINTMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPOINTMENTS_DOCTORS_DoctorModelId",
                        column: x => x.DoctorModelId,
                        principalTable: "DOCTORS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_APPOINTMENTS_PATIENTS_PatientModelId",
                        column: x => x.PatientModelId,
                        principalTable: "PATIENTS",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENTS_DoctorModelId",
                table: "APPOINTMENTS",
                column: "DoctorModelId");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENTS_PatientModelId",
                table: "APPOINTMENTS",
                column: "PatientModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APPOINTMENTS");

            migrationBuilder.DropTable(
                name: "NURSES");

            migrationBuilder.DropTable(
                name: "DOCTORS");

            migrationBuilder.DropTable(
                name: "PATIENTS");

            migrationBuilder.DropTable(
                name: "PERSON");
        }
    }
}
