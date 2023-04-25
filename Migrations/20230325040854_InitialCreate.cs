using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SimpsonsApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Occupation = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "CreatedAt", "ImageUrl", "Name", "Occupation" },
                values: new object[,]
                {
                    { new Guid("181870ad-0f5c-471e-8fd7-05884c019f1b"), new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4442), "https://static.wikia.nocookie.net/simpsons/images/0/0d/Kent_Brockman_-_shading.png/revision/latest?cb=20201222215914", "Kent Brockman", "News Anchor" },
                    { new Guid("1ea4237a-0bb1-4a0b-864a-943ae7cbd16b"), new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4439), "https://static.wikia.nocookie.net/simpsons/images/d/da/Jasper_Beardsley.png/revision/latest?cb=20201222215930", "Jasper Beardly", "Retiree" },
                    { new Guid("270a9391-9a6f-4281-bcd5-9063da7a1d8d"), new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4448), "https://static.wikia.nocookie.net/simpsons/images/a/ae/Lenny_Leonard.png/revision/latest?cb=20201222215907", "Lenny Leonard", "Nuclear Power Technician" },
                    { new Guid("289c3d7c-2a15-4a06-9c80-9990468bb252"), new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4446), "https://static.wikia.nocookie.net/simpsons/images/0/07/Tapped_Out_Unlock_Krusty.png/revision/latest?cb=20141120143301", "Herschel Shmoikel Pinchas Yerucham Krustofsky", "TV Entertainer" },
                    { new Guid("718e2593-4da1-43be-a880-568e3bde4c16"), new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4383), "https://static.wikia.nocookie.net/simpsons/images/c/c3/Eddie.png/revision/latest?cb=20201222215954", "Eddie", "Police Officer" },
                    { new Guid("75fb273a-d405-4605-8556-d5465159d654"), new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4386), "https://static.wikia.nocookie.net/simpsons/images/3/36/Janey_Tapped_Out.png/revision/latest?cb=20141218000819", "Janey Powell", "Schoolgirl" },
                    { new Guid("ff0734ee-731c-43e9-a391-531f4a0e6f68"), new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4371), "https://static.wikia.nocookie.net/simpsons/images/b/b6/Dewey_Largo_Tapped_Out.png/revision/latest?cb=20201225173139", "Dewey Largo", "Music Teacher" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characters");
        }
    }
}
