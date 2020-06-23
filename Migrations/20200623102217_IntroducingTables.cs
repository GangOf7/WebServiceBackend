using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PiratesBay.Migrations
{
    public partial class IntroducingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommunicationLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntryTime = table.Column<DateTime>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CorrectiveMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageType = table.Column<string>(nullable: true),
                    Parameter = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectiveMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Device_info",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GUID = table.Column<string>(nullable: false),
                    Mac_Id = table.Column<string>(nullable: true),
                    Device_Name = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    MessageType = table.Column<string>(nullable: true),
                    DataEntryTime = table.Column<DateTime>(nullable: false),
                    ErrorLocation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParameterMeasureMarkAmber",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dissolved_oxygen_High = table.Column<double>(nullable: false),
                    Total_Dissolved_Solid_High = table.Column<double>(nullable: false),
                    Salinity_High = table.Column<double>(nullable: false),
                    Water_Temperature_High = table.Column<double>(nullable: false),
                    PH_Level_High = table.Column<double>(nullable: false),
                    Ammonium_level_High = table.Column<double>(nullable: false),
                    Dissolved_oxygen_Low = table.Column<double>(nullable: false),
                    Total_Dissolved_Solid_Low = table.Column<double>(nullable: false),
                    Salinity_Low = table.Column<double>(nullable: false),
                    Water_Temperature_Low = table.Column<double>(nullable: false),
                    PH_Level_Low = table.Column<double>(nullable: false),
                    Ammonium_level_Low = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterMeasureMarkAmber", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParameterMeasureMarkGreen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dissolved_oxygen_High = table.Column<double>(nullable: false),
                    Total_Dissolved_Solid_High = table.Column<double>(nullable: false),
                    Salinity_High = table.Column<double>(nullable: false),
                    Water_Temperature_High = table.Column<double>(nullable: false),
                    PH_Level_High = table.Column<double>(nullable: false),
                    Ammonium_level_High = table.Column<double>(nullable: false),
                    Dissolved_oxygen_Low = table.Column<double>(nullable: false),
                    Total_Dissolved_Solid_Low = table.Column<double>(nullable: false),
                    Salinity_Low = table.Column<double>(nullable: false),
                    Water_Temperature_Low = table.Column<double>(nullable: false),
                    PH_Level_Low = table.Column<double>(nullable: false),
                    Ammonium_level_Low = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterMeasureMarkGreen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParameterMeasureMarkRed",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dissolved_oxygen_High = table.Column<double>(nullable: false),
                    Total_Dissolved_Solid_High = table.Column<double>(nullable: false),
                    Salinity_High = table.Column<double>(nullable: false),
                    Water_Temperature_High = table.Column<double>(nullable: false),
                    PH_Level_High = table.Column<double>(nullable: false),
                    Ammonium_level_High = table.Column<double>(nullable: false),
                    Dissolved_oxygen_Low = table.Column<double>(nullable: false),
                    Total_Dissolved_Solid_Low = table.Column<double>(nullable: false),
                    Salinity_Low = table.Column<double>(nullable: false),
                    Water_Temperature_Low = table.Column<double>(nullable: false),
                    PH_Level_Low = table.Column<double>(nullable: false),
                    Ammonium_level_Low = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterMeasureMarkRed", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SensorData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Device_Id = table.Column<int>(nullable: false),
                    DataEntryTime = table.Column<DateTime>(nullable: false),
                    Dissolved_oxygen = table.Column<double>(nullable: false),
                    Total_Dissolved_Solid = table.Column<double>(nullable: false),
                    Salinity = table.Column<double>(nullable: false),
                    Water_Temperature = table.Column<double>(nullable: false),
                    PH_Level = table.Column<double>(nullable: false),
                    Ammonium_level = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SensorData_Device_info_Device_Id",
                        column: x => x.Device_Id,
                        principalTable: "Device_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Device_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AlternativePhoneNumber = table.Column<string>(nullable: true),
                    Role_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfo_Device_info_Device_Id",
                        column: x => x.Device_Id,
                        principalTable: "Device_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInfo_Role_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Value 100" });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Value 106" });

            migrationBuilder.InsertData(
                table: "Values",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Value 102" });

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_Device_Id",
                table: "SensorData",
                column: "Device_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_Device_Id",
                table: "UserInfo",
                column: "Device_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_Role_Id",
                table: "UserInfo",
                column: "Role_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommunicationLog");

            migrationBuilder.DropTable(
                name: "CorrectiveMessage");

            migrationBuilder.DropTable(
                name: "EventLog");

            migrationBuilder.DropTable(
                name: "ParameterMeasureMarkAmber");

            migrationBuilder.DropTable(
                name: "ParameterMeasureMarkGreen");

            migrationBuilder.DropTable(
                name: "ParameterMeasureMarkRed");

            migrationBuilder.DropTable(
                name: "SensorData");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "Device_info");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
