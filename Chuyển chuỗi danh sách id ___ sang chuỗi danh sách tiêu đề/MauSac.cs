using System;

namespace MyApp
{
    public class MauSac
    {
        // thuộc tính id
        public int id { get; set; }


        // thuộc tính tên màu sắc
        public string? ten_mau_sac { get; set; }


        // hàm khởi tạo không tham số
        public MauSac()
        {
            id = 0;
            ten_mau_sac = string.Empty;
        }
    }
}
