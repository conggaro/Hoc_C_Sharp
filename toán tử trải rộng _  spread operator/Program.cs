using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1, 2, 3 };
            int[] arr2 = new int[] { 4, 5, 6 };
            int[] arr3 = new int[] { 7, 8, 9 };


            // sử dụng toán tử trải rộng ".."
            // tiếng Anh là "Spread operator"
            int[] single = [..arr1,..arr2,..arr3];


            // in ra các phần tử trong mảng single
            foreach (int item in single)
            {
                Console.WriteLine(item);
            }
        }
    }
}