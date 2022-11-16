using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dotnetcheck.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReleasesIndex",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    channelversion = table.Column<string>(type: "TEXT", nullable: false),
                    latestrelease = table.Column<string>(type: "TEXT", nullable: false),
                    latestreleasedate = table.Column<string>(type: "TEXT", nullable: false),
                    security = table.Column<bool>(type: "INTEGER", nullable: false),
                    latestruntime = table.Column<string>(type: "TEXT", nullable: false),
                    latestsdk = table.Column<string>(type: "TEXT", nullable: false),
                    product = table.Column<string>(type: "TEXT", nullable: false),
                    releasetype = table.Column<string>(type: "TEXT", nullable: false),
                    supportphase = table.Column<string>(type: "TEXT", nullable: false),
                    eoldate = table.Column<string>(type: "TEXT", nullable: false),
                    releasesjson = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReleasesIndex", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReleasesIndex");
        }
    }
}
