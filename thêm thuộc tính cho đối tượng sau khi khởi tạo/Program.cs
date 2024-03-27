using System;
using System.Dynamic;

/*
    Nếu bạn muốn thêm phương thức
    cho một đối tượng sau khi nó
    đã được khởi tạo trong C#,
    bạn có thể sử dụng một số cách như sau:

    Sử dụng delegate hoặc Action/Func:
    Bạn có thể sử dụng delegate hoặc Action/Func
    để thêm một hành động hoặc hàm vào đối tượng.
    Điều này cho phép bạn gán một phương thức
    cho một biến và sau đó gọi nó
    như là một phương thức của đối tượng.

    Sử dụng Reflection:
    Bạn có thể sử dụng Reflection
    để thêm một phương thức vào một đối tượng
    tại thời điểm chạy của ứng dụng.
    Tuy nhiên, điều này thường là
    không khuyến khích vì nó có thể gây ra
    các vấn đề về hiệu suất và khả năng bảo trì.

    Sử dụng dynamic objects:
    Tương tự như việc thêm thuộc tính,
    bạn có thể sử dụng ExpandoObject
    hoặc DynamicObject để mở rộng đối tượng
    và thêm phương thức vào nó.
*/

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            dynamic obj = new ExpandoObject();



            // Thêm thuộc tính Age với giá trị là 30
            obj.Age = 30;

            // In giá trị thuộc tính Age
            Console.WriteLine($"Age: {obj.Age}");



            #region Thêm phương thức 1
            // Thêm phương thức SayHello cho đối tượng obj
            obj.SayHello = new Action<string>
            (
                (text) => {
                    Console.WriteLine(text);
                }
            );

            // Gọi phương thức SayHello
            obj.SayHello("Hello from dynamic object!");
            #endregion



            #region Thêm phương thức 2
            // Thêm phương thức TestShow cho đối tượng obj
            obj.TestShow = new Action
            (
                () => {
                    Console.WriteLine("Here there are no parameters");
                }
            );

            // Gọi phương thức TestShow
            obj.TestShow();
            #endregion



            #region Thêm phương thức 3
            // Thêm phương thức TinhTong cho đối tượng obj
            // đây là loại Func có tham số
            // int thứ nhất trong Func<int, int, int> là kiểu dữ liệu của x1
            // int thứ hai trong Func<int, int, int> là kiểu dữ liệu của x2
            // int thứ ba là kiểu trả về

            // nếu bạn không muốn truyền tham số
            // thì bạn xóa int thứ nhất và int thứ hai
            // chỉ để lại int thứ 3
            obj.TinhTong = new Func<int, int, int>
            (
                (x1, x2) => {
                    int tong = x1 + x2;
                    
                    return tong;
                }
            );

            // Gọi phương thức TinhTong
            int sum =  obj.TinhTong(5, 6);
            Console.WriteLine("This is sum = " + sum);
            #endregion
        }
    }
}