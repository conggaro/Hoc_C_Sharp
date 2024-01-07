using System;
using System.Security.Cryptography;
using Newtonsoft.Json;


// sử dụng thư viện Newtonsoft.Json

// Từ "Deserialize" có nghĩa là chuyển đổi dữ liệu
// từ định dạng chuỗi JSON về dạng đối tượng
// trong ngôn ngữ lập trình.

// Từ "Serialize" có nghĩa là chuyển đổi dữ liệu
// từ dạng đối tượng trong ngôn ngữ lập trình
// về dạng chuỗi JSON.

// Lưu ý rằng định dạng ngày thời gian
// trong JSON phải tuân theo định dạng chuẩn của JSON,
// thường được mô tả bởi ISO 8601.

// Trong định dạng chuỗi thời gian ISO 8601,
// chữ "T" được sử dụng để ngăn cách
// giữa phần ngày (năm, tháng, ngày)
// và phần thời gian (giờ, phút, giây).

// Do đó, nếu bạn nhìn thấy một chuỗi thời gian
// trong định dạng "2023-01-01T12:34:56",
// chữ "T" ở giữa có nghĩa là "Thời gian"
// và được sử dụng để phân tách phần ngày
// và phần thời gian của dữ liệu thời gian.


namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // đọc file
            string json = System.IO.File.ReadAllText(@"C:\DemoJSON\human.json");

            // Deserialize Object là chuyển đổi tuần tự hóa

            // chuyển json sang object
            Human deserialized = JsonConvert.DeserializeObject<Human>(json);

            Console.WriteLine("In ra object:");
            Console.WriteLine("Ho ten: " + deserialized.fullName);
            Console.WriteLine("Tuoi: " + deserialized.age);
            Console.WriteLine("Ngu day: " + deserialized.wakeUp.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine("Di ngu: " + deserialized.goToBed.ToString("dd/MM/yyyy HH:mm:ss"));
            Console.WriteLine("Gioi tinh: " + deserialized.gender);
            Console.WriteLine("Dia chi: " + string.Join(", ", deserialized.address));

            // chuyển object sang json
            string serialized = JsonConvert.SerializeObject(deserialized);

            Console.WriteLine("\n\nIn ra JSON:");
            Console.WriteLine(serialized);
        }
    }
}