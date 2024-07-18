using System;
using System.Threading.Tasks;

/*
    Parallel.For trong C# là một phương thức
    được cung cấp bởi thư viện TPL
    (Task Parallel Library) để thực hiện các vòng lặp song song.

    Điều này cho phép bạn chạy các tác vụ lặp lại
    đồng thời trên nhiều luồng,
    tận dụng tốt hơn khả năng đa nhân của CPU
    để tăng hiệu suất thực thi.

    Tóm Lại
    Parallel.For là một công cụ mạnh mẽ
    để tăng tốc độ thực hiện các vòng lặp trong C#.
    
    Tuy nhiên, cần phải cẩn thận khi sử dụng
    để tránh các vấn đề liên quan đến đồng bộ hóa
    và tranh chấp tài nguyên.
*/

/*
    Khi Nào Nên Sử Dụng Parallel.For

    1. Khi bạn có một tác vụ lặp lại mà không phụ thuộc vào thứ tự thực hiện.
    2. Khi bạn muốn tận dụng khả năng đa nhân của CPU để cải thiện hiệu suất.
    3. Khi bạn đang thực hiện các tác vụ tính toán nặng nề hoặc xử lý dữ liệu lớn.
*/

/*
    Parallel.For có thể được sử dụng tương tự
    như vòng lặp for thông thường,
    nhưng các lần lặp sẽ được thực thi song song.

    Cú Pháp:
    Parallel.For(fromInclusive, toExclusive, body);
                
    fromInclusive: Giá trị bắt đầu của vòng lặp (bao gồm).
    toExclusive: Giá trị kết thúc của vòng lặp (không bao gồm).
    body: Hành động được thực thi trong mỗi lần lặp.
*/

namespace MyApp
{
    public class Program
    {
        public static void Main()
        {
            Example1();

            Example2();

            Example3();
        }

        public static void Example1()
        {
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine($"Index {i}, Square: {i * i}");
            });
        }

        public static void Example2()
        {
            int[] array = new int[10];

            Parallel.For(0, array.Length, i =>
            {
                array[i] = i * i;
            });

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
        }

        public static void Example3()
        {
            CancellationTokenSource cts = new CancellationTokenSource();

            ParallelOptions options = new ParallelOptions
            {
                MaxDegreeOfParallelism = 4, // Số lượng luồng tối đa
                CancellationToken = cts.Token // Hủy bỏ vòng lặp nếu cần
            };

            try
            {
                Parallel.For(0, 10, options, i =>
                {
                    if (i == 5)
                    {
                        cts.Cancel(); // Hủy bỏ vòng lặp khi i == 5
                    }

                    Console.WriteLine($"Index {i}, Thread Id: {Thread.CurrentThread.ManagedThreadId}");
                });
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was canceled.");
            }
        }
    }
}