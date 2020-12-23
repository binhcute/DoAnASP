using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnGiay.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    IdColor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.IdColor);
                });

            migrationBuilder.CreateTable(
                name: "MaterialModel",
                columns: table => new
                {
                    IdMaterial = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialModel", x => x.IdMaterial);
                });

            migrationBuilder.CreateTable(
                name: "Producer",
                columns: table => new
                {
                    IdPro = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Infor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.IdPro);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    IdRoles = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.IdRoles);
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    IdSize = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumSize = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.IdSize);
                });

            migrationBuilder.CreateTable(
                name: "TypeShoe",
                columns: table => new
                {
                    IdType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeShoe", x => x.IdType);
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    IdAccount = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountName = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    IdRoles = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    RolesModelIdRoles = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.IdAccount);
                    table.ForeignKey(
                        name: "FK_Account_Roles_RolesModelIdRoles",
                        column: x => x.RolesModelIdRoles,
                        principalTable: "Roles",
                        principalColumn: "IdRoles",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shoe",
                columns: table => new
                {
                    IdShoe = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Img = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Sizes = table.Column<int>(nullable: false),
                    Colors = table.Column<int>(nullable: false),
                    Video = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    NumberSeri = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Shoelate = table.Column<bool>(nullable: false),
                    Version = table.Column<bool>(nullable: false),
                    Materials = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    Pro = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shoe", x => x.IdShoe);
                    table.ForeignKey(
                        name: "FK_Shoe_Color_Colors",
                        column: x => x.Colors,
                        principalTable: "Color",
                        principalColumn: "IdColor",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoe_MaterialModel_Materials",
                        column: x => x.Materials,
                        principalTable: "MaterialModel",
                        principalColumn: "IdMaterial",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoe_Producer_Pro",
                        column: x => x.Pro,
                        principalTable: "Producer",
                        principalColumn: "IdPro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoe_Size_Sizes",
                        column: x => x.Sizes,
                        principalTable: "Size",
                        principalColumn: "IdSize",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shoe_TypeShoe_Type",
                        column: x => x.Type,
                        principalTable: "TypeShoe",
                        principalColumn: "IdType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 300, nullable: true),
                    Address = table.Column<string>(maxLength: 300, nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    AccountIdAccount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.IdAdmin);
                    table.ForeignKey(
                        name: "FK_Admin_Account_AccountIdAccount",
                        column: x => x.AccountIdAccount,
                        principalTable: "Account",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 300, nullable: true),
                    Address = table.Column<string>(maxLength: 300, nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    AccountIdAccount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_Account_AccountIdAccount",
                        column: x => x.AccountIdAccount,
                        principalTable: "Account",
                        principalColumn: "IdAccount",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    IdComment = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 300, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    IdShoe = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.IdComment);
                    table.ForeignKey(
                        name: "FK_Comment_Shoe_IdShoe",
                        column: x => x.IdShoe,
                        principalTable: "Shoe",
                        principalColumn: "IdShoe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(nullable: false),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 300, nullable: true),
                    Address = table.Column<string>(maxLength: 300, nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    Date = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    UserIdUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_User_UserIdUser",
                        column: x => x.UserIdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(nullable: false),
                    IdShoe = table.Column<int>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    SumMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    OrderIdOrder = table.Column<int>(nullable: true),
                    ShoeIdShoe = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderIdOrder",
                        column: x => x.OrderIdOrder,
                        principalTable: "Order",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Shoe_ShoeIdShoe",
                        column: x => x.ShoeIdShoe,
                        principalTable: "Shoe",
                        principalColumn: "IdShoe",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account_RolesModelIdRoles",
                table: "Account",
                column: "RolesModelIdRoles");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_AccountIdAccount",
                table: "Admin",
                column: "AccountIdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdShoe",
                table: "Comment",
                column: "IdShoe");

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserIdUser",
                table: "Order",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderIdOrder",
                table: "OrderDetail",
                column: "OrderIdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_ShoeIdShoe",
                table: "OrderDetail",
                column: "ShoeIdShoe");

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_Colors",
                table: "Shoe",
                column: "Colors");

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_Materials",
                table: "Shoe",
                column: "Materials");

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_Pro",
                table: "Shoe",
                column: "Pro");

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_Sizes",
                table: "Shoe",
                column: "Sizes");

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_Type",
                table: "Shoe",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_User_AccountIdAccount",
                table: "User",
                column: "AccountIdAccount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Shoe");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "MaterialModel");

            migrationBuilder.DropTable(
                name: "Producer");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "TypeShoe");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
