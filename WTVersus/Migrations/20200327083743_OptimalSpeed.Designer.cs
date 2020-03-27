﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WTVersus.Models;

namespace WTVersus.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200327083743_OptimalSpeed")]
    partial class OptimalSpeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WTVersus.Models.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AAMissile")
                        .HasColumnType("bit");

                    b.Property<bool>("AGMissile")
                        .HasColumnType("bit");

                    b.Property<bool>("ASMissile")
                        .HasColumnType("bit");

                    b.Property<bool>("AirBrake")
                        .HasColumnType("bit");

                    b.Property<bool>("AirRadar")
                        .HasColumnType("bit");

                    b.Property<double?>("BR")
                        .HasColumnType("float");

                    b.Property<int?>("BombLoad")
                        .HasColumnType("int");

                    b.Property<double?>("BurstMass")
                        .HasColumnType("float");

                    b.Property<bool>("CCIP")
                        .HasColumnType("bit");

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Climb")
                        .HasColumnType("int");

                    b.Property<string>("CourseWeapon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnginePower")
                        .HasColumnType("int");

                    b.Property<int?>("FirstFlyYear")
                        .HasColumnType("int");

                    b.Property<bool>("Flares")
                        .HasColumnType("bit");

                    b.Property<int?>("Flutter")
                        .HasColumnType("int");

                    b.Property<bool>("GSuit")
                        .HasColumnType("bit");

                    b.Property<bool>("GroundRadar")
                        .HasColumnType("bit");

                    b.Property<bool>("HBomb")
                        .HasColumnType("bit");

                    b.Property<bool>("HCannon")
                        .HasColumnType("bit");

                    b.Property<bool>("HTorpedo")
                        .HasColumnType("bit");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaxSpeedAt0")
                        .HasColumnType("int");

                    b.Property<int?>("MaxSpeedAt5000")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OptimalAilerons")
                        .HasColumnType("int");

                    b.Property<int?>("OptimalAlitude")
                        .HasColumnType("int");

                    b.Property<int?>("OptimalElevator")
                        .HasColumnType("int");

                    b.Property<bool>("Parachute")
                        .HasColumnType("bit");

                    b.Property<bool>("RWR")
                        .HasColumnType("bit");

                    b.Property<string>("Rank")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RepairCost")
                        .HasColumnType("int");

                    b.Property<bool>("Tailhook")
                        .HasColumnType("bit");

                    b.Property<double?>("ThrustToWeight")
                        .HasColumnType("float");

                    b.Property<double?>("TurnAt0")
                        .HasColumnType("float");

                    b.Property<bool>("Turrel")
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int?>("ViewCount")
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.Property<string>("WikiDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WikiLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WrongMusic")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Planes");
                });
#pragma warning restore 612, 618
        }
    }
}
