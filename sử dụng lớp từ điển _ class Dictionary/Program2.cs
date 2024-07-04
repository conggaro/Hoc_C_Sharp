using System;
using System.Collections.Generic;

namespace MyApp
{
    public class Program
    {
        public static void Main()
        {
            // Tạo một Dictionary lưu trữ thông tin sinh viên
            Dictionary<int, string> studentInfo = new Dictionary<int, string>();

            // Thêm dữ liệu vào Dictionary
            studentInfo.Add(1001, "John Doe");
            studentInfo.Add(1002, "Jane Smith");
            studentInfo.Add(1003, "Michael Johnson");

            // In ra các cặp key-value trong Dictionary
            foreach (KeyValuePair<int, string> kvp in studentInfo)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }

            // Tìm kiếm thông tin sinh viên theo ID
            int searchId = 1002;
            if (studentInfo.ContainsKey(searchId))
            {
                Console.WriteLine($"Student with ID {searchId}: {studentInfo[searchId]}");
            }
            else
            {
                Console.WriteLine($"No student found with ID {searchId}");
            }

            // Chỉnh sửa thông tin sinh viên
            studentInfo[1003] = "Michael Williams";

            // Xóa một cặp key-value
            studentInfo.Remove(1001);

            Console.WriteLine("Updated student info:");
            foreach (KeyValuePair<int, string> kvp in studentInfo)
            {
                Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
            }
        }
    }
}