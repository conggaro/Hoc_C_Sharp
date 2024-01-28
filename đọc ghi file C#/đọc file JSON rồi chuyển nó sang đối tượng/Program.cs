using System;
using System.Text.Json;


// thư viện System.Text.Json
// chỉ hỗ trợ .NET Core
// và .NET 5 trở lên

// nếu bạn sử dụng .NET cũ
// thì bạn phải sử dụng thư viện bên ngoài
// ví dụ: thư viện Newtonsoft.Json


namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // đường dẫn để đọc file
            string filePath = @"C:\DemoJSON\fileFormatJSON.txt";
            //string filePath = @"C:\DemoJSON\product.json";

            // tạo biến để lưu dữ liệu đọc được
            string contentFile = string.Empty;

            // tạo đối tượng
            // để lưu giá trị sau khi chuyển từ JSON
            // sang Object
            Product product = default;

            // kiểm tra file có tồn tại không
            if (File.Exists(filePath))
            {
                contentFile = File.ReadAllText(filePath);

                // gọi hàm kiểm tra
                // xem nội dung trong file có đúng địng dạng JSON không
                if (IsValidJson(contentFile) == true)
                {
                    product = JsonSerializer.Deserialize<Product>(contentFile);

                    // in ra đối tượng
                    Console.WriteLine("In ra doi tuong:\n" + product.ToString() + "\n\n");
                }
            }

            // in ra file đọc được
            Console.WriteLine("In ra noi dung:\n" + contentFile + "\n");
        }


        // hàm kiểm tra nội dung trong file
        // có phải định dạng JSON không
        public static bool IsValidJson(string jsonString)
        {
            try
            {
                // Sử dụng JsonDocument.TryParse để kiểm tra đúng định dạng JSON
                JsonDocument doc = JsonDocument.Parse(jsonString);
                return true;
            }
            catch (JsonException)
            {
                return false;
            }
        }
    }


    public class Product
    {
        public int? Id { get; set; }
        public string? ProductName { get; set; }


        // khai báo constructor
        // để thiết lập giá trị mặc định cho thuộc tính
        public Product()
        {
            Id = null;
            ProductName = null;
        }


        // ghi đè phương thức ToString()
        public override string ToString()
        {
            return $"[{Id}, {ProductName}]";
        }
    }
}