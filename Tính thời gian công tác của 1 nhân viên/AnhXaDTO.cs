using System;

namespace MyApp
{
    // tạo lớp ánh xạ DTO
    // DTO là viết tắt của "Data Transfer Object"
    // được sử dụng trong lập trình
    // để chuyển dữ liệu giữa các thành phần khác nhau
    // của một ứng dụng
    public class AnhXaDTO
    {
        public int ketQua_SoSanh {  get; set; }
        public string thong_bao {  get; set; }
        public double thoiGian_CongTac {  get; set; }
    }
}
