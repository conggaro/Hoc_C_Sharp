using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng thời gian
            DateTime dt1 = new DateTime(2024, 1, 31);


            // tạo đối tượng thời gian
            DateTime dt2 = new DateTime(2025, 1, 31);


            // in ra đối tượng thời gian
            Console.WriteLine(dt1.ToString("dd/MM/yyyy"));
            Console.WriteLine(dt2.ToString("dd/MM/yyyy"));


            // để trừ thời gian trong C#
            // bạn có thể sử dụng phương thức Subtract()
            // của lớp DateTime
            // phương thức Subtract()
            // sẽ trả về đối tượng có kiểu dữ liệu TimeSpan
            TimeSpan length = dt2.Subtract(dt1);


            // sau đó, bạn có thể sử dụng thuộc tính sau:
            // 1. TotalDays
            // 2. TotalHours
            // 3. TotalMinutes
            // 4. TotalSeconds
            // 5. TotalMilliseconds

            // để lấy giá trị khoảng cách giữa
            // hai đối tượng thời gian theo đơn vị tương ứng
            Console.WriteLine("Khoang cach giua dt1 va dt2 la: {0}", length.TotalDays);
        }
    }
}