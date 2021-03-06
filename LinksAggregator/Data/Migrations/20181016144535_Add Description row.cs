﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace LinksAggregator.Data.Migrations
{
    public partial class AddDescriptionrow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Links",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Links");
        }
    }
}
