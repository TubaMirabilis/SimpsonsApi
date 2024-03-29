﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpsonsApi.Data;

#nullable disable

namespace SimpsonsApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230325040854_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SimpsonsApi.Entities.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ff0734ee-731c-43e9-a391-531f4a0e6f68"),
                            CreatedAt = new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4371),
                            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/b/b6/Dewey_Largo_Tapped_Out.png/revision/latest?cb=20201225173139",
                            Name = "Dewey Largo",
                            Occupation = "Music Teacher"
                        },
                        new
                        {
                            Id = new Guid("718e2593-4da1-43be-a880-568e3bde4c16"),
                            CreatedAt = new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4383),
                            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/c/c3/Eddie.png/revision/latest?cb=20201222215954",
                            Name = "Eddie",
                            Occupation = "Police Officer"
                        },
                        new
                        {
                            Id = new Guid("75fb273a-d405-4605-8556-d5465159d654"),
                            CreatedAt = new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4386),
                            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/3/36/Janey_Tapped_Out.png/revision/latest?cb=20141218000819",
                            Name = "Janey Powell",
                            Occupation = "Schoolgirl"
                        },
                        new
                        {
                            Id = new Guid("1ea4237a-0bb1-4a0b-864a-943ae7cbd16b"),
                            CreatedAt = new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4439),
                            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/d/da/Jasper_Beardsley.png/revision/latest?cb=20201222215930",
                            Name = "Jasper Beardly",
                            Occupation = "Retiree"
                        },
                        new
                        {
                            Id = new Guid("181870ad-0f5c-471e-8fd7-05884c019f1b"),
                            CreatedAt = new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4442),
                            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/0/0d/Kent_Brockman_-_shading.png/revision/latest?cb=20201222215914",
                            Name = "Kent Brockman",
                            Occupation = "News Anchor"
                        },
                        new
                        {
                            Id = new Guid("289c3d7c-2a15-4a06-9c80-9990468bb252"),
                            CreatedAt = new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4446),
                            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/0/07/Tapped_Out_Unlock_Krusty.png/revision/latest?cb=20141120143301",
                            Name = "Herschel Shmoikel Pinchas Yerucham Krustofsky",
                            Occupation = "TV Entertainer"
                        },
                        new
                        {
                            Id = new Guid("270a9391-9a6f-4281-bcd5-9063da7a1d8d"),
                            CreatedAt = new DateTime(2023, 3, 25, 4, 8, 54, 234, DateTimeKind.Utc).AddTicks(4448),
                            ImageUrl = "https://static.wikia.nocookie.net/simpsons/images/a/ae/Lenny_Leonard.png/revision/latest?cb=20201222215907",
                            Name = "Lenny Leonard",
                            Occupation = "Nuclear Power Technician"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
