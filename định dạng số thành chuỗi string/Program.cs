using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // cho số 123456789
            // yêu cầu định dạng nó thành 123,456,789
            int x = 123456789;


            // in ra số ban đầu
            Console.WriteLine("So ban dau:\n" + x);


            // định dạng lần 1
            string number_format = x.ToString("N0");


            // in ra kết quả sau khi định dạng lần 1
            Console.WriteLine("\nSo sau khi dinh dang lan 1 (Format USA):\n" + number_format);


            // nó đang định dạng theo kiểu Mỹ (USA)
            // nên kết quả sẽ là 123.456.789


            // để chuyển 123.456.789
            // thành 123,456,789
            // thì sử dụng phương thức Replace()


            // định dạng lần 2
            number_format = number_format.Replace(".", ",");


            // in ra kết quả sau khi định dạng lần 2
            Console.WriteLine("\nSo sau khi dinh dang lan 2 (Format Viet Nam):\n" + number_format);



            /*
                Trong ví dụ trên,
                chúng ta đã sử dụng chuỗi định dạng "N0"
                trong phương thức ToString().
                
                Ký tự 'N' chỉ định rằng chúng ta muốn định dạng số
                và '0' chỉ định rằng chúng ta muốn không có phần thập phân.
                
                Kết quả là số 123456789 đã được định dạng
                thành chuỗi "123.456.789".

                Lưu ý rằng cách định dạng số có thể được
                tùy chỉnh theo nhu cầu của bạn bằng cách
                sử dụng các chuỗi định dạng khác nhau.
            
                Ví dụ, nếu bạn muốn có phần thập phân
                với 2 chữ số sau dấu phẩy, bạn có thể
                sử dụng chuỗi định dạng "N2" thay vì "N0".
            */



            // cho số thực y = 6789.1234
            double y = 6789.1234;


            // in ra số thực ban đầu
            Console.WriteLine("\n\n\nSo thuc ban dau:\n" + y);


            // số thực sau khi định dạng
            string real_number = y.ToString("N1");


            // in ra kết quả sau khi định dạng
            Console.WriteLine("\nSo thuc sau khi dinh dang voi N1:\n" + real_number);
            
            Console.WriteLine("\nSo thuc sau khi dinh dang voi N2:\n" + y.ToString("N2"));
            
            Console.WriteLine("\nSo thuc sau khi dinh dang voi N3:\n" + y.ToString("N3"));
            
            Console.WriteLine("\nSo thuc sau khi dinh dang voi N4:\n" + y.ToString("N4"));

            Console.WriteLine("\nSo thuc sau khi dinh dang voi N5:\n" + y.ToString("N5"));

            Console.WriteLine("\nSo thuc sau khi dinh dang voi N6:\n" + y.ToString("N6"));
        }
    }
}