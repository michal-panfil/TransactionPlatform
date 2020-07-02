using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TransactionPlatform.API.Migrations
{
    public partial class EntityRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    CreateDT = table.Column<DateTime>(nullable: false),
                    CloseDT = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletId);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstrumentId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    BuyPrice = table.Column<decimal>(nullable: false),
                    Volumen = table.Column<int>(nullable: false),
                    BuyDT = table.Column<DateTime>(nullable: false),
                    SaleDT = table.Column<DateTime>(nullable: true),
                    WalletId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medium",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Short = table.Column<string>(nullable: true),
                    RatioToBaseMedium = table.Column<float>(nullable: false),
                    AvailableAmount = table.Column<decimal>(nullable: false),
                    BlockedAmount = table.Column<decimal>(nullable: false),
                    LastChangeDt = table.Column<DateTime>(nullable: false),
                    WalletId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medium", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medium_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_WalletId",
                table: "Assets",
                column: "WalletId");

            migrationBuilder.CreateIndex(
                name: "IX_Medium_WalletId",
                table: "Medium",
                column: "WalletId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Medium");

            migrationBuilder.DropTable(
                name: "Wallets");
        }
    }
}
