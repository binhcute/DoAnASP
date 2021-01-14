using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoAnGiay.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountName = table.Column<string>(maxLength: 200, nullable: false),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    Rule = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountName);
                });

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
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producer", x => x.IdPro);
                });

            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PriceSale = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.Id);
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
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeShoe", x => x.IdType);
                });

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    IdAdmin = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    Address = table.Column<string>(maxLength: 300, nullable: false),
                    Phone = table.Column<string>(maxLength: 10, nullable: false),
                    IdAccount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.IdAdmin);
                    table.ForeignKey(
                        name: "FK_Admin_Account_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "AccountName",
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
                    IdAccount = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                    table.ForeignKey(
                        name: "FK_User_Account_IdAccount",
                        column: x => x.IdAccount,
                        principalTable: "Account",
                        principalColumn: "AccountName",
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
                    Price = table.Column<int>(nullable: false),
                    Sizes = table.Column<int>(nullable: false),
                    Colors = table.Column<int>(nullable: false),
                    NumberSeri = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Shoelate = table.Column<bool>(nullable: false),
                    Version = table.Column<bool>(nullable: false),
                    Materials = table.Column<int>(nullable: false),
                    Sales = table.Column<int>(nullable: false),
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
                        name: "FK_Shoe_Sale_Sales",
                        column: x => x.Sales,
                        principalTable: "Sale",
                        principalColumn: "Id",
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
                name: "Order",
                columns: table => new
                {
                    IdOrder = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Order_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
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
                name: "OrderDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrder = table.Column<int>(nullable: false),
                    Shoes = table.Column<int>(nullable: false),
                    SumMoney = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    OrderIdOrder = table.Column<int>(nullable: true)
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
                        name: "FK_OrderDetail_Shoe_Shoes",
                        column: x => x.Shoes,
                        principalTable: "Shoe",
                        principalColumn: "IdShoe",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_IdAccount",
                table: "Admin",
                column: "IdAccount");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_IdShoe",
                table: "Comment",
                column: "IdShoe");

            migrationBuilder.CreateIndex(
                name: "IX_Order_IdUser",
                table: "Order",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderIdOrder",
                table: "OrderDetail",
                column: "OrderIdOrder");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_Shoes",
                table: "OrderDetail",
                column: "Shoes");

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
                name: "IX_Shoe_Sales",
                table: "Shoe",
                column: "Sales");

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_Sizes",
                table: "Shoe",
                column: "Sizes");

            migrationBuilder.CreateIndex(
                name: "IX_Shoe_Type",
                table: "Shoe",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_User_IdAccount",
                table: "User",
                column: "IdAccount");
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
                name: "Sale");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "TypeShoe");

            migrationBuilder.DropTable(
                name: "Account");
        }
    }
}
