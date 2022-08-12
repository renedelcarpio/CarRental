﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarRental.Data.Migrations
{
    [DbContext(typeof(RentalDbContext))]
    [Migration("20220811001438_rentalReferenceInUser")]
    partial class rentalReferenceInUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Models.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Available")
                        .HasColumnType("bit");

                    b.Property<string>("BrandAndModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GearBox")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("Seaters")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrunkSize")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Available = true,
                            BrandAndModel = "Suzuki Alto",
                            GearBox = "Manual Transmission",
                            PictureUrl = "https://th.bing.com/th/id/R.0a70c93cc6dcc81661078747bc4a9cc4?rik=lwiiImmqtAwm5w&riu=http%3a%2f%2fwww.autosarena.com%2fwp-content%2fuploads%2f2016%2f05%2fMaruti-Suzuki-Alto-800-Superior-White.png&ehk=aEBUZIxBqD3apL6Fs1lA2XzJodnd4nKa2maaCE01%2bDg%3d&risl=&pid=ImgRaw&r=0&sres=1&sresct=1",
                            Price = 100,
                            Seaters = "4 seaters",
                            TrunkSize = "254 liters",
                            Type = "Small"
                        },
                        new
                        {
                            Id = 2,
                            Available = true,
                            BrandAndModel = "Suzuki Celerio",
                            GearBox = "Automatic Transmission",
                            PictureUrl = "https://th.bing.com/th/id/R.d0586968de8a43eee95a1a41e5966e12?rik=ioti2Vk%2bdocK1Q&riu=http%3a%2f%2fwww.pngimagesfree.com%2fCar%2fMaruti%2fCelerio+Car+png.png&ehk=FuAjI5ipREVLyIRS4%2bf9G0ES6WWDuCKrwc8qBjjhjsY%3d&risl=&pid=ImgRaw&r=0",
                            Price = 135,
                            Seaters = "5 seaters",
                            TrunkSize = "254 liters",
                            Type = "Small"
                        },
                        new
                        {
                            Id = 3,
                            Available = true,
                            BrandAndModel = "Hyundai Accent",
                            GearBox = "Automatic Transmission",
                            PictureUrl = "https://th.bing.com/th/id/R.877bd017bab0e235737cb90a0af61ecd?rik=QhUPGYNejHH0oQ&riu=http%3a%2f%2fwww.pngimagesfree.com%2fCar%2fhyundai%2fHundai-accent-png_angular-front.png&ehk=Lbq%2btnlPeIidhdzUDKBkRkSTyXl0lXN3JlIsZTzItPo%3d&risl=&pid=ImgRaw&r=0",
                            Price = 170,
                            Seaters = "5 seaters",
                            TrunkSize = "388 liters",
                            Type = "Medium"
                        },
                        new
                        {
                            Id = 4,
                            Available = true,
                            BrandAndModel = "Suzuki Vitara",
                            GearBox = "Manual Transmission",
                            PictureUrl = "https://www.autokpplus.cz/User_Files/photos/60361f1ac420d5be032658d065vitarafront.png",
                            Price = 200,
                            Seaters = "5 seaters",
                            TrunkSize = "375 liters",
                            Type = "Medium"
                        },
                        new
                        {
                            Id = 5,
                            Available = true,
                            BrandAndModel = "Toyota Hilux",
                            GearBox = "Manual Transmission",
                            PictureUrl = "https://i1.wp.com/fairwheels.com/wp-content/uploads/2016/11/Toyota-Hilux-Revo-V-Automatic-3.0-price-and-specification.png?fit=980%2C559&ssl=1",
                            Price = 240,
                            Seaters = "5 seaters",
                            TrunkSize = "1 Ton",
                            Type = "Large"
                        },
                        new
                        {
                            Id = 6,
                            Available = true,
                            BrandAndModel = "Toyota Prado",
                            GearBox = "Automatic Transmission",
                            PictureUrl = "https://th.bing.com/th/id/R.1da109636cf679c449393fabd969aef2?rik=ca5rpoWTp9%2fyIQ&pid=ImgRaw&r=0",
                            Price = 300,
                            Seaters = "7 seaters",
                            TrunkSize = "640 liters",
                            Type = "Large"
                        });
                });

            modelBuilder.Entity("API.Models.Entities.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("ConfirmationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RentalEnd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RentalStart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("UserId");

                    b.ToTable("Rentals");
                });

            modelBuilder.Entity("API.Models.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@email.com",
                            IsAdmin = true,
                            Password = "Pa$$w0rd",
                            Username = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "bob@email.com",
                            IsAdmin = false,
                            Password = "Pa$$w0rd",
                            Username = "Bob"
                        },
                        new
                        {
                            Id = 3,
                            Email = "kurt@email.com",
                            IsAdmin = false,
                            Password = "Pa$$w0rd",
                            Username = "Kurt"
                        });
                });

            modelBuilder.Entity("API.Models.Entities.Rental", b =>
                {
                    b.HasOne("API.Models.Entities.Car", "Car")
                        .WithMany("Rentals")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Models.Entities.User", "User")
                        .WithMany("Rentals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("User");
                });

            modelBuilder.Entity("API.Models.Entities.Car", b =>
                {
                    b.Navigation("Rentals");
                });

            modelBuilder.Entity("API.Models.Entities.User", b =>
                {
                    b.Navigation("Rentals");
                });
#pragma warning restore 612, 618
        }
    }
}
