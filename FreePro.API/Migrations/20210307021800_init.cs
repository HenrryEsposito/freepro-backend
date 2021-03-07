using Microsoft.EntityFrameworkCore.Migrations;

namespace FreePro.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Meetings",
                columns: table => new
                {
                    MeetingId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Place = table.Column<string>(nullable: true),
                    MeetingDate = table.Column<string>(nullable: true),
                    Theme = table.Column<string>(nullable: true),
                    Invited = table.Column<int>(nullable: false),
                    Batch = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meetings", x => x.MeetingId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Meetings");
        }
    }
}
