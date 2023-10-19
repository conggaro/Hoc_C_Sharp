using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // cho chuỗi string
            string str = "abc, def, xyz";


            // chuyển chuỗi string
            // thành danh sách List<string>

            // giải pháp là sử dụng phương thức Split()
            List<string> ds = str
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();


            // in ra danh sách
            Console.WriteLine("DANH SACH CAC PHAN TU STRING:");


            foreach (string item in ds)
            {
                Console.WriteLine(item);
            }
        }
    }
}