using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Authentication.Infrastructure.DBContext.Migrations
{
    /// <inheritdoc />
    public partial class AuthenticationTableInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoginFailureCount = table.Column<int>(type: "int", nullable: false),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => x.LoginId);
                });

            migrationBuilder.CreateTable(
                name: "LoginStatus",
                columns: table => new
                {
                    LoginStatusId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LogoutDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LockId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginStatus", x => x.LoginStatusId);
                    table.ForeignKey(
                        name: "FK_LoginStatus_UserLogin_LoginId",
                        column: x => x.LoginId,
                        principalTable: "UserLogin",
                        principalColumn: "LoginId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoginStatus_LoginId",
                table: "LoginStatus",
                column: "LoginId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginStatus");

            migrationBuilder.DropTable(
                name: "UserLogin");
        }
    }
}
