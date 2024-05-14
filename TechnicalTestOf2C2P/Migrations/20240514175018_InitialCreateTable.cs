using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnicalTestOf2C2P.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CurrencyMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(3)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "varchar(10)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "varchar(10)", nullable: true),
                    Output = table.Column<string>(type: "varchar(1)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "varchar(10)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Currency = table.Column<string>(type: "varchar(3)", nullable: true),
                    Status = table.Column<string>(type: "varchar(10)", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(type: "varchar(10)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    UpdatedBy = table.Column<string>(type: "varchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyMaster");

            migrationBuilder.DropTable(
                name: "StatusMaster");

            migrationBuilder.DropTable(
                name: "Transactions");
        }
    }
}
