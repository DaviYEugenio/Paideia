using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Paideia.Infra.Data.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Candidate_Status_StatusId",
                table: "Candidate");

            migrationBuilder.DropIndex(
                name: "IX_Candidate_StatusId",
                table: "Candidate");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Candidate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StatusId",
                table: "Candidate",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Candidate_StatusId",
                table: "Candidate",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Candidate_Status_StatusId",
                table: "Candidate",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
