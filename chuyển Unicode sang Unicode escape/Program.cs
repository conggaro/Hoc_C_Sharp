using System;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Console.InputEncoding = Encoding.Unicode;
        Console.OutputEncoding = Encoding.Unicode;


        string input = "Từ ngày";
        string escaped = ToUnicodeEscape(input);
        Console.WriteLine("Original: " + input);
        Console.WriteLine("Escaped: " + escaped);
        Console.WriteLine(escaped == @"T\1EEB ng\00E0y");


        Console.WriteLine("\n");


        string input2 = "Đến ngày";
        string escaped2 = ToUnicodeEscape(input2);
        Console.WriteLine("Original: " + input2);
        Console.WriteLine("Escaped: " + escaped2);
        Console.WriteLine(escaped2 == @"\0110\1EBFn ng\00E0y");


        Console.WriteLine("\n");


        string input3 = "Từ tháng";
        string escaped3 = ToUnicodeEscape(input3);
        Console.WriteLine("Original: " + input3);
        Console.WriteLine("Escaped: " + escaped3);


        Console.WriteLine("\n");


        string input4 = "Đến tháng";
        string escaped4 = ToUnicodeEscape(input4);
        Console.WriteLine("Original: " + input4);
        Console.WriteLine("Escaped: " + escaped4);
    }

    static string ToUnicodeEscape(string input)
    {
        StringBuilder sb = new StringBuilder();
        foreach (char c in input)
        {
            if (c > 127) // only escape non-ASCII characters
            {
                sb.AppendFormat("\\{0:X4}", (int)c);
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.ToString();
    }
}