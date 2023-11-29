using System;

// chuyển danh sách Id
// sang danh sách tiêu đề

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo danh sách màu sắc
            // với mặc định là 2 phần tử
            List<MauSac> danhSach_MauSac = new List<MauSac>()
            {
                new MauSac() { id = 1, ten_mau_sac = "Do"},
                new MauSac() { id = 2, ten_mau_sac = "Cam" }
            };



            // sử dụng phương thức Add()
            // để thêm 1 phần tử vào danh sách
            danhSach_MauSac.Add(new MauSac() { id = 3, ten_mau_sac = "Vang" });



            // người ta còn gọi màu chàm là màu blue violet - xanh tím than
            // người ta còn gọi màu tím là màu violet

            // tạo đối tượng "list_temp"
            List<MauSac> list_temp = new List<MauSac>();
            list_temp.Add(new MauSac() { id = 4, ten_mau_sac = "Luc" });
            list_temp.Add(new MauSac() { id = 5, ten_mau_sac = "Lam" });
            list_temp.Add(new MauSac() { id = 6, ten_mau_sac = "Cham" });
            list_temp.Add(new MauSac() { id = 7, ten_mau_sac = "Tim" });
            list_temp.Add(new MauSac() { id = 8, ten_mau_sac = "Den" });
            list_temp.Add(new MauSac() { id = 9, ten_mau_sac = "Trang" });



            // sử dụng phương thức AddRange()
            // để thêm nhiều phần tử vào danh sách
            danhSach_MauSac.AddRange(list_temp);



            // in danh sách màu ra màn hình
            Console.WriteLine("DANH SACH MAU SACH:");
            foreach (var item in danhSach_MauSac)
            {
                Console.WriteLine($"[id = {item.id}, ten mau sac = {item.ten_mau_sac}]");
            }



            // tạo đối tượng con người 1
            ConNguoi dt1 = new ConNguoi()
            {
                ho_ten = "Nguyen Van A",
                tuoi = 20,
                gioi_tinh = GioiTinh.Nam,
                phuong_tien = ("Honda", 2),
                mau_sac = "1, 3, 4, 5, 6"
            };

            // tạo đối tượng con người 2
            ConNguoi dt2 = new ConNguoi();
            dt2.ho_ten = "Nguyen Thi B";
            dt2.tuoi = 25;
            dt2.gioi_tinh = GioiTinh.Nu;
            dt2.phuong_tien = ("Rolls-Royce", 4);
            dt2.mau_sac = "9";

            // tạo đối tượng con người 3
            ConNguoi dt3 = new ConNguoi();
            dt3.ho_ten = "Nguyen Thi D";
            dt3.tuoi = 33;
            dt3.gioi_tinh = GioiTinh.Nu;
            dt3.phuong_tien = ("Bugatti", 4);
            dt3.mau_sac = "8, 9";



            // tạo danh sách con người
            List<ConNguoi> danhSach_ConNguoi = new List<ConNguoi>();



            // thêm phần tử "con người"
            // vào "danh sách con người"
            danhSach_ConNguoi.Add(dt1);
            danhSach_ConNguoi.Add(dt2);
            danhSach_ConNguoi.Add(dt3);



            // in ra danh sách con người
            Console.WriteLine("\n\nDANH SACH CON NGUOI:");
            foreach (var record in danhSach_ConNguoi)
            {
                Console.WriteLine(record.ToString());
            }



            // bây giờ
            // kết quả mong muốn là chuyển
            // cái chuỗi string màu sắc toàn số
            // thành chữ
            // theo cái "id" tương ứng của danh sách màu sắc

            // ví dụ:
            // chuỗi "1, 3, 4, 5, 6"
            // sẽ trở thành "Do, Vang, Luc, Lam, Cham"


            #region code trí tuệ nhân tạo gợi ý
            Console.WriteLine("\n\nCHUYEN CHUOI MAU SAC SANG TEN MAU SAC:");

            // chuyển chuỗi màu sắc
            // thành chữ dựa trên ID tương ứng
            // trong danh sách màu sắc
            foreach (var conNguoi in danhSach_ConNguoi)
            {
                // tách chuỗi màu sắc thành mảng các ID
                string[] mauSacIds = conNguoi.mau_sac.Split(',');

                // chuỗi lưu trữ tên màu sắc đã chuyển đổi
                string mauSacTen = "";

                foreach (var mauSacId in mauSacIds)
                {
                    int id;
                    
                    if (int.TryParse(mauSacId.Trim(), out id))
                    {
                        // tìm màu sắc trong danh sách dựa trên ID
                        MauSac mauSac = danhSach_MauSac.Find(m => m.id == id);
                        
                        if (mauSac != null)
                        {
                            // thêm tên màu sắc vào chuỗi
                            mauSacTen += mauSac.ten_mau_sac + ", ";
                        }
                    }
                }

                if (!string.IsNullOrEmpty(mauSacTen))
                {
                    // xóa ký tự ',' và khoảng trắng cuối chuỗi
                    mauSacTen = mauSacTen.TrimEnd(',', ' ');
                }

                Console.WriteLine($"[{conNguoi.ho_ten}]: {mauSacTen}");
            }
            #endregion


            #region code của tôi viết
            var queryList = danhSach_ConNguoi
                            .Select(x =>
                            {
                                return new
                                {
                                    ho_ten = x.ho_ten,
                                    tuoi = x.tuoi,
                                    gioi_tinh = x.gioi_tinh,
                                    phuong_tien = x.phuong_tien,

                                    // chuyển chuỗi string thành List<string>
                                    list_string = (x.mau_sac != null) ? x.mau_sac.Split(", ").ToList() : "".Split(", ").ToList()
                                };
                            })
                            .Select(x =>
                            {
                                return new
                                {
                                    ho_ten = x.ho_ten,
                                    tuoi = x.tuoi,
                                    gioi_tinh = x.gioi_tinh,
                                    phuong_tien = x.phuong_tien,

                                    // chuyển chuỗi List<string> thành List<int>
                                    list_int = x.list_string.Select(item => int.Parse(item)).ToList()
                                };
                            })
                            .Select(x =>
                            {
                                var list_mau_sac_str =  danhSach_MauSac
                                                        .Where(item => x.list_int.Contains(item.id))
                                                        .Select(item => item.ten_mau_sac)
                                                        .ToList();

                                return new ConNguoi
                                {
                                    ho_ten = x.ho_ten,
                                    tuoi = x.tuoi,
                                    gioi_tinh = x.gioi_tinh,
                                    phuong_tien = x.phuong_tien,
                                    mau_sac = string.Join(", ", list_mau_sac_str)
                                };
                            });


            // in ra danh sách con người
            Console.WriteLine("\n\nDANH SACH CON NGUOI (SAU KHI XU LY):");
            foreach (var tuple in queryList)
            {
                Console.WriteLine(tuple.ToString());
            }
            #endregion
        }
    }
}