﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Areas.Admin.Models
{
    public class SanPham
    {
        [Key]
        public int MaSanPham { get; set; }
        [DisplayName("Tên Sản Phẩm")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(maximumLength: 191, MinimumLength = 1, ErrorMessage = "Độ dài chuỗi từ 1 đến 191 kí tự")]
        public string TenSanPham { get; set; }
        [DisplayName("Hình ảnh")]
        public string HinhAnh { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Đơn giá không được để trống")]
        [StringLength(maximumLength: 100000000, MinimumLength = 1, ErrorMessage = "Độ dài từ 1 đến 100000000 ")]
        [DisplayName("Đơn giá")]
        public float DonGia { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mô tả không được để trống")]
        [StringLength(maximumLength: 2000, MinimumLength = 10, ErrorMessage = "Độ dài từ 10 đến 2000 ")]
        [DisplayName("Mô tả")]
        public string MoTa { get; set; }

        [DisplayName("Trạng thái")]
        public int TrangThai { get; set; } = 1; //defualt TrangThai = 1 
        [DisplayName("Mã loại sản phẩm")]
        public int MaLoai { get; set; }
        [ForeignKey("Mã loại")]  // Khoa ngoai la MaLoai
        public virtual  LoaiSP Loai { get; set; } //Tham chieu toi khoa chinh Id cua LoaiSP 
       
        public int MaNCC { get; set; }  
        [ForeignKey("MaNCC")]
        [DisplayName("Mã nhà cung cấp")]
        public virtual NhaCungCap NCC { get; set; }
    }
}
