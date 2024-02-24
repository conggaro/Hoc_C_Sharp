using System;
using System.Reflection;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // tạo đối tượng
                Person person = new Person();

                // thiết lập giá trị cho các thuộc tính
                person.Id = 1;
                person.Name = "Test";

                // sử dụng lớp "Type"
                Type type = person.GetType();

                foreach (PropertyInfo property in type.GetProperties())
                {
                    // lấy ra tên của thuộc tính
                    string nameProperty = property.Name;

                    // lấy ra giá trị tương ứng
                    // với cái thuộc tính đó
                    object? valueProperty = property.GetValue(person);

                    if (nameProperty == "Name")
                    {
                        property.SetValue(person, "Nguyen Van A");

                        // thiết lập giá trị mới
                        // cho thuộc tính
                        valueProperty = property.GetValue(person);
                    }

                    // in ra màn hình tên thuộc tính
                    // và giá trị tương ứng
                    Console.WriteLine($"[Name: {nameProperty}, Value: {valueProperty}]");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }

    public class Person
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}