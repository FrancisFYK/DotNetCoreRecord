using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNetCoreRecord.Migrations
{
    public partial class AddId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persions",
                table: "Persions");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Persions");

            migrationBuilder.AddColumn<int>(
                name: "PersionId",
                table: "Persions",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persions",
                table: "Persions",
                column: "PersionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Persions",
                table: "Persions");

            migrationBuilder.DropColumn(
                name: "PersionId",
                table: "Persions");

            migrationBuilder.AddColumn<long>(
                name: "Id",
                table: "Persions",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persions",
                table: "Persions",
                column: "Id");
        }
    }
}
