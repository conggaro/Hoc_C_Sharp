using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                ShowMessage("Done");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        // sử dụng thuộc tính Obsolete
        // để thông báo là cái hàm này đã lỗi thời
        [Obsolete("Hàm này đã lỗi thời, hãy dùng hàm khác.")]
        public static void ShowMessage(string paragraph)
        {
            Console.WriteLine(paragraph);
        }
    }
}