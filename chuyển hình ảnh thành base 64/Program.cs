class Program
{
    static void Main()
    {
        string imagePath = "C:\\Users\\CongPC\\Music\\Flag_of_Vietnam.svg.png"; // Thay đổi đường dẫn tới hình ảnh của bạn
        string base64String = ConvertImageToBase64(imagePath);

        Console.WriteLine(base64String);

        // nếu bạn muốn ghi file
        // File.WriteAllText(@"C:\Users\CongPC\Videos\file_out.txt", base64String);
    }

    static string ConvertImageToBase64(string imagePath)
    {
        byte[] imageBytes = File.ReadAllBytes(imagePath);
        return Convert.ToBase64String(imageBytes);
    }
}