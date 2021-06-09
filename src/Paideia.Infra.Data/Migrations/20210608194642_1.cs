using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paideia.Infra.Data.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "Candidate",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFromIBPV = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShepherdOrMissionary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpouseTraining = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateInscription = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Church = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fone = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Cell = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoneComercial = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Candidate_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Candidate_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

         

            migrationBuilder.CreateTable(
                name: "CandidateStatus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CandidateId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandidateStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CandidateStatus_Candidate_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandidateStatus_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

          

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_StatusId",
                table: "Candidate",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_TrainingId",
                table: "Candidate",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateStatus_CandidateId",
                table: "CandidateStatus",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_CandidateStatus_StatusId",
                table: "CandidateStatus",
                column: "StatusId");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropTable(
                name: "CandidateStatus");


            migrationBuilder.DropTable(
                name: "Candidate");

           
        }
    }
}
