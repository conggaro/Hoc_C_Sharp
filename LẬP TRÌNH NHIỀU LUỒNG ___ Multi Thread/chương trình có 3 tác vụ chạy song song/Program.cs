using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // khai báo đối tượng "task1"
            Task task1 = new Task(
                // đây là biểu thức lambda
                () => {
                    for (int i = 1; i <= 5; i++)
                    {
                        // khóa đối tượng Console.Out
                        // để luồng này dùng xong màu chữ
                        // thì luồng khác mới được dùng màu chữ khác
                        lock (Console.Out)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(i);
                            Thread.Sleep(1000);
                            Console.ResetColor();
                        }
                    }
                }
            );


            // khai báo đối tượng "task2"
            Task task2 = new Task(
                // đây là biểu thức lambda
                () => {
                    for (int i = 1; i <= 10; i++)
                    {
                        lock (Console.Out)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(i);
                            Thread.Sleep(1000);
                            Console.ResetColor();
                        }
                    }
                }
            );


            // khai báo đối tượng "task3"
            Task task3 = new Task(
                // đây là biểu thức lambda
                (object item) => {
                    int number = (int)item;

                    for (int i = 1; i <= number; i++)
                    {
                        lock (Console.Out)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(i);
                            Thread.Sleep(1000);
                            Console.ResetColor();
                        }
                    }
                },

                // cái số 8 này sẽ được truyền
                // cho tham số "item"
                8
            );


            // chạy đối tượng "task1"
            task1.Start();

            // chạy đối tượng "task2"
            task2.Start();

            // chạy đối tượng "task2"
            task3.Start();



            // bắt chương trình đợi các tác vụ chạy xong
            // thì mới cho kết thúc chương trình.

            // nếu không bắt chương trình đợi
            // thì có thể chương trình kết thúc luôn
            // trong khi các tác vụ chưa chạy xong.
            Task[] tasks = { task1, task2, task3 };
            Task.WaitAll(tasks);
        }
    }
}