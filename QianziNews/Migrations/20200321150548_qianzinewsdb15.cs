using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QianziNews.Migrations
{
    public partial class qianzinewsdb15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Category = table.Column<string>(nullable: false),
                    Content = table.Column<string>(nullable: false),
                    PostTime = table.Column<DateTime>(nullable: false, defaultValueSql: "getDate()"),
                    Author = table.Column<string>(nullable: true, defaultValue: "匿名"),
                    Source = table.Column<string>(nullable: true, defaultValue: "无")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(maxLength: 1000, nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    PostTime = table.Column<DateTime>(nullable: false),
                    Zan = table.Column<int>(nullable: false, defaultValue: 0),
                    NewsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_Comment_News",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClickCount = table.Column<int>(nullable: false),
                    NewsId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsDetail", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_NewsDetail_News",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(nullable: false),
                    NewsId = table.Column<int>(nullable: false),
                    MimeType = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsImage", x => x.Id);
                    table.ForeignKey(
                        name: "ForeignKey_NewsImage_News",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_NewsId",
                table: "Comment",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsDetail_NewsId",
                table: "NewsDetail",
                column: "NewsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsImage_NewsId",
                table: "NewsImage",
                column: "NewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "NewsDetail");

            migrationBuilder.DropTable(
                name: "NewsImage");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
