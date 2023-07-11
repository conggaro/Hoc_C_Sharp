// sử dụng namespace System

// trong namespace System thì có lớp Console
// giúp nhập xuất dữ liệu

// cấu trúc của lập trình C#
// namespace thì chứa class

// trong class thì chứa biến, hàm (dùng từ khóa static)
// trong class thì chứa thuộc tính, phương thức (không dùng từ khóa static)

using System;

namespace MyApp{
    class Program{
        public static void Main(string[] args){
            // xóa màn hình console cũ
            Console.Clear();

            // tạo tiêu đề cho cửa sổ console
            // (dùng Command Prompt mới thấy)
            Console.Title = "Nhap xuat du lieu trong C#";

            // nhập họ tên
            Console.Write("Nhap ho ten: ");
            string ho_ten = Console.ReadLine();

            // in ra họ tên
            Console.Write("In ra ho ten: " + ho_ten + "\n\n");

            // nhập số

            // đây là cách 1:
            // nhập tuổi
            // tuổi thì có kiểu dữ liệu int
            Console.Write("Nhap tuoi: ");
            int tuoi = Convert.ToInt32(Console.ReadLine());

            // in ra tuổi
            Console.Write("In ra tuoi: " + tuoi + "\n\n");

            // đây là cách 2:
            // nhập điểm trung bình
            // điểm trung bình thì có kiểu double
            Console.Write("Nhap diem trung binh (vi du: 9,9): ");
            string str_diemTB = Console.ReadLine();
            double diemTB = double.Parse(str_diemTB);

            // in ra điểm trung bình
            // trong C#
            // thì số thập phân dùng dấu phẩy ","
            // dấu phẩy là định dạng theo nước Mỹ
            Console.Write("In ra diem trung binh: " + diemTB + "\n\n");

            /*
            nếu muốn tạo ra chương trình .exe hoặc .dll
            chương trình do C# tạo ra là .dll

            dùng lệnh "dotnet publish"

            publish nghĩa là xuất bản, công bố
            */
        }
    }
}