using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniformSystem.Migrations
{
    /// <inheritdoc />
    public partial class ChangeToSnakeNaming : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_UniformCategory",
                table: "UniformCategory");

            migrationBuilder.RenameTable(
                name: "UniformCategory",
                newName: "tb_uniform_category");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "tb_user",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_user",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tb_user",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_user",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_user_Email",
                table: "tb_user",
                newName: "ix_tb_user_email");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "tb_uniforms_delivered",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_uniforms_delivered",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UniformId",
                table: "tb_uniforms_delivered",
                newName: "uniform_id");

            migrationBuilder.RenameColumn(
                name: "ToEmployeeId",
                table: "tb_uniforms_delivered",
                newName: "to_employee_id");

            migrationBuilder.RenameColumn(
                name: "DeliveredById",
                table: "tb_uniforms_delivered",
                newName: "delivered_by_id");

            migrationBuilder.RenameColumn(
                name: "DeliveredAt",
                table: "tb_uniforms_delivered",
                newName: "delivered_at");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniforms_delivered_UniformId",
                table: "tb_uniforms_delivered",
                newName: "ix_tb_uniforms_delivered_uniform_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniforms_delivered_ToEmployeeId",
                table: "tb_uniforms_delivered",
                newName: "ix_tb_uniforms_delivered_to_employee_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniforms_delivered_DeliveredById",
                table: "tb_uniforms_delivered",
                newName: "ix_tb_uniforms_delivered_delivered_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniforms_delivered_DeliveredAt",
                table: "tb_uniforms_delivered",
                newName: "ix_tb_uniforms_delivered_delivered_at");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "tb_uniform",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Sex",
                table: "tb_uniform",
                newName: "sex");

            migrationBuilder.RenameColumn(
                name: "Reference",
                table: "tb_uniform",
                newName: "reference");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_uniform",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_uniform",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UniformCategoryId",
                table: "tb_uniform",
                newName: "uniform_category_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniform_Sex",
                table: "tb_uniform",
                newName: "ix_tb_uniform_sex");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniform_Reference",
                table: "tb_uniform",
                newName: "ix_tb_uniform_reference");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniform_Name",
                table: "tb_uniform",
                newName: "ix_tb_uniform_name");

            migrationBuilder.RenameIndex(
                name: "IX_tb_uniform_UniformCategoryId",
                table: "tb_uniform",
                newName: "ix_tb_uniform_uniform_category_id");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "tb_inventory_logs",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_inventory_logs",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "tb_inventory_logs",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UniformId",
                table: "tb_inventory_logs",
                newName: "uniform_id");

            migrationBuilder.RenameColumn(
                name: "LogDate",
                table: "tb_inventory_logs",
                newName: "log_date");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_logs_UpdatedById",
                table: "tb_inventory_logs",
                newName: "ix_tb_inventory_logs_updated_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_logs_UniformId",
                table: "tb_inventory_logs",
                newName: "ix_tb_inventory_logs_uniform_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_logs_LogDate",
                table: "tb_inventory_logs",
                newName: "ix_tb_inventory_logs_log_date");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "tb_inventory",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_inventory",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedById",
                table: "tb_inventory",
                newName: "updated_by_id");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "tb_inventory",
                newName: "updated_at");

            migrationBuilder.RenameColumn(
                name: "UniformId",
                table: "tb_inventory",
                newName: "uniform_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_UpdatedById",
                table: "tb_inventory",
                newName: "ix_tb_inventory_updated_by_id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_UpdatedAt",
                table: "tb_inventory",
                newName: "ix_tb_inventory_updated_at");

            migrationBuilder.RenameIndex(
                name: "IX_tb_inventory_UniformId",
                table: "tb_inventory",
                newName: "ix_tb_inventory_uniform_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_employees",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "tb_employees",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_employees",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_tb_employees_Email",
                table: "tb_employees",
                newName: "ix_tb_employees_email");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tb_uniform_category",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tb_uniform_category",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "tb_uniform_category",
                type: "character varying(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tb_user",
                table: "tb_user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tb_uniforms_delivered",
                table: "tb_uniforms_delivered",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tb_uniform",
                table: "tb_uniform",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tb_inventory_logs",
                table: "tb_inventory_logs",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tb_inventory",
                table: "tb_inventory",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tb_employees",
                table: "tb_employees",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_tb_uniform_category",
                table: "tb_uniform_category",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_tb_inventory_tb_uniform_uniform_id",
                table: "tb_inventory",
                column: "uniform_id",
                principalTable: "tb_uniform",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tb_inventory_tb_user_updated_by_id",
                table: "tb_inventory",
                column: "updated_by_id",
                principalTable: "tb_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tb_inventory_logs_tb_uniform_uniform_id",
                table: "tb_inventory_logs",
                column: "uniform_id",
                principalTable: "tb_uniform",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tb_inventory_logs_tb_user_updated_by_id",
                table: "tb_inventory_logs",
                column: "updated_by_id",
                principalTable: "tb_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tb_uniform_uniform_category_uniform_category_id",
                table: "tb_uniform",
                column: "uniform_category_id",
                principalTable: "tb_uniform_category",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tb_uniforms_delivered_tb_employees_to_employee_id",
                table: "tb_uniforms_delivered",
                column: "to_employee_id",
                principalTable: "tb_employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tb_uniforms_delivered_tb_uniform_uniform_id",
                table: "tb_uniforms_delivered",
                column: "uniform_id",
                principalTable: "tb_uniform",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_tb_uniforms_delivered_tb_user_delivered_by_id",
                table: "tb_uniforms_delivered",
                column: "delivered_by_id",
                principalTable: "tb_user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_tb_inventory_tb_uniform_uniform_id",
                table: "tb_inventory");

            migrationBuilder.DropForeignKey(
                name: "fk_tb_inventory_tb_user_updated_by_id",
                table: "tb_inventory");

            migrationBuilder.DropForeignKey(
                name: "fk_tb_inventory_logs_tb_uniform_uniform_id",
                table: "tb_inventory_logs");

            migrationBuilder.DropForeignKey(
                name: "fk_tb_inventory_logs_tb_user_updated_by_id",
                table: "tb_inventory_logs");

            migrationBuilder.DropForeignKey(
                name: "fk_tb_uniform_uniform_category_uniform_category_id",
                table: "tb_uniform");

            migrationBuilder.DropForeignKey(
                name: "fk_tb_uniforms_delivered_tb_employees_to_employee_id",
                table: "tb_uniforms_delivered");

            migrationBuilder.DropForeignKey(
                name: "fk_tb_uniforms_delivered_tb_uniform_uniform_id",
                table: "tb_uniforms_delivered");

            migrationBuilder.DropForeignKey(
                name: "fk_tb_uniforms_delivered_tb_user_delivered_by_id",
                table: "tb_uniforms_delivered");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tb_user",
                table: "tb_user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tb_uniforms_delivered",
                table: "tb_uniforms_delivered");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tb_uniform",
                table: "tb_uniform");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tb_inventory_logs",
                table: "tb_inventory_logs");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tb_inventory",
                table: "tb_inventory");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tb_employees",
                table: "tb_employees");

            migrationBuilder.DropPrimaryKey(
                name: "pk_tb_uniform_category",
                table: "tb_uniform_category");

            migrationBuilder.RenameTable(
                name: "tb_uniform_category",
                newName: "UniformCategory");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "tb_user",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "tb_user",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "tb_user",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_user",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_tb_user_email",
                table: "tb_user",
                newName: "IX_tb_user_Email");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "tb_uniforms_delivered",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_uniforms_delivered",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "uniform_id",
                table: "tb_uniforms_delivered",
                newName: "UniformId");

            migrationBuilder.RenameColumn(
                name: "to_employee_id",
                table: "tb_uniforms_delivered",
                newName: "ToEmployeeId");

            migrationBuilder.RenameColumn(
                name: "delivered_by_id",
                table: "tb_uniforms_delivered",
                newName: "DeliveredById");

            migrationBuilder.RenameColumn(
                name: "delivered_at",
                table: "tb_uniforms_delivered",
                newName: "DeliveredAt");

            migrationBuilder.RenameIndex(
                name: "ix_tb_uniforms_delivered_uniform_id",
                table: "tb_uniforms_delivered",
                newName: "IX_tb_uniforms_delivered_UniformId");

            migrationBuilder.RenameIndex(
                name: "ix_tb_uniforms_delivered_to_employee_id",
                table: "tb_uniforms_delivered",
                newName: "IX_tb_uniforms_delivered_ToEmployeeId");

            migrationBuilder.RenameIndex(
                name: "ix_tb_uniforms_delivered_delivered_by_id",
                table: "tb_uniforms_delivered",
                newName: "IX_tb_uniforms_delivered_DeliveredById");

            migrationBuilder.RenameIndex(
                name: "ix_tb_uniforms_delivered_delivered_at",
                table: "tb_uniforms_delivered",
                newName: "IX_tb_uniforms_delivered_DeliveredAt");

            migrationBuilder.RenameColumn(
                name: "size",
                table: "tb_uniform",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "sex",
                table: "tb_uniform",
                newName: "Sex");

            migrationBuilder.RenameColumn(
                name: "reference",
                table: "tb_uniform",
                newName: "Reference");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "tb_uniform",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_uniform",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "uniform_category_id",
                table: "tb_uniform",
                newName: "UniformCategoryId");

            migrationBuilder.RenameIndex(
                name: "ix_tb_uniform_sex",
                table: "tb_uniform",
                newName: "IX_tb_uniform_Sex");

            migrationBuilder.RenameIndex(
                name: "ix_tb_uniform_reference",
                table: "tb_uniform",
                newName: "IX_tb_uniform_Reference");

            migrationBuilder.RenameIndex(
                name: "ix_tb_uniform_name",
                table: "tb_uniform",
                newName: "IX_tb_uniform_Name");

            migrationBuilder.RenameIndex(
                name: "ix_tb_uniform_uniform_category_id",
                table: "tb_uniform",
                newName: "IX_tb_uniform_UniformCategoryId");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "tb_inventory_logs",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_inventory_logs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                table: "tb_inventory_logs",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "uniform_id",
                table: "tb_inventory_logs",
                newName: "UniformId");

            migrationBuilder.RenameColumn(
                name: "log_date",
                table: "tb_inventory_logs",
                newName: "LogDate");

            migrationBuilder.RenameIndex(
                name: "ix_tb_inventory_logs_updated_by_id",
                table: "tb_inventory_logs",
                newName: "IX_tb_inventory_logs_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "ix_tb_inventory_logs_uniform_id",
                table: "tb_inventory_logs",
                newName: "IX_tb_inventory_logs_UniformId");

            migrationBuilder.RenameIndex(
                name: "ix_tb_inventory_logs_log_date",
                table: "tb_inventory_logs",
                newName: "IX_tb_inventory_logs_LogDate");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "tb_inventory",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_inventory",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "updated_by_id",
                table: "tb_inventory",
                newName: "UpdatedById");

            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "tb_inventory",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "uniform_id",
                table: "tb_inventory",
                newName: "UniformId");

            migrationBuilder.RenameIndex(
                name: "ix_tb_inventory_updated_by_id",
                table: "tb_inventory",
                newName: "IX_tb_inventory_UpdatedById");

            migrationBuilder.RenameIndex(
                name: "ix_tb_inventory_updated_at",
                table: "tb_inventory",
                newName: "IX_tb_inventory_UpdatedAt");

            migrationBuilder.RenameIndex(
                name: "ix_tb_inventory_uniform_id",
                table: "tb_inventory",
                newName: "IX_tb_inventory_UniformId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "tb_employees",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "tb_employees",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tb_employees",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "ix_tb_employees_email",
                table: "tb_employees",
                newName: "IX_tb_employees_Email");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "UniformCategory",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "UniformCategory",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "UniformCategory",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255);

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

            migrationBuilder.AddPrimaryKey(
                name: "PK_UniformCategory",
                table: "UniformCategory",
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
    }
}
