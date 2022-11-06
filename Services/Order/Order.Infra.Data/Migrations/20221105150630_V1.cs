using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Order.Infra.Data.Migrations
{
    public partial class V1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "orderStatuses",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(20)", nullable: false),
                    TrạngtháiĐơnhàng = table.Column<string>(name: "Trạng thái Đơn hàng", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(20)", nullable: false),
                    Mãngườimua = table.Column<Guid>(name: "Mã người mua", type: "uniqueidentifier", nullable: false),
                    Tênngườimua = table.Column<string>(name: "Tên người mua", type: "nvarchar(20)", nullable: false),
                    Môtảđơnhàng = table.Column<string>(name: "Mô tả đơn hàng", type: "nvarchar(max)", nullable: true),
                    Đãlưu = table.Column<bool>(name: "Đã lưu", type: "bit", nullable: false),
                    Mãtrạngthái = table.Column<string>(name: "Mã trạng thái", type: "varchar(20)", nullable: false),
                    ThànhphốTỉnh = table.Column<string>(name: "Thành phố/Tỉnh", type: "nvarchar(max)", nullable: true),
                    QuậnHuyện = table.Column<string>(name: "Quận/Huyện", type: "nvarchar(max)", nullable: true),
                    XãPhường = table.Column<string>(name: "Xã/Phường", type: "nvarchar(max)", nullable: true),
                    Tuyếnđường = table.Column<string>(name: "Tuyến đường", type: "nvarchar(max)", nullable: true),
                    Địachỉ = table.Column<string>(name: "Địa chỉ", type: "nvarchar(max)", nullable: true),
                    Mãngườitạo = table.Column<string>(name: "Mã người tạo", type: "varchar(20)", nullable: false),
                    Thờigiantạo = table.Column<DateTime>(name: "Thời gian tạo", type: "datetime2", nullable: false),
                    Mãchỉnhsửa = table.Column<string>(name: "Mã chỉnh sửa", type: "varchar(20)", nullable: false),
                    Thờigiansửa = table.Column<DateTime>(name: "Thời gian sửa", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orders_orderStatuses_Mã trạng thái",
                        column: x => x.Mãtrạngthái,
                        principalTable: "orderStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(20)", nullable: false),
                    Mãđơnhàng = table.Column<string>(name: "Mã đơn hàng", type: "varchar(20)", nullable: false),
                    Mãsảnphẩm = table.Column<string>(name: "Mã sản phẩm", type: "nvarchar(20)", nullable: false),
                    Tênsảnphẩm = table.Column<string>(name: "Tên sản phẩm", type: "nvarchar(20)", nullable: false),
                    Ảnh = table.Column<string>(type: "text", nullable: false),
                    Giá = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    Giảmgiá = table.Column<decimal>(name: "Giảm giá", type: "DECIMAL", nullable: false),
                    Sốlượng = table.Column<int>(name: "Số lượng", type: "int", nullable: false),
                    Mãngườitạo = table.Column<string>(name: "Mã người tạo", type: "varchar(20)", nullable: false),
                    Thờigiantạo = table.Column<DateTime>(name: "Thời gian tạo", type: "datetime2", nullable: false),
                    Mãchỉnhsửa = table.Column<string>(name: "Mã chỉnh sửa", type: "varchar(20)", nullable: false),
                    Thờigiansửa = table.Column<DateTime>(name: "Thời gian sửa", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItems_orders_Mã đơn hàng",
                        column: x => x.Mãđơnhàng,
                        principalTable: "orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_Mã đơn hàng",
                table: "orderItems",
                column: "Mã đơn hàng");

            migrationBuilder.CreateIndex(
                name: "IX_orders_Mã trạng thái",
                table: "orders",
                column: "Mã trạng thái");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "orderStatuses");
        }
    }
}
