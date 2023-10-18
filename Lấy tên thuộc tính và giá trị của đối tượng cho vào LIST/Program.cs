using System;

namespace MyApp
{
    // tạo lớp con người
    public class ConNguoi
    {
        public string ho_ten { get; set;}
        public int tuoi { get; set;}
        public bool gioi_tinh { get; set;}
    }
    

    // tạo lớp Program
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng
            ConNguoi dt = new ConNguoi();
            
            
            // thiết lập giá trị
            dt.ho_ten = "Nguyen Van A";
            dt.tuoi = 20;
            dt.gioi_tinh = true;


            // tạo danh sách để chứa các tên thuộc tính
            List<string> ds_TenThuocTinh = new List<string>();


            // tạo danh sách để chứa các giá trị
            List<string> ds_GiaTri = new List<string>();


            // dùng vòng lặp foreach()
            // để thêm phần tử vào danh sách
            foreach (var item in dt.GetType().GetProperties())
            {
                // phần tử "tên thuộc tính"
                string ten_ThuocTinh = item.Name;

                // thêm phần tử "tên thuộc tính" vào danh sách
                ds_TenThuocTinh.Add(ten_ThuocTinh);

                // phần tử "giá trị"
                string gia_tri = item.GetValue(dt, null).ToString();

                // thêm phần tử "giá trị" vào danh sách
                ds_GiaTri.Add(gia_tri);
            }


            // in ra danh sách tên thuộc tính
            Console.WriteLine("DANH SACH TEN THUOC TINH:");
            foreach (string item in ds_TenThuocTinh)
            {
                Console.WriteLine(item);
            }


            // in ra danh sách giá trị
            Console.WriteLine("\n\nDANH SACH GIA TRI:");
            foreach (string item in ds_GiaTri)
            {
                Console.WriteLine(item);
            }


            // tạo biến "kết hợp"
            // để chuyển danh sách thành chuỗi string
            string ket_hop = string.Join(", ", ds_GiaTri);


            Console.WriteLine("\n\nChuoi string:\n" + ket_hop);
        }
    }
}