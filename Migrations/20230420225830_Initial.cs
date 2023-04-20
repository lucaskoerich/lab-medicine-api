using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                    CPF = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    ATTENDANCE_STATUS = table.Column<int>(type: "int", nullable: false),
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
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APPOINTMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_APPOINTMENTS_DOCTORS_ID_DOCTOR",
                        column: x => x.ID_DOCTOR,
                        principalTable: "DOCTORS",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_APPOINTMENTS_PATIENTS_ID_PATIENT",
                        column: x => x.ID_PATIENT,
                        principalTable: "PATIENTS",
                        principalColumn: "ID");
                });

            migrationBuilder.InsertData(
                table: "PERSON",
                columns: new[] { "ID", "BIRTH_DATE", "CPF", "GENDER", "NAME", "PHONE_NUMBER" },
                values: new object[,]
                {
                    { 1, new DateTime(1985, 10, 15, 22, 15, 58, 0, DateTimeKind.Unspecified), "12874145871", "Masculino", "João Silva", "91986850045" },
                    { 2, new DateTime(1990, 5, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "65587414544", "Feminino", "Maria Santos", "11987654322" },
                    { 3, new DateTime(1982, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "88748739057", "Feminino", "Ana Paula Oliveira", "11991234567" },
                    { 4, new DateTime(1975, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "20070117004", "Masculino", "José da Silva", "21998765432" },
                    { 5, new DateTime(1995, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "94942452023", "Feminino", "Ana Souza", "21987654321" },
                    { 6, new DateTime(1970, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "29061208041", "Masculino", "Pedro Oliveira", "31987654321" },
                    { 7, new DateTime(1995, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "54175182047", "Feminino", "Fernanda Oliveira", "81991234567" },
                    { 8, new DateTime(1980, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "44849054005", "Masculino", "Pedro Henrique Souza", "31991234567" },
                    { 9, new DateTime(1992, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "87427425014", "Feminino", "Sandra Silva", "21991234567" },
                    { 10, new DateTime(1997, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "98257694088", "Feminino", "Maria Joaquina", "31987654321" },
                    { 11, new DateTime(1980, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "60544567099", "Masculino", "Carlos Silva Antunes", "71997437590" },
                    { 12, new DateTime(1985, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "26534267063", "Feminino", "Maria Souza", "27997538253" },
                    { 13, new DateTime(1990, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "89924802020", "Feminino", "Julia Silva", "92993448986" },
                    { 14, new DateTime(1985, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "61385125020", "Masculino", "Gabriel Santos", "41994623474" }
                });

            migrationBuilder.InsertData(
                table: "DOCTORS",
                columns: new[] { "ID", "APPOINTMENT_COUNT", "CLINICAL_SPECIALIZATION", "CRM_UF", "EDUCATIONAL_INSTITUTION", "STATUS_IN_SYSTEM" },
                values: new object[,]
                {
                    { 11, 5, 0, "87458/SC", "Universidade de São Paulo", 0 },
                    { 12, 10, 6, "14785/SC", "Universidade Federal do Rio de Janeiro", 0 }
                });

            migrationBuilder.InsertData(
                table: "NURSES",
                columns: new[] { "ID", "COFEN_UF", "EDUCATIONAL_INSTITUTION" },
                values: new object[,]
                {
                    { 13, "123456/SP", "Escola de Enfermagem da Universidade de São Paulo" },
                    { 14, "654321/RJ", "Escola de Enfermagem da Universidade Federal do Rio de Janeiro" }
                });

            migrationBuilder.InsertData(
                table: "PATIENTS",
                columns: new[] { "ID", "ALLERGIES", "APPOINTMENT_COUNT", "ATTENDANCE_STATUS", "EMERGENCY_CONTACT", "INSURANCE", "SPECIFIC_CARE" },
                values: new object[,]
                {
                    { 1, "[\"Amendoim\",\"Aspirina\"]", 2, 2, "91365777069", "Amil", "[\"Hipertensão\"]" },
                    { 2, "[\"Leite\",\"Penicilina\"]", 1, 1, "69992556682", "Unimed", "[\"Diabetes\"]" },
                    { 3, "[\"Frutos do mar\",\"Glúten\"]", 3, 2, "11987654321", "Bradesco Saúde", "[\"Asma\"]" },
                    { 4, "[\"Abacaxi\",\"Ibuprofeno\"]", 2, 2, "21987654321", "SulAmérica Saúde", "[\"Pressão alta\"]" },
                    { 5, "[\"Ampicilina\",\"Abacaxi\"]", 1, 0, "21976453627", "Bradesco Saúde", "[\"Asma\"]" },
                    { 6, "[\"Frutos do mar\",\"Cacau\"]", 0, 0, "31974563215", "SulAmérica", "[\"Colesterol alto\"]" },
                    { 7, "[\"Nozes\",\"Leite\"]", 1, 1, "81987654321", "Golden Cross", "[\"Depressão\"]" },
                    { 8, "[\"Poeira\",\"Camarão\"]", 1, 0, "31987654321", "Amil", "[\"Diabetes\"]" },
                    { 9, "[\"Amendoim\",\"Aspirina\"]", 2, 2, "21987654321", "Unimed", "[\"Hipertensão\"]" },
                    { 10, "[\"Amendoim\",\"Lactose\"]", 0, 0, "31998765432", "Golden Cross", "[\"Asma\"]" }
                });

            migrationBuilder.InsertData(
                table: "APPOINTMENTS",
                columns: new[] { "ID", "DESCRIPTION", "ID_DOCTOR", "ID_PATIENT" },
                values: new object[,]
                {
                    { 1, "Consulta de rotina", 11, 1 },
                    { 2, "Exame de sangue", 12, 1 },
                    { 3, "Consulta de rotina", 11, 2 },
                    { 4, "Consulta de rotina", 12, 3 },
                    { 5, "Acompanhamento nutricional", 11, 3 },
                    { 6, "Consulta de alergia", 11, 3 },
                    { 7, "Consulta de rotina", 12, 4 },
                    { 8, "Consulta para avaliação cardíaca", 12, 4 },
                    { 9, "Consulta de rotina", 12, 5 },
                    { 10, "Consulta de rotina", 11, 7 },
                    { 11, "Consulta de rotina", 12, 8 },
                    { 12, "Consulta de rotina", 11, 9 },
                    { 13, "Exame de sangue", 12, 9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENTS_ID_DOCTOR",
                table: "APPOINTMENTS",
                column: "ID_DOCTOR");

            migrationBuilder.CreateIndex(
                name: "IX_APPOINTMENTS_ID_PATIENT",
                table: "APPOINTMENTS",
                column: "ID_PATIENT");

            migrationBuilder.CreateIndex(
                name: "IX_PERSON_CPF",
                table: "PERSON",
                column: "CPF",
                unique: true);
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
