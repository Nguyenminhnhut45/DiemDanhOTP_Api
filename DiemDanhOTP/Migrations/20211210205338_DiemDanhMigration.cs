using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiemDanhOTP.Migrations
{
    public partial class DiemDanhMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    IDAdmin = table.Column<byte>(type: "tinyint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Usename = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.IDAdmin);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    IDCourse = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    CoursetName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NOC = table.Column<byte>(type: "tinyint", nullable: true),
                    Peroid = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.IDCourse);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usename = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Role = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    IDAdmin = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                    table.ForeignKey(
                        name: "Relationship25",
                        column: x => x.IDAdmin,
                        principalTable: "Admins",
                        principalColumn: "IDAdmin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    IDStudent = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.IDStudent);
                    table.ForeignKey(
                        name: "Relationship27",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    IDTeacher = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Birthday = table.Column<DateTime>(type: "date", nullable: true),
                    ID = table.Column<int>(type: "int", nullable: true),
                    SourceTeacher = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Gmail = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.IDTeacher);
                    table.ForeignKey(
                        name: "Relationship26",
                        column: x => x.ID,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GroupSubject",
                columns: table => new
                {
                    IDGroup = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDCourse = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    IDTeacher = table.Column<int>(type: "int", nullable: true),
                    ClassGroup = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    DateStart = table.Column<DateTime>(type: "date", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "date", nullable: true),
                    Semester = table.Column<byte>(type: "tinyint", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: true),
                    Linkds = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Linkaddsr = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupSubject", x => x.IDGroup);
                    table.ForeignKey(
                        name: "Relationship10",
                        column: x => x.IDCourse,
                        principalTable: "Courses",
                        principalColumn: "IDCourse",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Relationship12",
                        column: x => x.IDTeacher,
                        principalTable: "Teachers",
                        principalColumn: "IDTeacher",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    IDSession = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Classroom = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Session = table.Column<byte>(type: "tinyint", nullable: true),
                    PeriodStart = table.Column<byte>(type: "tinyint", nullable: true),
                    PeriodEnd = table.Column<byte>(type: "tinyint", nullable: true),
                    IDGroup = table.Column<int>(type: "int", nullable: true),
                    Day = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.IDSession);
                    table.ForeignKey(
                        name: "Relationship28",
                        column: x => x.IDGroup,
                        principalTable: "GroupSubject",
                        principalColumn: "IDGroup",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Study",
                columns: table => new
                {
                    IDGroup = table.Column<int>(type: "int", nullable: false),
                    IDStudent = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    STT = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "Relationship13",
                        column: x => x.IDGroup,
                        principalTable: "GroupSubject",
                        principalColumn: "IDGroup",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Relationship14",
                        column: x => x.IDStudent,
                        principalTable: "Students",
                        principalColumn: "IDStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionDetail",
                columns: table => new
                {
                    IDLession = table.Column<int>(type: "int", nullable: false),
                    IDStuddent = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OTP = table.Column<string>(type: "varchar(6)", unicode: false, maxLength: 6, nullable: true),
                    ViTri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionDetail", x => new { x.IDLession, x.IDStuddent });
                    table.ForeignKey(
                        name: "Relationship1",
                        column: x => x.IDLession,
                        principalTable: "Session",
                        principalColumn: "IDSession",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Relationship2",
                        column: x => x.IDStuddent,
                        principalTable: "Students",
                        principalColumn: "IDStudent",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Relationship10",
                table: "GroupSubject",
                column: "IDCourse");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship12",
                table: "GroupSubject",
                column: "IDTeacher");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship28",
                table: "Session",
                column: "IDGroup");

            migrationBuilder.CreateIndex(
                name: "IX_SessionDetail_IDStuddent",
                table: "SessionDetail",
                column: "IDStuddent");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship27",
                table: "Students",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Study_IDGroup",
                table: "Study",
                column: "IDGroup");

            migrationBuilder.CreateIndex(
                name: "IX_Study_IDStudent",
                table: "Study",
                column: "IDStudent");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship26",
                table: "Teachers",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship25",
                table: "Users",
                column: "IDAdmin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessionDetail");

            migrationBuilder.DropTable(
                name: "Study");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "GroupSubject");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Admins");
        }
    }
}
