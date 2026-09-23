using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace UniformSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UniformCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniformCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uniform",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Reference = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<char>(type: "character(1)", nullable: false),
                    Size = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    UniformCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uniform", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Uniform_UniformCategory_UniformCategoryId",
                        column: x => x.UniformCategoryId,
                        principalTable: "UniformCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniformId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    UpdatedById = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Uniform_UniformId",
                        column: x => x.UniformId,
                        principalTable: "Uniform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inventory_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniformId = table.Column<int>(type: "integer", nullable: false),
                    UpdatedById = table.Column<int>(type: "integer", nullable: false),
                    LogDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryLogs_Uniform_UniformId",
                        column: x => x.UniformId,
                        principalTable: "Uniform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLogs_User_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UniformDelivered",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UniformId = table.Column<int>(type: "integer", nullable: false),
                    ToEmployeeId = table.Column<int>(type: "integer", nullable: false),
                    DeliveredById = table.Column<int>(type: "integer", nullable: false),
                    DeliveredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    Amount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniformDelivered", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UniformDelivered_Employee_ToEmployeeId",
                        column: x => x.ToEmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniformDelivered_Uniform_UniformId",
                        column: x => x.UniformId,
                        principalTable: "Uniform",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UniformDelivered_User_DeliveredById",
                        column: x => x.DeliveredById,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Email",
                table: "Employee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_UniformId",
                table: "Inventory",
                column: "UniformId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_UpdatedAt",
                table: "Inventory",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_UpdatedById",
                table: "Inventory",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_LogDate",
                table: "InventoryLogs",
                column: "LogDate");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_UniformId",
                table: "InventoryLogs",
                column: "UniformId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_UpdatedById",
                table: "InventoryLogs",
                column: "UpdatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Uniform_Name",
                table: "Uniform",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Uniform_Reference",
                table: "Uniform",
                column: "Reference",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uniform_Sex",
                table: "Uniform",
                column: "Sex");

            migrationBuilder.CreateIndex(
                name: "IX_Uniform_UniformCategoryId",
                table: "Uniform",
                column: "UniformCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UniformDelivered_DeliveredAt",
                table: "UniformDelivered",
                column: "DeliveredAt");

            migrationBuilder.CreateIndex(
                name: "IX_UniformDelivered_DeliveredById",
                table: "UniformDelivered",
                column: "DeliveredById");

            migrationBuilder.CreateIndex(
                name: "IX_UniformDelivered_ToEmployeeId",
                table: "UniformDelivered",
                column: "ToEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_UniformDelivered_UniformId",
                table: "UniformDelivered",
                column: "UniformId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "InventoryLogs");

            migrationBuilder.DropTable(
                name: "UniformDelivered");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Uniform");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UniformCategory");
        }
    }
}
