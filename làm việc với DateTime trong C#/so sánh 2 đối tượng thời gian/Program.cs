using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Bạn có thể so sánh hai đối tượng DateTime trong C#
            // bằng cách sử dụng phương thức
            // DateTime.Compare(DateTime t1, DateTime t2)

            // Phương thức này trả về một giá trị nguyên số,
            // cho biết mối quan hệ giữa hai đối tượng DateTime.

            // Nếu giá trị trả về là:
            // Âm: t1 sớm hơn t2.
            // Không: t1 và t2 bằng nhau.
            // Dương: t1 muộn hơn t2.


            DateTime date1 = new DateTime(2023, 11, 9, 23, 59, 59);
            DateTime date2 = new DateTime(2023, 11, 10, 0, 0, 0);


            int result = DateTime.Compare(date1, date2);


            string relationship;


            if (result < 0)
                relationship = "sớm hơn";
            else if (result == 0)
                relationship = "giống nhau";
            else
                relationship = "muộn hơn";


            Console.WriteLine("{0} {1} {2}", date1, relationship, date2);


            // cách 2:
            // string relationship = result < 0 ? "sớm hơn" : result == 0 ? "giống nhau" : "muộn hơn";

        }
    }
}