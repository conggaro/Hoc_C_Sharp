using System;

namespace MyApp
{
    public enum GioiTinh
    {
        Nu = 0,
        Nam = 1,
        Khac = 2
    }

    public class ConNguoi
    {
        // dấu hỏi chấm chính là toán tử nullable
        // cách viết hay dùng int? x = null;
        // cách viết đầy đủ là Nullable<int> x = null;

        // bình thường int x = null;
        // thì sẽ bị báo lỗi

        // nhưng viết int? x = null thì không sao


        // thuộc tính họ tên
        public string? ho_ten {  get; set; }


        // thuộc tính tuổi
        public int? tuoi { get; set; }


        // thuộc tính giới tính
        public GioiTinh? gioi_tinh { get; set; }


        // thuộc tính phương tiện đi lại
        // đây là kiểu bản ghi trong C#
        public (string ten_xe, int so_banh) phuong_tien {  get; set; }


        // thuộc tính màu sắc
        public string? mau_sac {  get; set; }


        // hàm khởi tạo không tham số
        public ConNguoi()
        {
            ho_ten = string.Empty;
            tuoi = 0;
            gioi_tinh = GioiTinh.Khac;
            phuong_tien = (string.Empty, 0);
            mau_sac = string.Empty;
        }


        // ghi đè phương thức ToString()
        public override string ToString()
        {
            return $"[{ho_ten, -16} {tuoi, -6} {gioi_tinh, -6} ({$"{phuong_tien.ten_xe}, {phuong_tien.so_banh})", -20} {$"\"{mau_sac}\"", -30}]";
        }
    }
}
