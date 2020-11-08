using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaskManagmentSystem.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    CategoryName = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Categori__19093A0B9225BBE9", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false),
                    Subject = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    CreateTime = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    StartDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    DueDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    CompletedDate = table.Column<DateTime>(type: "smalldatetime", nullable: true),
                    Complete = table.Column<bool>(nullable: false),
                    Importance = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tasks__7C6949B17703985F", x => x.TaskId);
                });

            migrationBuilder.CreateTable(
                name: "TasksCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: true),
                    TaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__TasksCate__Categ__276EDEB3",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__TasksCate__TaskI__286302EC",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TasksCategories_CategoryId",
                table: "TasksCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_TasksCategories_TaskId",
                table: "TasksCategories",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TasksCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Tasks");
        }
    }
}
