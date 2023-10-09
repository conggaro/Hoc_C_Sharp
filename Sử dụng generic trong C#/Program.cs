using System;

namespace MyApp
{
    public class Program
    {
        // khai báo hàm generic đổi chỗ
        public static void Doi_Cho<T>(ref T a,ref T b){
            T temp;

            temp = a;
            a = b;
            b = temp;
        }

        public static void Main(string[] args)
        {
            int bien1 = 5;
            int bien2 = 99;

            Console.WriteLine("Ban dau:");
            Console.WriteLine(bien1);
            Console.WriteLine(bien2);

            Console.WriteLine();

            Console.WriteLine("Luc sau:");
            Doi_Cho<int>(ref bien1, ref bien2);
            Console.WriteLine(bien1);
            Console.WriteLine(bien2);
        }
    }
}