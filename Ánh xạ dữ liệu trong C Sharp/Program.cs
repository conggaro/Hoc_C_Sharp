using System;
using System.Reflection;
using System.Xml.Linq;

namespace MyApp
{
    // tạo lớp con người
    public class ConNguoi
    {
        // khai báo thuộc tính họ tên
        public string hoTen { get; set; }

        // khai báo thuộc tính tuổi
        public int tuoi { get; set; }

        // khai báo thuộc tính giới tính
        public bool gioiTinh { get; set; }


        // hàm khởi tạo không tham số
        public ConNguoi()
        {
            // Console.WriteLine("Khoi tao doi tuong");
        }


        // hàm hủy
        ~ConNguoi()
        {
            // Console.WriteLine("Da huy doi tuong");
        }
    }


    // khai báo kiểu dữ liệu liệt kê enum
    // có tên đại diện là GioiTinh
    public enum GioiTinh
    {
        Nu = 0,
        Nam = 1
    }


    // tạo lớp Program
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng danh sách
            List<ConNguoi> ds = new List<ConNguoi>();
            

            // thêm phần tử vào danh sách
            ds.Add(new ConNguoi() { hoTen = "Nguyen Van A", tuoi = 20, gioiTinh = true});
            ds.Add(new ConNguoi() { hoTen = "Pham Thi B", tuoi = 18, gioiTinh = false });
            ds.Add(new ConNguoi() { hoTen = "Nguyen Van C", tuoi = 25, gioiTinh = true });
            ds.Add(new ConNguoi() { hoTen = "Pham Thi D", tuoi = 30, gioiTinh = false });
            ds.Add(new ConNguoi() { hoTen = "Pham Thi E", tuoi = 28, gioiTinh = false });


            // in ra danh sách ban đầu
            Console.WriteLine("DANH SACH BAN DAU:");
            foreach (var item in ds)
            {
                Console.WriteLine($"[{item.hoTen}, {item.tuoi}, {item.gioiTinh}]");
            }


            // ánh xạ danh sách
            // trong JavaScript thì có phương thức map()
            // từ "map" trong tiếng Anh
            // dịch ra còn là "ánh xạ"

            // còn trong C# thì có phương thức Select()
            // khi sử dụng phương thức 
            // thì nó sẽ trả về kết quả
            // có kiểu dữ liệu là "IEnumerable"
            var danhSach_AnhXa = ds.Select(x => new
            {
                FirstName = x.hoTen.Substring(x.hoTen.LastIndexOf(" ") + 1, (x.hoTen.Length - 1) - x.hoTen.LastIndexOf(" ")),
                LastName = x.hoTen.Substring(0, x.hoTen.IndexOf(" ")),
                MiddleName = x.hoTen.Substring(x.hoTen.IndexOf(" ") + 1, (x.hoTen.LastIndexOf(" ") - 1) - x.hoTen.IndexOf(" ")),
                Age = x.tuoi,
                Gender = (x.gioiTinh == true) ? GioiTinh.Nam : GioiTinh.Nu
            });


            // in ra danh sách ánh xạ
            Console.WriteLine("\n\nDANH SACH ANH XA:");
            foreach (var item in danhSach_AnhXa)
            {
                Console.WriteLine($"[{item.FirstName}, {item.MiddleName}, {item.LastName}, {item.Age}, {item.Gender}]");
            }
        }
    }
}