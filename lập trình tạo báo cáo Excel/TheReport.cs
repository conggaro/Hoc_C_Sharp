using System;

namespace MyApp
{
    public class TheReport
    {
        // biến tĩnh dùng để đếm
        public static int dem = 0;


        // thuộc tính "số thứ tự"
        public int? stt { get; set; }


        // thuộc tính "họ tên"
        public string? ho_ten { get; set; }


        // thuộc tính "mức lương"
        public long? muc_luong { get; set; }


        // thuộc tính "phụ cấp trách nhiệm - phụ cấp chức vụ"
        public long? pctn_pccv { get; set; }


        // thuộc tính "điểm chức danh - chức vụ"
        public double? diem_cd_cv { get; set; }


        // thuộc tính "làm việc"
        public double? lam_viec { get; set; }


        // thuộc tính "nghỉ phép"
        public double? nghi_phep { get; set; }


        // thuộc tính "nghỉ lễ - Tết"
        public double? nghiLe_Tet { get; set; }


        // thuộc tính "VR - CL"
        public double? vr_cl { get; set; }


        // thuộc tính "lương tháng này"
        public long? luong_thang_nay { get; set; }


        // hàm khởi tạo không tham số
        public TheReport()
        {
            // mỗi khi tạo đối tượng
            // có kiểu dữ liệu TheReport
            // thì biến đếm sẽ tăng lên 1
            dem = dem + 1;

            // sau đó sẽ gán cho
            // biến số thứ tự
            stt = dem;
        }


        // ghi đè phương thức ToString()
        public override string ToString()
        {
            return  $"[{stt, -5}" +
                    $"{ho_ten, -17}" +
                    $"{muc_luong, -12}" +
                    $"{pctn_pccv, -5}" +
                    $"{diem_cd_cv, -6}" +
                    $"{lam_viec.ToString().Replace(',', '.'), -8}" +
                    $"{nghi_phep.ToString().Replace(',', '.'),-6}" +
                    $"{nghiLe_Tet.ToString().Replace(',', '.'), -6}" +
                    $"{vr_cl.ToString().Replace(',', '.'), -6}" +
                    $"{luong_thang_nay, -12}" +
                    "]";
        }
    }
}