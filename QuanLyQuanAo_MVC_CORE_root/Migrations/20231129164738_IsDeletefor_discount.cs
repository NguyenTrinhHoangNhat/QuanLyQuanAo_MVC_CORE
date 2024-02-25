using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyQuanAo_MVC_CORE.Migrations
{
    /// <inheritdoc />
    public partial class IsDeletefor_discount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "brand",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    brandName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    imgUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    imgName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    isDelete = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__brand__3213E83F8ADA9618", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    nameDiscount = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    codeName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    isPercent = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Discount__3213E83F90C55EA2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    productTypesName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isDelete = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ProductT__3213E83FAA4FA0A9", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    roleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Role__3213E83FF31D22F2", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    productName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    amout = table.Column<int>(type: "int", nullable: false),
                    numberLove = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sizeList = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    colorList = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    imgUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    imgName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    price = table.Column<double>(type: "float", nullable: false),
                    discount = table.Column<double>(type: "float", nullable: true),
                    idBrand = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    idProductTypes = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    isDelete = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Product__3213E83FABE75C78", x => x.id);
                    table.ForeignKey(
                        name: "FK__Product__idBrand__44FF419A",
                        column: x => x.idBrand,
                        principalTable: "brand",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__Product__idProdu__45F365D3",
                        column: x => x.idProductTypes,
                        principalTable: "ProductTypes",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    email = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    pass = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    roleId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    phoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    addressUser = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    imgUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    imgName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    isDelete = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__User__3213E83FF581A029", x => x.id);
                    table.ForeignKey(
                        name: "FK__User__roleId__3B75D760",
                        column: x => x.roleId,
                        principalTable: "Role",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Cart",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    userId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    totalProducts = table.Column<double>(type: "float", nullable: true),
                    isOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cart__3213E83F024A81D4", x => x.id);
                    table.ForeignKey(
                        name: "FK__Cart__userId__49C3F6B7",
                        column: x => x.userId,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CartDetail",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    idCart = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    idProduct = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: true),
                    totalMoney = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CartDeta__3213E83FC7F4B31B", x => x.id);
                    table.ForeignKey(
                        name: "FK__CartDetai__idCar__4BAC3F29",
                        column: x => x.idCart,
                        principalTable: "Cart",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__CartDetai__idPro__4CA06362",
                        column: x => x.idProduct,
                        principalTable: "Product",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "OrderUser",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false, defaultValueSql: "(newid())"),
                    idCart = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    idDiscount = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    total = table.Column<double>(type: "float", nullable: true),
                    orderDate = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrderUse__3213E83F917BBC51", x => x.id);
                    table.ForeignKey(
                        name: "FK__OrderUser__idCar__534D60F1",
                        column: x => x.idCart,
                        principalTable: "Cart",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__OrderUser__idDis__5441852A",
                        column: x => x.idDiscount,
                        principalTable: "Discount",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cart_userId",
                table: "Cart",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_idCart",
                table: "CartDetail",
                column: "idCart");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetail_idProduct",
                table: "CartDetail",
                column: "idProduct");

            migrationBuilder.CreateIndex(
                name: "IX_OrderUser_idCart",
                table: "OrderUser",
                column: "idCart");

            migrationBuilder.CreateIndex(
                name: "IX_OrderUser_idDiscount",
                table: "OrderUser",
                column: "idDiscount");

            migrationBuilder.CreateIndex(
                name: "IX_Product_idBrand",
                table: "Product",
                column: "idBrand");

            migrationBuilder.CreateIndex(
                name: "IX_Product_idProductTypes",
                table: "Product",
                column: "idProductTypes");

            migrationBuilder.CreateIndex(
                name: "IX_User_roleId",
                table: "User",
                column: "roleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartDetail");

            migrationBuilder.DropTable(
                name: "OrderUser");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Cart");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "brand");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Role");
        }
    }
}
