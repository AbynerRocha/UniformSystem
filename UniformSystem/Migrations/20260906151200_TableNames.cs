using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniformSystem.Migrations
{
    /// <inheritdoc />
    public partial class TableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Uniform_UniformId",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_User_UpdatedById",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogs_Uniform_UniformId",
                table: "InventoryLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_InventoryLogs_User_UpdatedById",
                table: "InventoryLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Uniform_UniformCategory_UniformCategoryId",
                table: "Uniform");

            migrationBuilder.DropForeignKey(
                name: "FK_UniformDelivered_Employee_ToEmployeeId",
                table: "UniformDelivered");

            migrationBuilder.DropForeignKey(
                name: "FK_UniformDelivered_Uniform_UniformId",
                table: "UniformDelivered");

            migrationBuilder.DropForeignKey(
                name: "FK_UniformDelivered_User_DeliveredById",
                table: "UniformDelivered");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UniformDelivered",
                table: "UniformDelivered");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Uniform",
                table: "Uniform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InventoryLogs",
                table: "InventoryLogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "tb_user");

            migrationBuilder.RenameTable(
                name: "UniformDelivered",
                newName: "tb_uniforms_delivered");

            migrationBuilder.RenameTable(
                name: "Uniform",
                newName: "tb_uniform");

            migrationBuilder.RenameTable(
                name: "InventoryLogs",
                newName: "tb_inventory_logs");

            migrationBuilder.RenameTable(
                name: "Inventory",
                newName: "tb_inventory");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "tb_employees");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "UniformCategory",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UniformCategory",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_User_Email",
                table: "tb_user",
                newName: "IX_tb_user_Email");

            migrationBuilder.RenameIndex(
                name: "IX_UniformDelivered_UniformId",
                table: "tb_uniforms_delivered",
                newName: "IX_tb_uniforms_delivered_UniformId");

            migrationBuilder.RenameIndex(
                name: "IX_UniformDelivered_ToEmployeeId",
                table: "tb_uniforms_delivered",
                newName: "IX_tb_uniforms_delivered_ToEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_UniformDelivered_DeliveredById",
                table: "tb_uniforms_delivered",
                newName: "IX_tb_uniforms_delivered_DeliveredById");

            migrationBuilder.RenameIndex(
                name: "IX_UniformDelivered_DeliveredAt",
                table: "tb_uniforms_delivered",
                newName: "IX_tb_uniforms_delivered_DeliveredAt");

            migrationBuilder.RenameIndex(
                name: "IX_Uniform_UniformCategoryId",
                table: "tb_uniform",
                newName: "IX_tb_uniform_UniformCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Uniform_Sex",
                table: "tb_uniform",
                newName: "IX_tb_uniform_Sex");

            migrationBuilder.RenameIndex(
                name: "IX_Uniform_Reference",
                table: "tb_uniform",
                newName: "IX_tb_uniform_Reference");

            migrationBuilder.RenameIndex(
                name: "IX_Uniform_Name",
                table: "tb_uniform",
                newName: "IX_tb_uniform_Name");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLogs_UpdatedById",
                table: "tb_inventory_logs",
                newName: "IX_tb_inventory_logs_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLogs_UniformId",
                table: "tb_inventory_logs",
                newName: "IX_tb_inventory_logs_UniformId");

            migrationBuilder.RenameIndex(
                name: "IX_InventoryLogs_LogDate",
                table: "tb_inventory_logs",
                newName: "IX_tb_inventory_logs_LogDate");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_UpdatedById",
                table: "tb_inventory",
                newName: "IX_tb_inventory_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_UpdatedAt",
                table: "tb_inventory",
                newName: "IX_tb_inventory_UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_UniformId",
                table: "tb_inventory",
                newName: "IX_tb_inventory_UniformId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_Email",
                table: "tb_employees",
                newName: "IX_tb_employees_Email");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "tb_employees",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "tb_employees",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_uniforms_delivered",
                table: "tb_uniforms_delivered",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_uniform",
                table: "tb_uniform",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_inventory_logs",
                table: "tb_inventory_logs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_inventory",
                table: "tb_inventory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tb_employees",
                table: "tb_employees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_inventory_tb_uniform_UniformId",
                table: "tb_inventory",
                column: "UniformId",
                principalTable: "tb_uniform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_inventory_tb_user_UpdatedById",
                table: "tb_inventory",
                column: "UpdatedById",
                principalTable: "tb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_inventory_logs_tb_uniform_UniformId",
                table: "tb_inventory_logs",
                column: "UniformId",
                principalTable: "tb_uniform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_inventory_logs_tb_user_UpdatedById",
                table: "tb_inventory_logs",
                column: "UpdatedById",
                principalTable: "tb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_uniform_UniformCategory_UniformCategoryId",
                table: "tb_uniform",
                column: "UniformCategoryId",
                principalTable: "UniformCategory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_uniforms_delivered_tb_employees_ToEmployeeId",
                table: "tb_uniforms_delivered",
                column: "ToEmployeeId",
                principalTable: "tb_employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_uniforms_delivered_tb_uniform_UniformId",
                table: "tb_uniforms_delivered",
                column: "UniformId",
                principalTable: "tb_uniform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_uniforms_delivered_tb_user_DeliveredById",
                table: "tb_uniforms_delivered",
                column: "DeliveredById",
                principalTable: "tb_user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_inventory_tb_uniform_UniformId",
                table: "tb_inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_inventory_tb_user_UpdatedById",
                table: "tb_inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_inventory_logs_tb_uniform_UniformId",
                table: "tb_inventory_logs");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_inventory_logs_tb_user_UpdatedById",
                table: "tb_inventory_logs");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_uniform_UniformCategory_UniformCategoryId",
                table: "tb_uniform");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_uniforms_delivered_tb_employees_ToEmployeeId",
                table: "tb_uniforms_delivered");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_uniforms_delivered_tb_uniform_UniformId",
                table: "tb_uniforms_delivered");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_uniforms_delivered_tb_user_DeliveredById",
                table: "tb_uniforms_delivered");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_user",
                table: "tb_user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_uniforms_delivered",
                table: "tb_uniforms_delivered");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_uniform",
                table: "tb_uniform");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_inventory_logs",
                table: "tb_inventory_logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_inventory",
                table: "tb_inventory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tb_employees",
                table: "tb_employees");

            migrationBuilder.RenameTable(
                name: "tb_user",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "tb_uniforms_delivered",
                newName: "UniformDelivered");

            migrationBuilder.RenameTable(
                name: "tb_uniform",
                newName: "Uniform");

            migrationBuilder.RenameTable(
                name: "tb_inventory_logs",
                newName: "InventoryLogs");

            migrationBuilder.RenameTable(
                name: "tb_inventory",
                newName: "Inventory");

            migrationBuilder.RenameTable(
                name: "tb_employees",
                newName: "Employee");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UniformCategory",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UniformCategory",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_user_Email",
                table: "User",
                newName: "IX_User_Email");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniforms_delivered_UniformId",
                table: "UniformDelivered",
                newName: "IX_UniformDelivered_UniformId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniforms_delivered_ToEmployeeId",
                table: "UniformDelivered",
                newName: "IX_UniformDelivered_ToEmployeeId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniforms_delivered_DeliveredById",
                table: "UniformDelivered",
                newName: "IX_UniformDelivered_DeliveredById");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniforms_delivered_DeliveredAt",
                table: "UniformDelivered",
                newName: "IX_UniformDelivered_DeliveredAt");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniform_UniformCategoryId",
                table: "Uniform",
                newName: "IX_Uniform_UniformCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniform_Sex",
                table: "Uniform",
                newName: "IX_Uniform_Sex");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniform_Reference",
                table: "Uniform",
                newName: "IX_Uniform_Reference");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniform_Name",
                table: "Uniform",
                newName: "IX_Uniform_Name");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_logs_UpdatedById",
                table: "InventoryLogs",
                newName: "IX_InventoryLogs_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_logs_UniformId",
                table: "InventoryLogs",
                newName: "IX_InventoryLogs_UniformId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_logs_LogDate",
                table: "InventoryLogs",
                newName: "IX_InventoryLogs_LogDate");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_UpdatedById",
                table: "Inventory",
                newName: "IX_Inventory_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_UpdatedAt",
                table: "Inventory",
                newName: "IX_Inventory_UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_UniformId",
                table: "Inventory",
                newName: "IX_Inventory_UniformId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_employees_Email",
                table: "Employee",
                newName: "IX_Employee_Email");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employee",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Employee",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UniformDelivered",
                table: "UniformDelivered",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Uniform",
                table: "Uniform",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InventoryLogs",
                table: "InventoryLogs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                table: "Inventory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Uniform_UniformId",
                table: "Inventory",
                column: "UniformId",
                principalTable: "Uniform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_User_UpdatedById",
                table: "Inventory",
                column: "UpdatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogs_Uniform_UniformId",
                table: "InventoryLogs",
                column: "UniformId",
                principalTable: "Uniform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryLogs_User_UpdatedById",
                table: "InventoryLogs",
                column: "UpdatedById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uniform_UniformCategory_UniformCategoryId",
                table: "Uniform",
                column: "UniformCategoryId",
                principalTable: "UniformCategory",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniformDelivered_Employee_ToEmployeeId",
                table: "UniformDelivered",
                column: "ToEmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniformDelivered_Uniform_UniformId",
                table: "UniformDelivered",
                column: "UniformId",
                principalTable: "Uniform",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UniformDelivered_User_DeliveredById",
                table: "UniformDelivered",
                column: "DeliveredById",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
