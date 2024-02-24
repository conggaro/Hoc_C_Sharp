using System;

namespace MyApp
{
    public class Program
    {
        // kien truc cua delegate "architecture"
        // no se duoc khai bao trong class
        public delegate void DelegateShowLog(string paragraph);

        public static void Main(string[] args)
        {
            try
            {
                DelegateShowLog dsl;

                dsl = null;

                dsl += ShowInfo;

                dsl += ShowWarning;

                // ngoài ra còn có kiểu gán biểu thức lambda
                dsl += (string paragraph) =>
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(paragraph);
                    Console.ResetColor();
                };


                // dsl("Test Log");

                // để an toàn thì viết
                //if (dsl != null)
                //{
                //    dsl("Test Log");
                //}

                // hoặc viết
                dsl?.Invoke("Test log 123");



                // nếu bạn lười quá
                // không muốn khai báo delegate
                // thì sử dụng Func có sẵn trong C#
                // đây là loại có kiểu trả về
                Func<int, int, int> delegateSum = null;     // chữ int cuối cùng là kiểu trả về

                delegateSum += Sum;

                Console.WriteLine(delegateSum(1, 2));



                // ngoài ra còn có loại không cần kiểu trả về
                // nó là Action
                Action<string> delegateShow = null;

                delegateShow += ShowInfo;
                delegateShow += ShowWarning;

                delegateShow("This is Action");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void ShowInfo(string paragraph)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(paragraph);
            Console.ResetColor();
        }

        public static void ShowWarning(string paragraph)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(paragraph);
            Console.ResetColor();
        }

        public static int Sum(int a, int b)
        {
            return a + b;
        }
    }
}