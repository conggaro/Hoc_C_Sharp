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


            Console.WriteLine("In ra danh sach ten thuoc tinh:");


            // in ra danh sách tên thuộc tính
            // của đối tượng
            foreach (var item in dt.GetType().GetProperties())
            {
                
                Console.WriteLine(item.Name);
            }
        }
    }
}