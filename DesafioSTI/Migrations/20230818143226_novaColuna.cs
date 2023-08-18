using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioSTI.Migrations
{
    /// <inheritdoc />
    public partial class novaColuna : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "frequentada",
                table: "Consulta",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "frequentada",
                table: "Consulta");
        }
    }
}
