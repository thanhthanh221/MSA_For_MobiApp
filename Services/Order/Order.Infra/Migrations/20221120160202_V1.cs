using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Infra.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trạng thái đơn hàng",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TrạngtháiĐơnhàng = table.Column<string>(name: "Trạng thái Đơn hàng", type: "nvarchar(100)", nullable: false),
                    Thôngtinđơnhàng = table.Column<string>(name: "Thông tin đơn hàng", type: "nvarchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trạng thái đơn hàng", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Đơn hàng",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Tênđơnhàng = table.Column<string>(name: "Tên đơn hàng", type: "varchar(255)", nullable: false),
                    Thờigiantạo = table.Column<DateTime>(name: "Thời gian tạo", type: "DATETIME", nullable: false),
                    Giá = table.Column<decimal>(type: "decimal", nullable: false),
                    Mãngườiđặt = table.Column<string>(name: "Mã người đặt", type: "varchar(255)", nullable: false),
                    TênNgườiĐặthàng = table.Column<string>(name: "Tên Người Đặt hàng", type: "varchar(255)", nullable: false),
                    Mãtrạngthái = table.Column<int>(name: "Mã trạng thái", type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Đơn hàng", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Đơn hàng_Trạng thái đơn hàng_Mã trạng thái",
                        column: x => x.Mãtrạngthái,
                        principalTable: "Trạng thái đơn hàng",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Địa chỉ",
                columns: table => new
                {
                    orderId = table.Column<string>(type: "varchar(255)", nullable: false),
                    ThànhphốTỉnh = table.Column<string>(name: "Thành phố/Tỉnh", type: "nvarchar(255)", nullable: false),
                    QuậnHuyện = table.Column<string>(name: "Quận/Huyện", type: "nvarchar(255)", nullable: false),
                    XãPhường = table.Column<string>(name: "Xã/Phường", type: "nvarchar(255)", nullable: false),
                    Đường = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Địachỉ = table.Column<string>(name: "Địa chỉ", type: "nvarchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Địa chỉ", x => x.orderId);
                    table.ForeignKey(
                        name: "FK_Địa chỉ_Đơn hàng_orderId",
                        column: x => x.orderId,
                        principalTable: "Đơn hàng",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sản phẩm đơn hàng",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false),
                    Mãsảnphẩm = table.Column<string>(name: "Mã sản phẩm", type: "varchar(255)", nullable: false),
                    Tênsảnphẩm = table.Column<string>(name: "Tên sản phẩm", type: "nvarchar(255)", nullable: false),
                    Giá = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Ảnh = table.Column<string>(type: "text", nullable: false),
                    Sốlượng = table.Column<int>(name: "Số lượng", type: "int", nullable: false),
                    Mãđơnhàng = table.Column<string>(name: "Mã đơn hàng", type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sản phẩm đơn hàng", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sản phẩm đơn hàng_Đơn hàng_Mã đơn hàng",
                        column: x => x.Mãđơnhàng,
                        principalTable: "Đơn hàng",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Đơn hàng_Mã trạng thái",
                table: "Đơn hàng",
                column: "Mã trạng thái");

            migrationBuilder.CreateIndex(
                name: "IX_Sản phẩm đơn hàng_Mã đơn hàng",
                table: "Sản phẩm đơn hàng",
                column: "Mã đơn hàng");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Địa chỉ");

            migrationBuilder.DropTable(
                name: "Sản phẩm đơn hàng");

            migrationBuilder.DropTable(
                name: "Đơn hàng");

            migrationBuilder.DropTable(
                name: "Trạng thái đơn hàng");
        }
    }
}
