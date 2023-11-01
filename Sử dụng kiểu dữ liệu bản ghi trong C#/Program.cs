using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // khai báo biến "nguoi1"
            // có kiểu dữ liệu bản ghi (Tuples type in C#)
            (string ho_ten, int tuoi, bool gioi_tinh) nguoi1 = ("Nguyen Van A", 20, true);


            // in ra màn hình
            Console.WriteLine("Ho ten: {0}\nTuoi: {1}\nGioi tinh: {2}", nguoi1.ho_ten, nguoi1.tuoi, nguoi1.gioi_tinh);
        }
    }
}