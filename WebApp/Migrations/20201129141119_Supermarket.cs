using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class Supermarket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChuDe",
                columns: table => new
                {
                    MaChuDe = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenchude = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChuDe", x => x.MaChuDe);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMai",
                columns: table => new
                {
                    Makhuyenmai = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tenkhuyenmai = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhuyenMai", x => x.Makhuyenmai);
                });

            migrationBuilder.CreateTable(
                name: "LoaiSP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenloaiSP = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoaiSP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    MaNguoiDung = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenTaiKhoan = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhanQuyen = table.Column<int>(type: "int", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NguoiDung", x => x.MaNguoiDung);
                });

            migrationBuilder.CreateTable(
                name: "NhaCC",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNCC = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    SĐT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhaCC", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KhachHang",
                columns: table => new
                {
                    MaNVBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhDaiDien = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HoTenNVBan = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MaND = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KhachHang", x => x.MaNVBan);
                    table.ForeignKey(
                        name: "FK_KhachHang_NguoiDung_MaND",
                        column: x => x.MaND,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVienBanHang",
                columns: table => new
                {
                    MaNVBan = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTenNVBan = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MaND = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVienBanHang", x => x.MaNVBan);
                    table.ForeignKey(
                        name: "FK_NhanVienBanHang_NguoiDung_MaND",
                        column: x => x.MaND,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVienGiaoHang",
                columns: table => new
                {
                    MaNVGiao = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoTenNVGiao = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MaND = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVienGiaoHang", x => x.MaNVGiao);
                    table.ForeignKey(
                        name: "FK_NhanVienGiaoHang_NguoiDung_MaND",
                        column: x => x.MaND,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NhanVienQuanLi",
                columns: table => new
                {
                    MaNVQuanLi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhDaiDien = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    HoTenNVQuanLi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NgaySinh = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SDT = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MaND = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NhanVienQuanLi", x => x.MaNVQuanLi);
                    table.ForeignKey(
                        name: "FK_NhanVienQuanLi_NguoiDung_MaND",
                        column: x => x.MaND,
                        principalTable: "NguoiDung",
                        principalColumn: "MaNguoiDung",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    MaSanPham = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenSanPham = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    HinhAnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DonGia = table.Column<long>(type: "bigint", maxLength: 100000000, nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MaLoai = table.Column<int>(type: "int", nullable: false),
                    Mãloại = table.Column<int>(name: "Mã loại", type: "int", nullable: true),
                    MaNCC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SanPham", x => x.MaSanPham);
                    table.ForeignKey(
                        name: "FK_SanPham_LoaiSP_Mã loại",
                        column: x => x.Mãloại,
                        principalTable: "LoaiSP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SanPham_NhaCC_MaNCC",
                        column: x => x.MaNCC,
                        principalTable: "NhaCC",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoaDon",
                columns: table => new
                {
                    MaHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ngaylap = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GiamGia = table.Column<int>(type: "int", nullable: false),
                    TongTien = table.Column<long>(type: "bigint", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MaKH = table.Column<int>(type: "int", nullable: false),
                    MaKhuyenMai = table.Column<int>(type: "int", nullable: false),
                    HoaDonMaHD = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoaDon", x => x.MaHD);
                    table.ForeignKey(
                        name: "FK_HoaDon_HoaDon_HoaDonMaHD",
                        column: x => x.HoaDonMaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhachHang_MaKH",
                        column: x => x.MaKH,
                        principalTable: "KhachHang",
                        principalColumn: "MaNVBan",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoaDon_KhuyenMai_MaKhuyenMai",
                        column: x => x.MaKhuyenMai,
                        principalTable: "KhuyenMai",
                        principalColumn: "Makhuyenmai",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TinTuc",
                columns: table => new
                {
                    MaTinTuc = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HinhDaiDien = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tentieude = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NgayDang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoTa = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    TrangThai = table.Column<int>(type: "int", maxLength: 1000, nullable: false),
                    Matacgia = table.Column<int>(type: "int", nullable: false),
                    MaChuDe = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TinTuc", x => x.MaTinTuc);
                    table.ForeignKey(
                        name: "FK_TinTuc_ChuDe_MaChuDe",
                        column: x => x.MaChuDe,
                        principalTable: "ChuDe",
                        principalColumn: "MaChuDe",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TinTuc_NhanVienQuanLi_Matacgia",
                        column: x => x.Matacgia,
                        principalTable: "NhanVienQuanLi",
                        principalColumn: "MaNVQuanLi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietHoaDon",
                columns: table => new
                {
                    MaCTHD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Thanhtien = table.Column<long>(type: "bigint", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false),
                    MaHD = table.Column<int>(type: "int", nullable: false),
                    MaSP = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChiTietHoaDon", x => x.MaCTHD);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_HoaDon_MaHD",
                        column: x => x.MaHD,
                        principalTable: "HoaDon",
                        principalColumn: "MaHD",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChiTietHoaDon_SanPham_MaSP",
                        column: x => x.MaSP,
                        principalTable: "SanPham",
                        principalColumn: "MaSanPham",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaHD",
                table: "ChiTietHoaDon",
                column: "MaHD");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietHoaDon_MaSP",
                table: "ChiTietHoaDon",
                column: "MaSP");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_HoaDonMaHD",
                table: "HoaDon",
                column: "HoaDonMaHD");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKH",
                table: "HoaDon",
                column: "MaKH");

            migrationBuilder.CreateIndex(
                name: "IX_HoaDon_MaKhuyenMai",
                table: "HoaDon",
                column: "MaKhuyenMai");

            migrationBuilder.CreateIndex(
                name: "IX_KhachHang_MaND",
                table: "KhachHang",
                column: "MaND");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVienBanHang_MaND",
                table: "NhanVienBanHang",
                column: "MaND");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVienGiaoHang_MaND",
                table: "NhanVienGiaoHang",
                column: "MaND");

            migrationBuilder.CreateIndex(
                name: "IX_NhanVienQuanLi_MaND",
                table: "NhanVienQuanLi",
                column: "MaND");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_Mã loại",
                table: "SanPham",
                column: "Mã loại");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_MaNCC",
                table: "SanPham",
                column: "MaNCC");

            migrationBuilder.CreateIndex(
                name: "IX_TinTuc_MaChuDe",
                table: "TinTuc",
                column: "MaChuDe");

            migrationBuilder.CreateIndex(
                name: "IX_TinTuc_Matacgia",
                table: "TinTuc",
                column: "Matacgia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChiTietHoaDon");

            migrationBuilder.DropTable(
                name: "NhanVienBanHang");

            migrationBuilder.DropTable(
                name: "NhanVienGiaoHang");

            migrationBuilder.DropTable(
                name: "TinTuc");

            migrationBuilder.DropTable(
                name: "HoaDon");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "ChuDe");

            migrationBuilder.DropTable(
                name: "NhanVienQuanLi");

            migrationBuilder.DropTable(
                name: "KhachHang");

            migrationBuilder.DropTable(
                name: "KhuyenMai");

            migrationBuilder.DropTable(
                name: "LoaiSP");

            migrationBuilder.DropTable(
                name: "NhaCC");

            migrationBuilder.DropTable(
                name: "NguoiDung");
        }
    }
}
