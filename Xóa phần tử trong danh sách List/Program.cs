using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng danh sách
            List<int> ds = new List<int>();


            // thêm phần tử vào danh sách
            ds.Add(1);
            ds.Add(2);
            ds.Add(3);
            ds.Add(4);
            ds.Add(5);
            ds.Add(6);
            ds.Add(7);
            ds.Add(8);
            ds.Add(9);
            ds.Add(10);


            // in ra danh sách ban đầu
            Console.WriteLine("Danh sach ban dau:");
            // in ra danh sách
            foreach (var item in ds)
            {
                Console.Write("{0} ", item);
            }



            // xóa phần tử tại vị trí thứ 0
            ds.RemoveAt(0);

            // in ra danh sách sau khi xóa
            Console.WriteLine("\n\nXoa phan tu co index = 0:");
            
            foreach (var item in ds)
            {
                Console.Write(item.ToString() + " ");
            }



            // xóa phần tử có giá trị là 5
            ds.Remove(5);

            // in ra danh sách sau khi xóa
            Console.WriteLine("\n\nXoa phan tu co gia tri = 5:");

            foreach (var item in ds)
            {
                Console.Write(item.ToString() + " ");
            }



            // xóa phần tử theo điều kiện
            // xóa phần tử lớn hơn hoặc bằng 8
            ds.RemoveAll(x => x >= 8);

            // in ra danh sách sau khi xóa
            Console.WriteLine("\n\nXoa phan tu lon hon hoac bang 8:");

            foreach (var item in ds)
            {
                Console.Write(item.ToString() + " ");
            }


            Console.WriteLine();
        }
    }
}