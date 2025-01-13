class Program
{
    static void Main()
    {
        string filePathSource = "C:\\Users\\CongPC\\Music\\vjp.txt";

        // Đọc toàn bộ nội dung file
        string content = File.ReadAllText(filePathSource);

        string base64String = content;

        string filePath = "C:\\Users\\CongPC\\Videos\\file.png"; // Đường dẫn nơi bạn muốn lưu tệp hình ảnh

        ConvertBase64ToFile(base64String, filePath);
        Console.WriteLine("Tệp hình ảnh đã được lưu thành công!");
    }

    static void ConvertBase64ToFile(string base64String, string filePath)
    {
        // Giải mã chuỗi Base64 thành mảng byte
        byte[] fileBytes = Convert.FromBase64String(base64String);

        // Ghi mảng byte vào tệp
        File.WriteAllBytes(filePath, fileBytes);
    }
}