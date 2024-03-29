using System;

/*
    Trong đoạn mã của bạn,
    string temp1 = str[..6]
    là một phần của cú pháp mới
    được giới thiệu trong C# 8.0 gọi là "Index from End" (chỉ số từ cuối).
    
    Điều này cho phép bạn truy cập
    các phần tử của một chuỗi từ cuối của chuỗi đó.

    Điều này là một cách ngắn gọn
    và tiện lợi hơn để cắt chuỗi từ cuối
    về đầu mà không cần phải tính toán vị trí index thủ công.
*/

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string str = "abcdef123456";

            
            // khi bạn chỉ muốn lấy 6 ký tự
            // tính từ đầu
            string temp1 = str[..6];


            // khi bạn muốn lấy 10 ký tự
            // tính từ đầu
            // thì bạn phải trừ đi 2 ký tự cuối
            string temp2 = str[..(str.Length - 2)];


            Console.WriteLine(str + "\n");
            Console.WriteLine(temp1 + "\n");
            Console.WriteLine(temp2);
        }
    }
}