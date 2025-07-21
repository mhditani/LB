using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("6c97267f-ec7d-40c5-b814-51321515c661"), "Easy" },
                    { new Guid("8efd4ac3-7549-4f14-91b8-c4153e728882"), "Medium" },
                    { new Guid("e6a6d27d-4e98-41ea-85c5-3f509eb0ed77"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { new Guid("a1f1c555-1111-4a51-b1a1-000000000001"), "BEY", "https://upload.wikimedia.org/wikipedia/commons/5/53/Beirut_Central_District.jpg", "Beirut" },
                    { new Guid("a1f1c555-1111-4a51-b1a1-000000000002"), "MLB", "https://upload.wikimedia.org/wikipedia/commons/3/31/Bekish_monastery_001.jpg", "Mount Lebanon" },
                    { new Guid("a1f1c555-1111-4a51-b1a1-000000000003"), "NLB", "https://upload.wikimedia.org/wikipedia/commons/d/d7/Ehden_View.jpg", "North Lebanon" },
                    { new Guid("a1f1c555-1111-4a51-b1a1-000000000004"), "AKK", "https://upload.wikimedia.org/wikipedia/commons/8/88/Akkar_Lebanon_village_landscape.jpg", "Akkar" },
                    { new Guid("a1f1c555-1111-4a51-b1a1-000000000005"), "BEK", "https://upload.wikimedia.org/wikipedia/commons/4/4b/Zahle_Bekaa_Valley_Lebanon_2009.jpg", "Bekaa" },
                    { new Guid("a1f1c555-1111-4a51-b1a1-000000000006"), "BHM", "https://upload.wikimedia.org/wikipedia/commons/3/3c/Baalbek_Roman_ruins.jpg", "Baalbek-Hermel" },
                    { new Guid("a1f1c555-1111-4a51-b1a1-000000000007"), "SLB", "https://upload.wikimedia.org/wikipedia/commons/3/33/Tyre_harbor_south_lebanon_2006.jpg", "South Lebanon" },
                    { new Guid("a1f1c555-1111-4a51-b1a1-000000000008"), "NAB", "https://upload.wikimedia.org/wikipedia/commons/f/f3/Nabatieh_Lebanon_view.jpg", "Nabatieh" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6c97267f-ec7d-40c5-b814-51321515c661"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("8efd4ac3-7549-4f14-91b8-c4153e728882"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e6a6d27d-4e98-41ea-85c5-3f509eb0ed77"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1f1c555-1111-4a51-b1a1-000000000001"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1f1c555-1111-4a51-b1a1-000000000002"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1f1c555-1111-4a51-b1a1-000000000003"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1f1c555-1111-4a51-b1a1-000000000004"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1f1c555-1111-4a51-b1a1-000000000005"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1f1c555-1111-4a51-b1a1-000000000006"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1f1c555-1111-4a51-b1a1-000000000007"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a1f1c555-1111-4a51-b1a1-000000000008"));
        }
    }
}
