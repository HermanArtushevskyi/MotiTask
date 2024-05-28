using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace motitask.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criteria",
                columns: table => new
                {
                    C_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    C_name = table.Column<string>(type: "TEXT", nullable: false),
                    C_range = table.Column<int>(type: "INTEGER", nullable: false),
                    C_weight = table.Column<double>(type: "REAL", nullable: false),
                    C_type = table.Column<string>(type: "TEXT", nullable: false),
                    optim_type = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteria", x => x.C_id);
                });

            migrationBuilder.CreateTable(
                name: "LPRs",
                columns: table => new
                {
                    L_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    L_name = table.Column<string>(type: "TEXT", nullable: false),
                    L_range = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LPRs", x => x.L_id);
                });

            migrationBuilder.CreateTable(
                name: "Marks",
                columns: table => new
                {
                    M_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    C_id = table.Column<int>(type: "INTEGER", nullable: false),
                    M_name = table.Column<string>(type: "TEXT", nullable: false),
                    M_range = table.Column<int>(type: "INTEGER", nullable: false),
                    M_num = table.Column<int>(type: "INTEGER", nullable: false),
                    M_norm = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marks", x => x.M_id);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    R_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    L_id = table.Column<int>(type: "INTEGER", nullable: false),
                    A_id = table.Column<int>(type: "INTEGER", nullable: false),
                    L_range = table.Column<int>(type: "INTEGER", nullable: false),
                    A_weight = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.R_id);
                });

            migrationBuilder.CreateTable(
                name: "Vectors",
                columns: table => new
                {
                    V_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    A_id = table.Column<int>(type: "INTEGER", nullable: false),
                    M_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vectors", x => x.V_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Criteria");

            migrationBuilder.DropTable(
                name: "LPRs");

            migrationBuilder.DropTable(
                name: "Marks");

            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "Vectors");
        }
    }
}
