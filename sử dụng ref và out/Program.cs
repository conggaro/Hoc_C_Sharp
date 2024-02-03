using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // từ khóa "ref" và "out"
            // đều được sử dụng cho biến tham chiếu

            // sự khác nhau giữa "ref" và "out"
            // là "ref" thì phải gán cho nó 1 giá trị khi tạo biến
            // còn "out" thì không cần giá trị khi khởi tạo

            // nhưng mà lúc sau thì "out" vẫn phải gán giá trị
            // chỉ không bắt buộc phải gán giá trị khi khởi tạo ban đầu thôi

            

            int x = 10;

            // in ra giá bị ban đầu
            Console.WriteLine("Ban dau: " + x);

            // gọi hàm Increase_With_Ref()
            Increase_With_Ref(ref x);

            // in ra giá trị sau khi bị thay đổi
            Console.WriteLine("Luc sau: " + x);



            int y;

            // in ra giá bị ban đầu
            // vì không có giá trị ban đầu nên .NET không cho in ra màn hình
            // Console.WriteLine("\nBan dau: " + y);

            // gọi hàm Increase_With_Out()
            Increase_With_Out(out y, 20);

            // in ra giá trị sau khi bị thay đổi
            Console.WriteLine("\n\nSu dung out: " + y);
        }


        // hàm tăng biến lên 1 với "ref"
        public static void Increase_With_Ref(ref int parameter)
        {
            // tăng cái biến đấy lên 1
            parameter = parameter + 1;
        }


        // hàm tăng biến lên 1 với "out"
        public static void Increase_With_Out(out int parameter, int value)
        {
            // gán giá trị của "value" cho biến tham chiếu
            parameter = value;

            // tăng lên 1
            parameter = parameter + 1;
        }
    }
}