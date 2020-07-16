﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PiratesBay.Data;

namespace PiratesBay.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200709125440_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("PiratesBay.Models.CommunicationLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Communication_Type")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataEntryTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<int>("User_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("warning_corrective_mapping_ID")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("User_Id");

                    b.HasIndex("warning_corrective_mapping_ID");

                    b.ToTable("CommunicationLog");
                });

            modelBuilder.Entity("PiratesBay.Models.CorrectiveMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Amber_Threshold_High")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Amber_Threshold_Low")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Green_Threshold_High")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Green_Threshold_Low")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageType")
                        .HasColumnType("TEXT");

                    b.Property<string>("Red_Threshold_High")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Red_Threshold_Low")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("lastupdatedby")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lastupdatedon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("CorrectiveMessage");
                });

            modelBuilder.Entity("PiratesBay.Models.Device_info", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Area")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Device_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("GUID")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Latitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("Longitude")
                        .HasColumnType("TEXT");

                    b.Property<string>("Mac_Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("State")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("lastupdatedby")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lastupdatedon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Device_info");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Area = "Sundarban",
                            Country = "India",
                            Device_Name = "HMS Interceptor",
                            GUID = "00000000-0000-0000-0000-000000000000",
                            State = "West Bengal",
                            Status = true,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Area = "Bantala",
                            Country = "India",
                            Device_Name = "The Queen Anne's Revenge",
                            GUID = "00000000-0000-0000-0000-000000000000",
                            State = "West Bengal",
                            Status = true,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Area = "Kolkata",
                            Country = "India",
                            Device_Name = "The Silent Mary",
                            GUID = "00000000-0000-0000-0000-000000000000",
                            State = "West Bengal",
                            Status = true,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Area = "Hoogly",
                            Country = "India",
                            Device_Name = "Empress",
                            GUID = "00000000-0000-0000-0000-000000000000",
                            State = "West Bengal",
                            Status = true,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Area = "Midnapore",
                            Country = "India",
                            Device_Name = "Lord Beckett's Armada",
                            GUID = "00000000-0000-0000-0000-000000000000",
                            State = "West Bengal",
                            Status = true,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PiratesBay.Models.EventLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataEntryTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Device_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Message")
                        .HasColumnType("TEXT");

                    b.Property<string>("MessageType")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Device_Id");

                    b.ToTable("EventLog");
                });

            modelBuilder.Entity("PiratesBay.Models.ParameterBenchmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Amber_Threshold_High")
                        .HasColumnType("REAL");

                    b.Property<double>("Amber_Threshold_Low")
                        .HasColumnType("REAL");

                    b.Property<double>("Green_Threshold_High")
                        .HasColumnType("REAL");

                    b.Property<double>("Green_Threshold_Low")
                        .HasColumnType("REAL");

                    b.Property<int>("Param_Id")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Red_Threshold_High")
                        .HasColumnType("REAL");

                    b.Property<double>("Red_Threshold_Low")
                        .HasColumnType("REAL");

                    b.Property<string>("lastupdatedby")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lastupdatedon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Param_Id");

                    b.ToTable("ParameterBenchmark");
                });

            modelBuilder.Entity("PiratesBay.Models.Parameter_Master", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Param_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<string>("lastupdatedby")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lastupdatedon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Parameter_Masters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Param_Name = "Temperature",
                            Status = false,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Param_Name = "PH Level",
                            Status = false,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Param_Name = "Partical Level",
                            Status = false,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Param_Name = "Oxygen Level",
                            Status = false,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Param_Name = "Salinity",
                            Status = false,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PiratesBay.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RoleName")
                        .HasColumnType("TEXT");

                    b.Property<string>("lastupdatedby")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lastupdatedon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Administrator",
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "General User",
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Owner",
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            RoleName = "Care Taker",
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PiratesBay.Models.SensorData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataEntryTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("Device_Id")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Input_Value")
                        .HasColumnType("REAL");

                    b.Property<int>("Param_Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Device_Id");

                    b.HasIndex("Param_Id");

                    b.ToTable("SensorData");
                });

            modelBuilder.Entity("PiratesBay.Models.UserDeviceMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Device_Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("User_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("lastupdatedby")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lastupdatedon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("UserDeviceMapping");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Device_Id = 1,
                            User_Id = 1,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Device_Id = 2,
                            User_Id = 1,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Device_Id = 3,
                            User_Id = 1,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            Device_Id = 4,
                            User_Id = 1,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            Device_Id = 5,
                            User_Id = 1,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PiratesBay.Models.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AlternativePhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("NotificationFrequency")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<int>("Role_Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("lastupdatedby")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lastupdatedon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Role_Id");

                    b.ToTable("UserInfo");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Will Turner",
                            Role_Id = 1,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Name = "Elizabeth Swann",
                            Role_Id = 2,
                            lastupdatedon = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("PiratesBay.Models.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Values");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Value 100"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Value 106"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Value 102"
                        });
                });

            modelBuilder.Entity("PiratesBay.Models.WarningMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Warning_message")
                        .HasColumnType("TEXT");

                    b.Property<string>("lastupdatedby")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lastupdatedon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("WarningMaster");
                });

            modelBuilder.Entity("PiratesBay.Models.WarningStateDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Param_Greaterthan_val")
                        .HasColumnType("REAL");

                    b.Property<int>("Param_Id")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Param_LessThan_val")
                        .HasColumnType("REAL");

                    b.Property<int>("Warning_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("lastupdatedby")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lastupdatedon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Param_Id");

                    b.HasIndex("Warning_ID");

                    b.ToTable("WarningStateDetails");
                });

            modelBuilder.Entity("PiratesBay.Models.Warning_Corrective_Mapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CorrectiveMessage_ID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Warning_ID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("lastupdatedby")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("lastupdatedon")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Warning_Corrective_Mapping");
                });

            modelBuilder.Entity("PiratesBay.Models.CommunicationLog", b =>
                {
                    b.HasOne("PiratesBay.Models.UserInfo", "UserInfo")
                        .WithMany()
                        .HasForeignKey("User_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiratesBay.Models.Warning_Corrective_Mapping", "Warning_Corrective_Mapping")
                        .WithMany()
                        .HasForeignKey("warning_corrective_mapping_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PiratesBay.Models.EventLog", b =>
                {
                    b.HasOne("PiratesBay.Models.Device_info", "Device_Info")
                        .WithMany()
                        .HasForeignKey("Device_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PiratesBay.Models.ParameterBenchmark", b =>
                {
                    b.HasOne("PiratesBay.Models.Parameter_Master", "Parameter_Master")
                        .WithMany()
                        .HasForeignKey("Param_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PiratesBay.Models.SensorData", b =>
                {
                    b.HasOne("PiratesBay.Models.Device_info", "Device_Info")
                        .WithMany()
                        .HasForeignKey("Device_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiratesBay.Models.Parameter_Master", "Parameter_Master")
                        .WithMany()
                        .HasForeignKey("Param_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PiratesBay.Models.UserInfo", b =>
                {
                    b.HasOne("PiratesBay.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PiratesBay.Models.WarningStateDetails", b =>
                {
                    b.HasOne("PiratesBay.Models.Parameter_Master", "Parameter_Master")
                        .WithMany()
                        .HasForeignKey("Param_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PiratesBay.Models.WarningMaster", "WarningMaster")
                        .WithMany()
                        .HasForeignKey("Warning_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}