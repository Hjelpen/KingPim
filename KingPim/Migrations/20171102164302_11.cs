using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace KingPim.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SubCategories");

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                table: "SubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "SubCategoryId");

            migrationBuilder.CreateTable(
                name: "AttributeGroups",
                columns: table => new
                {
                    AttributeGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttributeGroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeGroups", x => x.AttributeGroupId);
                });

            migrationBuilder.CreateTable(
                name: "SubCategoryAttributeGroup",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false),
                    AttributeGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategoryAttributeGroup", x => new { x.SubCategoryId, x.AttributeGroupId });
                    table.ForeignKey(
                        name: "FK_SubCategoryAttributeGroup_AttributeGroups_AttributeGroupId",
                        column: x => x.AttributeGroupId,
                        principalTable: "AttributeGroups",
                        principalColumn: "AttributeGroupId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubCategoryAttributeGroup_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubCategoryAttributeGroup_AttributeGroupId",
                table: "SubCategoryAttributeGroup",
                column: "AttributeGroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubCategoryAttributeGroup");

            migrationBuilder.DropTable(
                name: "AttributeGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                table: "SubCategories");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SubCategories",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "Id");
        }
    }
}
