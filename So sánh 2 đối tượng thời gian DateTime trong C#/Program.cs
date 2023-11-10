using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // bạn có thể so sánh hai đối tượng DateTime trong C#
            // bằng cách sử dụng phương thức
            // DateTime.Compare(DateTime t1, DateTime t2)

            // phương thức này trả về một giá trị nguyên (int),
            // cho biết mối quan hệ giữa hai đối tượng DateTime.

            // nếu giá trị trả về là:
            // số âm: t1 sớm hơn t2.
            // số 0: t1 và t2 bằng nhau.
            // số dương: t1 muộn hơn t2.


            // tạo đối tượng thời gian
            DateTime date1 = new DateTime(2023, 11, 9, 23, 59, 59);
            DateTime date2 = new DateTime(2023, 11, 10, 0, 0, 0);


            // tạo biến kết quả
            int result = DateTime.Compare(date1, date2);


            // khai báo biến mối quan hệ "relationship"
            string relationship;


            if (result < 0)
            {
                // sớm hơn
                relationship = "som hon";
            }
            else if (result == 0)
            {
                // bằng nhau
                relationship = "bang nhau";
            }
            else
            {
                // muộn hơn
                relationship = "muon hon";
            }


            // in kết quả ra màn hình
            Console.WriteLine("{0} {1} {2}", date1.ToString("dd/MM/yyyy"), relationship, date2.ToString("dd/MM/yyyy"));


            // cách 2:
            // string relationship = result < 0 ? "sớm hơn" : result == 0 ? "giống nhau" : "muộn hơn";

        }
    }
}