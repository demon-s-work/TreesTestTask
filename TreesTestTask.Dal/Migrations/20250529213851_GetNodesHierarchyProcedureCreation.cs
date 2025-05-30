using Microsoft.EntityFrameworkCore.Migrations;
using TreesTestTask.Migrations.Resources;

#nullable disable

namespace TreesTestTask.Migrations.Migrations
{
    /// <inheritdoc />
    public partial class GetNodesHierarchyProcedureCreation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlMigrations.GetNodesHierarchyStoredProcedureCreatiion);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(SqlMigrations.GetNodesHierarchyStoredProcedureDeletion);
        }
    }
}
