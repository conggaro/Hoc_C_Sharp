using System;
using System.Text;

namespace MyApp
{
    class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Ký tự Unicode đầu vào
            char inputChar = 'ỳ';

            // Chuyển đổi ký tự thành hexadecimals
            string hexString = ConvertCharToHex(inputChar);

            // In ra kết quả
            Console.WriteLine("input: " + inputChar + "\n");

            Console.WriteLine("unicode to hexadecimal: " + hexString + "\n");

            Console.WriteLine("hexadecimal to unicode: " + HexToUnicode(hexString));
        }

        public static string ConvertCharToHex(char input)
        {
            // Lấy mã Unicode của ký tự và định dạng nó
            string hex = ((int)input).ToString("X4");

            // Trả về chuỗi định dạng "\XXXX"
            return @"\" + hex;
        }

        public static string HexToUnicode(string hex)
        {
            // Nếu có ký tự '\' ở đầu, loại bỏ nó
            if (hex.StartsWith("\\"))
            {
                hex = hex.TrimStart('\\');
            }

            // Chuyển đổi chuỗi hex thành số nguyên
            int code = Convert.ToInt32(hex, 16);

            // Chuyển số nguyên thành ký tự Unicode
            return char.ConvertFromUtf32(code);
        }

    }
}