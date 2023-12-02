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
            dt2.mau_sac = "";

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



            #region code của tôi viết (cách 1)
            // cách 1 có nhược điểm là mất công ánh xạ từng cái một
            // lúc viết code return đó.

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
                                    list_string = (x.mau_sac != null && x.mau_sac.Length > 0) ? x.mau_sac.Split(", ").ToList() : new List<string>()
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


                                // nếu bạn return như thế này
                                // thì bên trên bạn không phải tạo
                                // đối tượng danh sách sao chép
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
            Console.WriteLine("\n\nCACH 1: DANH SACH CON NGUOI (SAU KHI XU LY):");
            foreach (var tuple in queryList)
            {
                Console.WriteLine(tuple.ToString());
            }
            #endregion



            #region code của tôi viết (cách 2)
            /*
                mục đích tôi nghĩ cách 2
                là để bớt đi mấy cái đoạn viết code phải
                ánh xạ từng cái một
                rất mất thời gian và công sức.

                đây chính là ví dụ ánh xạ từng cái một.


                return new
                {
                    ho_ten = x.ho_ten,
                    tuoi = x.tuoi,
                    gioi_tinh = x.gioi_tinh,
                    phuong_tien = x.phuong_tien,

                    // chuyển chuỗi List<string> thành List<int>
                    list_int = x.list_string.Select(item => int.Parse(item)).ToList()
                };

            */


            // phải tạo đối tượng danh sách phiên bản sao chép
            // hay còn gọi là đối tượng danh sách clone
            // để không làm thay đổi dữ liệu bên trong đối tượng gốc "danhSach_ConNguoi"
            // vì lập trình hướng đối tượng
            // thì đối tượng danhSach_ConNguoi là kiểu tham chiếu reference đấy

            // chỉ có cách 2 mới phải tạo list_clone thôi

            // để clone danh sách thì
            // phải clone từng phần tử một
            
            // nếu dùng câu lệnh "new List<ConNguoi>(danhSach_ConNguoi)"
            // thì vẫn chưa clone được đâu
            // tại vì viết như này nó chưa sao chép được sâu vào trong các phần tử


            // tạo đối tượng danh sách sao chép
            List<ConNguoi> list_clone = new List<ConNguoi>();


            // bây giờ bắt đầu sao chép này
            foreach (var item in danhSach_ConNguoi)
            {
                list_clone.Add(item.Clone());
            }

            
            var queryList2 = list_clone
                            .Select(x =>
                            {
                                // tạo biến listString để chứa dữ liệu danh sách
                                // các phần tử có kiểu dữ liệu string
                                List<string> listString = (x.mau_sac != null && x.mau_sac.Length > 0) ? x.mau_sac.Split(", ").ToList() : new List<string>();

                                // gán đối tượng danh sách "listString"
                                // cho thuộc tính "x.list_string"
                                x.list_string = listString;

                                return x;
                            })
                            .Select(x =>
                            {
                                // viết code xử lý để đạt được kết quả mong muốn
                                // sau đó gán giá trị vào đối tượng listInt
                                List<int> listInt = (x.list_string != null) ? x.list_string.Select(item => int.Parse(item)).ToList() : new List<int>();

                                // lấy giá trị của đối tượng "listInt"
                                // đem gán cho thuộc tính "x.list_int"
                                x.list_int = listInt;

                                return x;
                            })
                            .Select(x =>
                            {
                                if (x.list_int != null)
                                {
                                    var list_TenMauSac = danhSach_MauSac
                                                        .Where(item => x.list_int.Contains(item.id))
                                                        .Select(item => item.ten_mau_sac)
                                                        .ToList();

                                    x.mau_sac = string.Join(", ", list_TenMauSac);
                                }
                                else
                                {
                                    x.mau_sac = "";
                                }

                                return x;
                            });


            // in ra danh sách con người
            Console.WriteLine("\n\nCACH 2: DANH SACH CON NGUOI 2 (SAU KHI XU LY):");
            foreach (var tuple in queryList2)
            {
                Console.WriteLine(tuple.ToString());
            }
            #endregion



            #region code của tôi viết (cách 3)
            List<ConNguoi> queryList3 = new List<ConNguoi>();


            foreach (var item in danhSach_ConNguoi)
            {
                queryList3.Add(item.Clone());
            }


            // cách 3 thì chỉ sửa bên trong thôi
            // dùng vòng lặp for()
            for (int i = 0; i < queryList3.Count(); i++)
            {
                if (queryList3[i].mau_sac != null && queryList3[i].mau_sac.Length > 0)
                {
                    // tạo list string
                    // để thêm tên màu sắc
                    // mỗi khi chạy vào If()
                    List<string> list_MauSac = new List<string>();


                    var list1 = queryList3[i].mau_sac.Split(", ").ToList();
                    
                    var list2 = list1.Select(x => int.Parse(x)).ToList();


                    foreach (var item in list2)
                    {
                        // nếu dùng switch...case...
                        // thì cũng được
                        // nhưng switch...case...
                        // là 1 dạng viết code cứng rồi, nó sẽ không linh hoạt
                        // khi thêm mới 1 phần tử màu sắc
                        // thì bạn sẽ phải sửa lại code chỗ switch...case...


                        // trong này tôi sẽ dùng 2 vòng lặp for()
                        for (int j = 0; j < danhSach_MauSac.Count(); j++)
                        {
                            if (item == danhSach_MauSac[j].id)
                            {
                                list_MauSac.Add(danhSach_MauSac[j].ten_mau_sac);
                                break;
                            }
                        }
                    }


                    queryList3[i].mau_sac = string.Join(", ", list_MauSac);
                }
                else
                {
                    queryList3[i].mau_sac = "";
                }
            }


            // in ra danh sách con người
            Console.WriteLine("\n\nCACH 3: DANH SACH CON NGUOI (SAU KHI XU LY):");
            foreach (var record in queryList3)
            {
                Console.WriteLine(record.ToString());
            }
            #endregion
        }
    }
}