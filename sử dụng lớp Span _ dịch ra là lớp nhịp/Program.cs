using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 2, 3 };


            // sử dụng lớp "Span"
            // Span dịch ra là "nhịp"
            Span<int> spans = new Span<int>(arr);


            // in các phần tử
            // trong đối tượng spans
            // ra màn hình
            for (int i = 0; i < spans.Length; i++)
            {
                Console.WriteLine(spans[i]);
            }
        }
    }
}