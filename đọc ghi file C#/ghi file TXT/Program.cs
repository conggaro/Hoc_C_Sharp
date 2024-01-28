using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string contentStr = "Ghi file C# khong kho";

            // sử dụng phương thức WriteAllText()
            // để ghi file
            File.WriteAllText(@"C:\DemoTEXT\out.txt", contentStr);

            // sử dụng phương thức ReadAllText()
            // để đọc file
            string contentFileOutput = File.ReadAllText(@"C:\DemoTEXT\out.txt");

            Console.WriteLine(contentFileOutput + "\n\n");



            // cách 1: dùng mảng
            //string[] arr = {
            //    "Ghi file C# khong kho",
            //    "Ghi tung dong vao file cung de khong kem"
            //};

            // cách 2: dùng danh sách
            List<string> list = new List<string>()
            {
                "Text 1",
                "Text 2",
                "Text 3"
            };

            // sử dụng phương thức WriteAllText()
            // để ghi từng dòng vào file
            File.WriteAllLines(@"C:\DemoTEXT\out2.txt", list);

            // sử dụng phương thức ReadAllLines()
            // để đọc từng dòng file
            string[] arrContent = File.ReadAllLines(@"C:\DemoTEXT\out2.txt");

            for (int i = 0; i < arrContent.Length; i++)
            {
                Console.WriteLine(arrContent[i]);
            }
        }
    }
}