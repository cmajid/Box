using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Box.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddIdForDownload : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DataFileId",
                table: "Download",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Download_DataFileId",
                table: "Download",
                column: "DataFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Download_DataFile_DataFileId",
                table: "Download",
                column: "DataFileId",
                principalTable: "DataFile",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Download_DataFile_DataFileId",
                table: "Download");

            migrationBuilder.DropIndex(
                name: "IX_Download_DataFileId",
                table: "Download");

            migrationBuilder.DropColumn(
                name: "DataFileId",
                table: "Download");
        }
    }
}
