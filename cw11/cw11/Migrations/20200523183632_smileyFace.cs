using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace cw11.Migrations
{
    public partial class smileyFace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Doctor",
                columns: table => new
                {
                    IdDoctor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Doctor_PK", x => x.IdDoctor);
                });

            migrationBuilder.CreateTable(
                name: "Medicament",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: false),
                    Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Medicament_PK", x => x.IdMedicament);
                });

            migrationBuilder.CreateTable(
                name: "Patient",
                columns: table => new
                {
                    IdPatient = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Patient_PK", x => x.IdPatient);
                });

            migrationBuilder.CreateTable(
                name: "Prescription",
                columns: table => new
                {
                    IdPrescription = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    IdPatient = table.Column<int>(nullable: false),
                    IdDoctor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Prescription_PK", x => x.IdPrescription);
                    table.ForeignKey(
                        name: "Prescription-Doctor",
                        column: x => x.IdDoctor,
                        principalTable: "Doctor",
                        principalColumn: "IdDoctor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Prescription-Patient",
                        column: x => x.IdPatient,
                        principalTable: "Patient",
                        principalColumn: "IdPatient",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresMedi",
                columns: table => new
                {
                    IdMedicament = table.Column<int>(nullable: false),
                    IdPrescription = table.Column<int>(nullable: false),
                    Dose = table.Column<int>(nullable: false),
                    Details = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresMedi", x => new { x.IdMedicament, x.IdPrescription });
                    table.ForeignKey(
                        name: "Medicament-Prescription_Medicament",
                        column: x => x.IdMedicament,
                        principalTable: "Medicament",
                        principalColumn: "IdMedicament",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Prescription_Prescription_Medicament",
                        column: x => x.IdPrescription,
                        principalTable: "Prescription",
                        principalColumn: "IdPrescription",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Doctor",
                columns: new[] { "IdDoctor", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "jsparrow@gmail.com", "Jacek", "Sieczko" },
                    { 2, "pjpyta@gmail.com", "Adam", "Brodka" },
                    { 3, "xhvqyo@gmail.com", "Adrian", "Bednarek" },
                    { 4, "no1special@gmail.com", "Filip", "Lysy" },
                    { 5, "logico@gmail.com", "Dominik", "Logiczny" }
                });

            migrationBuilder.InsertData(
                table: "Medicament",
                columns: new[] { "IdMedicament", "Description", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "2/10 too much water", "IGN", "rak" },
                    { 2, "bardzo smaczne", "Pawulon", "eutanazja" },
                    { 3, "meltuje glowe", "Krokodil", "drug" },
                    { 4, "j***e kawusie i bedzie git", "Kawusia", "kawusia" },
                    { 5, "smaczne", "Drink", "drug" }
                });

            migrationBuilder.InsertData(
                table: "Patient",
                columns: new[] { "IdPatient", "BirthDate", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 5, 23, 20, 36, 31, 958, DateTimeKind.Local).AddTicks(4020), "Jan", "Dzban" },
                    { 2, new DateTime(2020, 5, 23, 20, 36, 31, 961, DateTimeKind.Local).AddTicks(2736), "Michał", "RPG" },
                    { 3, new DateTime(2020, 5, 23, 20, 36, 31, 961, DateTimeKind.Local).AddTicks(2791), "Mirosław", "Wykop" },
                    { 4, new DateTime(2020, 5, 23, 20, 36, 31, 961, DateTimeKind.Local).AddTicks(2797), "Mirosława", "Wykop" },
                    { 5, new DateTime(2020, 5, 23, 20, 36, 31, 961, DateTimeKind.Local).AddTicks(2801), "imie5", "nazwisko5" }
                });

            migrationBuilder.InsertData(
                table: "Prescription",
                columns: new[] { "IdPrescription", "Date", "DueDate", "IdDoctor", "IdPatient" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 6, 13, 20, 36, 31, 965, DateTimeKind.Local).AddTicks(553), new DateTime(2020, 6, 29, 20, 36, 31, 965, DateTimeKind.Local).AddTicks(1109), 5, 1 },
                    { 2, new DateTime(2020, 6, 13, 20, 36, 31, 965, DateTimeKind.Local).AddTicks(2345), new DateTime(2020, 6, 29, 20, 36, 31, 965, DateTimeKind.Local).AddTicks(2364), 4, 2 },
                    { 3, new DateTime(2020, 6, 13, 20, 36, 31, 965, DateTimeKind.Local).AddTicks(2388), new DateTime(2020, 6, 29, 20, 36, 31, 965, DateTimeKind.Local).AddTicks(2391), 3, 3 },
                    { 4, new DateTime(2020, 6, 13, 20, 36, 31, 965, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 6, 29, 20, 36, 31, 965, DateTimeKind.Local).AddTicks(2398), 2, 4 },
                    { 5, new DateTime(2020, 6, 13, 20, 36, 31, 965, DateTimeKind.Local).AddTicks(2402), new DateTime(2020, 6, 29, 20, 36, 31, 965, DateTimeKind.Local).AddTicks(2405), 1, 5 }
                });

            migrationBuilder.InsertData(
                table: "PresMedi",
                columns: new[] { "IdMedicament", "IdPrescription", "Details", "Dose" },
                values: new object[,]
                {
                    { 5, 1, "cos", 5 },
                    { 4, 2, "cos", 1 },
                    { 3, 3, "cos", 12 },
                    { 2, 4, "cos", 1337 },
                    { 1, 5, "cos", 2137 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdDoctor",
                table: "Prescription",
                column: "IdDoctor");

            migrationBuilder.CreateIndex(
                name: "IX_Prescription_IdPatient",
                table: "Prescription",
                column: "IdPatient");

            migrationBuilder.CreateIndex(
                name: "IX_PresMedi_IdPrescription",
                table: "PresMedi",
                column: "IdPrescription");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresMedi");

            migrationBuilder.DropTable(
                name: "Medicament");

            migrationBuilder.DropTable(
                name: "Prescription");

            migrationBuilder.DropTable(
                name: "Doctor");

            migrationBuilder.DropTable(
                name: "Patient");
        }
    }
}
