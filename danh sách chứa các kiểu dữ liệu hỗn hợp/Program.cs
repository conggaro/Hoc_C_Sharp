using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // danh sách hỗn hợp - mixed list
            List<object> mixedList = new List<object>();


            mixedList.Add(1);

            mixedList.Add("ABC");

            mixedList.Add(true);

            mixedList.Add(new Person() { Id = 1, Name = "C Sharp" });


            Console.WriteLine("Dung vong lap for de xu ly \"Danh sach hon hop\"");

            int index = 1;

            foreach (var item in mixedList)
            {
                switch (item.GetType().Name)
                {
                    case "Int32":
                        Console.WriteLine($"{index}. {item.GetType().Name}");
                        
                        // viết code xử lý theo ý thích ở đây

                        break;

                    case "String":
                        Console.WriteLine($"{index}. {item.GetType().Name}");

                        // viết code xử lý theo ý thích ở đây

                        break;

                    case "Boolean":
                        Console.WriteLine($"{index}. {item.GetType().Name}");

                        // viết code xử lý theo ý thích ở đây

                        break;

                    case "Person":
                        Console.WriteLine($"{index}. {item.GetType().Name}");

                        // viết code xử lý theo ý thích ở đây

                        break;

                    default:
                        Console.WriteLine("Chưa viết đúng tên kiểu dữ liệu");
                        break;
                }

                index++;
            }
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}