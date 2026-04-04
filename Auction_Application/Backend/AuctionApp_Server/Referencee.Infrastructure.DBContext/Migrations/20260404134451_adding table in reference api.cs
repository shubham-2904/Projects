using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reference.Infrastructure.DBContext.Migrations
{
    /// <inheritdoc />
    public partial class addingtableinreferenceapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionHouse_User_OwnerUserId",
                table: "AuctionHouse");

            migrationBuilder.CreateTable(
                name: "AuctionEvent",
                columns: table => new
                {
                    AuctionEventId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionHouseId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizerId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualEndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionEvent", x => x.AuctionEventId);
                    table.ForeignKey(
                        name: "FK_AuctionEvent_AuctionHouse_ActionHouseId",
                        column: x => x.ActionHouseId,
                        principalTable: "AuctionHouse",
                        principalColumn: "AuctionHouseId");
                    table.ForeignKey(
                        name: "FK_AuctionEvent_User_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "AuctionItem",
                columns: table => new
                {
                    AuctionItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuctionHouseId = table.Column<long>(type: "bigint", nullable: true),
                    Category = table.Column<short>(type: "smallint", nullable: true),
                    count = table.Column<int>(type: "int", nullable: false),
                    BuyPrice = table.Column<decimal>(type: "decimal(24,9)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionItem", x => x.AuctionItemId);
                    table.ForeignKey(
                        name: "FK_AuctionItem_AuctionHouse_AuctionHouseId",
                        column: x => x.AuctionHouseId,
                        principalTable: "AuctionHouse",
                        principalColumn: "AuctionHouseId");
                });

            migrationBuilder.CreateTable(
                name: "AuctionParticipant",
                columns: table => new
                {
                    AuctionParticipantId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionEventId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionParticipant", x => x.AuctionParticipantId);
                    table.ForeignKey(
                        name: "FK_AuctionParticipant_AuctionEvent_AuctionEventId",
                        column: x => x.AuctionEventId,
                        principalTable: "AuctionEvent",
                        principalColumn: "AuctionEventId");
                    table.ForeignKey(
                        name: "FK_AuctionParticipant_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuctionEvent_ActionHouseId",
                table: "AuctionEvent",
                column: "ActionHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionEvent_OrganizerId",
                table: "AuctionEvent",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionItem_AuctionHouseId",
                table: "AuctionItem",
                column: "AuctionHouseId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionParticipant_AuctionEventId",
                table: "AuctionParticipant",
                column: "AuctionEventId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionParticipant_UserId",
                table: "AuctionParticipant",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionHouse_User_OwnerUserId",
                table: "AuctionHouse",
                column: "OwnerUserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AuctionHouse_User_OwnerUserId",
                table: "AuctionHouse");

            migrationBuilder.DropTable(
                name: "AuctionItem");

            migrationBuilder.DropTable(
                name: "AuctionParticipant");

            migrationBuilder.DropTable(
                name: "AuctionEvent");

            migrationBuilder.AddForeignKey(
                name: "FK_AuctionHouse_User_OwnerUserId",
                table: "AuctionHouse",
                column: "OwnerUserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
