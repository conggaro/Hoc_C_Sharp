using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 1; i <= 5; i++)
            {
                // in ra màn hình "i"
                Console.WriteLine(i);

                // nghỉ 1 giây
                Thread.Sleep(1000);
            }
        }
    }
}