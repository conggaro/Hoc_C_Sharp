using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // cách sử dụng toán tử null coalescing ??
            // để gán giá trị mặc định là 10
            // cho biến x
            // nếu giá trị của x là null

            int? x = null;
            Console.WriteLine(x);

            x = x ?? 10;
            Console.WriteLine(x);


            // nó tương đương với câu lệnh
            //if (x == null)
            //{
            //    x = 10;
            //}
            //Console.WriteLine(x);
        }
    }
}