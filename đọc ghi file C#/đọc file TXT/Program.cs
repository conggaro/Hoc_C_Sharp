using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Noi dung trong file:");

            // sử dụng phương thức ReadAllText()
            string contentStr = File.ReadAllText(@"C:\DemoTEXT\demoContent.txt");

            Console.WriteLine(contentStr);



            Console.WriteLine("\n\nNoi dung trong file: ");

            // sử dụng phương thức ReadAllLines()
            string[] arrStr = File.ReadAllLines(@"C:\DemoTEXT\demoContent.txt");
            
            for (int i = 0; i < arrStr.Length; ++i)
            {
                Console.Write(i + ". ");
                Console.WriteLine(arrStr[i]);
            }
        }
    }
}