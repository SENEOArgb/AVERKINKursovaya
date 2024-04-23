﻿// <auto-generated />
using System;
using KursovayaMAIN.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KursovayaMAIN.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("KursovayaMAIN.Model.Consumables", b =>
                {
                    b.Property<int>("consumableId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("consumableName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("consumablePrice")
                        .HasColumnType("INTEGER");

                    b.Property<string>("consumableType")
                        .HasColumnType("TEXT");

                    b.ToTable("Consumables");
                });

            modelBuilder.Entity("KursovayaMAIN.Model.Orders", b =>
                {
                    b.Property<int>("countBalls")
                        .HasColumnType("INTEGER");

                    b.Property<string>("orderArticle")
                        .HasColumnType("TEXT");

                    b.Property<int>("orderId")
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly>("orderProcessDate")
                        .HasColumnType("TEXT");

                    b.Property<TimeOnly>("orderProcessTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("tariffName")
                        .HasColumnType("TEXT");

                    b.Property<int>("tariffPrice")
                        .HasColumnType("INTEGER");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("KursovayaMAIN.Model.Users", b =>
                {
                    b.Property<int>("passportNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("passportSeries")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("userName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("userSurname")
                        .HasColumnType("TEXT");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KursovayaMAIN.Model.Weapons", b =>
                {
                    b.Property<string>("acummulator")
                        .HasColumnType("TEXT");

                    b.Property<string>("combatCaliber")
                        .HasColumnType("TEXT");

                    b.Property<string>("countryManufactureWeapon")
                        .HasColumnType("TEXT");

                    b.Property<int?>("firingRate")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("magazineCapacity")
                        .HasColumnType("INTEGER");

                    b.Property<string>("manufacturerWeapon")
                        .HasColumnType("TEXT");

                    b.Property<string>("materialWeapon")
                        .HasColumnType("TEXT");

                    b.Property<string>("serialNumberWeapon")
                        .HasColumnType("TEXT");

                    b.Property<string>("weaponCategory")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("weaponId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("weaponName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("weaponPrice")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("weightWeapon")
                        .HasColumnType("REAL");

                    b.Property<int?>("yearManufactureWeapon")
                        .HasColumnType("INTEGER");

                    b.ToTable("Weapons");
                });
#pragma warning restore 612, 618
        }
    }
}