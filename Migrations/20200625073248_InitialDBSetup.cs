using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PiratesBay.Migrations
{
    public partial class InitialDBSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CorrectiveMessage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Green_Threshold_High = table.Column<string>(nullable: false),
                    Green_Threshold_Low = table.Column<string>(nullable: false),
                    Amber_Threshold_High = table.Column<string>(nullable: false),
                    Amber_Threshold_Low = table.Column<string>(nullable: false),
                    Red_Threshold_High = table.Column<string>(nullable: false),
                    Red_Threshold_Low = table.Column<string>(nullable: false),
                    MessageType = table.Column<string>(nullable: true),
                    lastupdatedby = table.Column<string>(nullable: true),
                    lastupdatedon = table.Column<DateTime>(nullable: false)
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
                        .Annotation("Sqlite:Autoincrement", true),
                    GUID = table.Column<string>(nullable: false),
                    Mac_Id = table.Column<string>(nullable: true),
                    Device_Name = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Area = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    lastupdatedby = table.Column<string>(nullable: true),
                    lastupdatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device_info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Parameter_Masters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Param_Name = table.Column<string>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    lastupdatedby = table.Column<string>(nullable: true),
                    lastupdatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parameter_Masters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(nullable: true),
                    lastupdatedby = table.Column<string>(nullable: true),
                    lastupdatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDeviceMapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Device_Id = table.Column<int>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    lastupdatedby = table.Column<string>(nullable: true),
                    lastupdatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDeviceMapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warning_Corrective_Mapping",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CorrectiveMessage_ID = table.Column<int>(nullable: false),
                    Warning_ID = table.Column<int>(nullable: false),
                    lastupdatedby = table.Column<string>(nullable: true),
                    lastupdatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Warning_Corrective_Mapping", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Message = table.Column<string>(nullable: true),
                    MessageType = table.Column<string>(nullable: true),
                    DataEntryTime = table.Column<DateTime>(nullable: false),
                    Device_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLog_Device_info_Device_Id",
                        column: x => x.Device_Id,
                        principalTable: "Device_info",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParameterBenchmark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Param_Id = table.Column<int>(nullable: false),
                    Green_Threshold_High = table.Column<double>(nullable: false),
                    Green_Threshold_Low = table.Column<double>(nullable: false),
                    Amber_Threshold_High = table.Column<double>(nullable: false),
                    Amber_Threshold_Low = table.Column<double>(nullable: false),
                    Red_Threshold_High = table.Column<double>(nullable: false),
                    Red_Threshold_Low = table.Column<double>(nullable: false),
                    lastupdatedby = table.Column<string>(nullable: true),
                    lastupdatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterBenchmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParameterBenchmark_Parameter_Masters_Param_Id",
                        column: x => x.Param_Id,
                        principalTable: "Parameter_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SensorData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Device_Id = table.Column<int>(nullable: false),
                    Param_Id = table.Column<int>(nullable: false),
                    Input_Value = table.Column<double>(nullable: false),
                    DataEntryTime = table.Column<DateTime>(nullable: false)
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
                    table.ForeignKey(
                        name: "FK_SensorData_Parameter_Masters_Param_Id",
                        column: x => x.Param_Id,
                        principalTable: "Parameter_Masters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Role_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    AlternativePhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    NotificationFrequency = table.Column<string>(nullable: true),
                    lastupdatedby = table.Column<string>(nullable: true),
                    lastupdatedon = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserInfo_Role_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User_Id = table.Column<int>(nullable: false),
                    warning_corrective_mapping_ID = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Communication_Type = table.Column<string>(nullable: true),
                    DataEntryTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunicationLog_UserInfo_User_Id",
                        column: x => x.User_Id,
                        principalTable: "UserInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommunicationLog_Warning_Corrective_Mapping_warning_corrective_mapping_ID",
                        column: x => x.warning_corrective_mapping_ID,
                        principalTable: "Warning_Corrective_Mapping",
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
                name: "IX_CommunicationLog_User_Id",
                table: "CommunicationLog",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationLog_warning_corrective_mapping_ID",
                table: "CommunicationLog",
                column: "warning_corrective_mapping_ID");

            migrationBuilder.CreateIndex(
                name: "IX_EventLog_Device_Id",
                table: "EventLog",
                column: "Device_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterBenchmark_Param_Id",
                table: "ParameterBenchmark",
                column: "Param_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_Device_Id",
                table: "SensorData",
                column: "Device_Id");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_Param_Id",
                table: "SensorData",
                column: "Param_Id");

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
                name: "ParameterBenchmark");

            migrationBuilder.DropTable(
                name: "SensorData");

            migrationBuilder.DropTable(
                name: "UserDeviceMapping");

            migrationBuilder.DropTable(
                name: "Values");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "Warning_Corrective_Mapping");

            migrationBuilder.DropTable(
                name: "Device_info");

            migrationBuilder.DropTable(
                name: "Parameter_Masters");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
