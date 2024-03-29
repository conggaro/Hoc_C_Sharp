using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;

/*
    bạn phải cài đặt thư viện
    vào trong NuGet Package

    System.Linq.Dynamic.Core
    System.Linq
    System.Collections.Generic
*/

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo danh sách
            List<string> words = new List<string>
            {
                "apple",
                "banana",
                "cherry",
                "date",
                "elderberry"
            };


            // biểu thức lambda dưới dạng chuỗi
            // nó cũng là biểu thức điều kiện luôn
            string condition = "x => x.Length > 5";

            // Sử dụng phương thức Where để lọc các phần tử dựa trên điều kiện
            var result = words.AsQueryable().Where(condition);


            // cách 2:
            // var result2 = words.AsQueryable().Where("x => x.Length > @0", 5);


            // In ra các phần tử đã được lọc
            foreach (var word in result)
            {
                Console.WriteLine(word);
            }
        }
    }
}