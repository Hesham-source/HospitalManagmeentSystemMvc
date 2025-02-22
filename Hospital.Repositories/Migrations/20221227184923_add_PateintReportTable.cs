using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Repositories.Migrations
{
    public partial class add_PateintReportTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientReport_AspNetUsers_DoctorId",
                table: "PatientReport");

            migrationBuilder.DropForeignKey(
                name: "FK_PatientReport_AspNetUsers_PatientId",
                table: "PatientReport");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedMedicines_PatientReport_PatientReportId",
                table: "PrescribedMedicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PatientReport",
                table: "PatientReport");

            migrationBuilder.RenameTable(
                name: "PatientReport",
                newName: "patientReports");

            migrationBuilder.RenameIndex(
                name: "IX_PatientReport_PatientId",
                table: "patientReports",
                newName: "IX_patientReports_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_PatientReport_DoctorId",
                table: "patientReports",
                newName: "IX_patientReports_DoctorId");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "patientReports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "patientReports",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_patientReports",
                table: "patientReports",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_patientReports_AspNetUsers_DoctorId",
                table: "patientReports",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_patientReports_AspNetUsers_PatientId",
                table: "patientReports",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedMedicines_patientReports_PatientReportId",
                table: "PrescribedMedicines",
                column: "PatientReportId",
                principalTable: "patientReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patientReports_AspNetUsers_DoctorId",
                table: "patientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_patientReports_AspNetUsers_PatientId",
                table: "patientReports");

            migrationBuilder.DropForeignKey(
                name: "FK_PrescribedMedicines_patientReports_PatientReportId",
                table: "PrescribedMedicines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patientReports",
                table: "patientReports");

            migrationBuilder.RenameTable(
                name: "patientReports",
                newName: "PatientReport");

            migrationBuilder.RenameIndex(
                name: "IX_patientReports_PatientId",
                table: "PatientReport",
                newName: "IX_PatientReport_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_patientReports_DoctorId",
                table: "PatientReport",
                newName: "IX_PatientReport_DoctorId");

            migrationBuilder.AlterColumn<string>(
                name: "PatientId",
                table: "PatientReport",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DoctorId",
                table: "PatientReport",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PatientReport",
                table: "PatientReport",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReport_AspNetUsers_DoctorId",
                table: "PatientReport",
                column: "DoctorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PatientReport_AspNetUsers_PatientId",
                table: "PatientReport",
                column: "PatientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_PrescribedMedicines_PatientReport_PatientReportId",
                table: "PrescribedMedicines",
                column: "PatientReportId",
                principalTable: "PatientReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
