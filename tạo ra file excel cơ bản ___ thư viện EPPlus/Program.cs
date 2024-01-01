using System;
using System.Drawing;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;


/*
    Để cài đặt thư viện OfficeOpenXml trong một dự án C#

    CÁCH 1:
    1. Mở Visual Studio và mở dự án của bạn.
    
    2. Mở NuGet Package Manager Console (View > Other Windows > Package Manager Console).
    
    3. Chạy lệnh sau để cài đặt thư viện OfficeOpenXml:
    "Install-Package EPPlus"

    4. Đợi cho quá trình cài đặt hoàn tất.



    CÁCH 2:
    tìm kiếm với từ khóa "EPPlus" ở trong "Manage NuGet Packages"
*/


namespace MyApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                // thiết lập chứng chỉ phi thương mại "NonCommercial"
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


                // khai báo đường dẫn
                string filePath = @"C:\DemoExcel\ReportDemo.xlsx";


                // tạo đối tượng "file"
                FileInfo file = new FileInfo(filePath);


                // khai báo đối tượng danh sách
                List<HumanModel> listHuman = GetSetupData();


                // gọi hàm SaveExcelFile()
                // để tạo ra file excel
                // và lưu file đó theo đường dẫn
                // "C:\DemoExcel\ReportDemo.xlsx"
                await SaveExcelFile(listHuman, file);


                // gọi hàm LoadExcelFile()
                // để lấy dữ liệu từ file excel
                // rồi đổ dữ liệu vào
                // đối tượng danh sách listFromExcel
                List<HumanModel> listFromExcel = await LoadExcelFile(file);


                foreach (var item in listFromExcel)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                // bắn ra thông báo lỗi
                Console.WriteLine($"Thong bao loi: {ex.Message}");
            }
        }


        // tạo hàm mô phỏng công việc lấy dữ liệu
        public static List<HumanModel> GetSetupData()
        {
            // tạo đối tượng danh sách
            // mặc định bên trong có sẵn 3 phần tử
            List<HumanModel> list = new List<HumanModel>()
            {
                new HumanModel() { Id = 1, FullName = "Nguyen Van A" },
                new HumanModel() { Id = 2, FullName = "Nguyen Van B" },
                new HumanModel() { Id = 3, FullName = "Nguyen Van C" }
            };

            // thêm phần tử vào đối tượng danh sách
            list.Add(new HumanModel() { Id = 4, FullName = "Nguyen Van D" });
            list.Add(new HumanModel() { Id = 5, FullName = "Nguyen Van E" });
            list.Add(new HumanModel() { Id = 6, FullName = "Nguyen Van F" });

            return list;
        }

        // tạo hàm lưu file excel
        public static async Task SaveExcelFile(List<HumanModel> list, FileInfo file)
        {
            // gọi hàm xóa nếu đã tồn tại file
            DeleteIfExist(file);

            // sử dụng tài nguyên
            // bằng từ khóa "using"
            using (ExcelPackage package = new ExcelPackage(file))
            {
                // tạo đối tượng ExcelWorksheet
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Đây là báo cáo");


                // tạo đối tượng ExcelRangeBase
                ExcelRangeBase range = ws.Cells["A2"].LoadFromCollection(list, true);


                // AutoFitColumns sẽ tự động điều chỉnh kích thước của cột
                // để vừa vặn với nội dung lớn nhất trong cột
                range.AutoFitColumns();


                // viết tiêu đề cho báo cáo vào ô A1
                ws.Cells["A1"].Value = "Tiêu đề báo cáo";


                // thiết lập gộp từ ô A1 đến ô C1
                ws.Cells["A1:C1"].Merge = true;


                // thiết lập căn giữa cho cột A
                // cột A thì tương đương với số 1
                // Horizontal là "nằm ngang"
                // Alignment là "căn chỉnh"
                ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;


                // thiết lập cỡ chữ cho dòng 1
                ws.Row(1).Style.Font.Size = 24;


                // thiết lập màu chữ "xanh nước biển"
                ws.Row(1).Style.Font.Color.SetColor(Color.Blue);


                ws.Row(2).Style.HorizontalAlignment= ExcelHorizontalAlignment.Center;


                // thiết lập chữ đậm
                ws.Row(2).Style.Font.Bold = true;


                // thiết lập độ rộng cho cột B là 20
                // cột B thì tương đương với số 2
                ws.Column(2).Width = 20;


                // lưu file excel
                await package.SaveAsync();


                // giải phóng tài nguyên
                // nó sẽ làm cho biến "package" bị xóa đi
                // giúp cho bộ nhớ trên RAM không bị lãng phí
                package.Dispose();
            }
        }


        // tạo hàm xóa file
        public static void DeleteIfExist(FileInfo file)
        {
            if (file.Exists)
            {
                file.Delete();
            }
        }


        // tạo hàm lấy dữ liệu từ file excel
        public static async Task<List<HumanModel>> LoadExcelFile(FileInfo file)
        {
            // tạo đối tượng danh sách
            List<HumanModel> list = new List<HumanModel>();


            // tạo đối tượng "package"
            using (ExcelPackage package = new ExcelPackage(file))
            {
                // gọi phương thức LoadAsync()
                // để tải dữ liệu từ file
                // vào đối tượng
                await package.LoadAsync(file);


                // tạo đối tượng "ws"
                ExcelWorksheet ws = package.Workbook.Worksheets[0];


                // khai báo dòng và cột
                int row = 3;
                int col = 1;


                // sử dụng vòng lặp while()
                // để thêm phần tử vào danh sách
                while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
                {
                    // tạo đối tượng "object_human"
                    HumanModel object_human = new HumanModel();

                    // gán giá trị cho các thuộc tính
                    object_human.Id = int.Parse(ws.Cells[row, col].Value.ToString());
                    object_human.FullName = ws.Cells[row, col + 1].Value.ToString();

                    // thêm phần tử vào trong danh sách
                    list.Add(object_human);
                    
                    // tăng dòng lên 1
                    row = row + 1;
                }


                // giải phóng tài nguyên
                package.Dispose();
            }

            return list;
        }
    }


    // tạo lớp HumanModel
    public class HumanModel
    {
        public int? Id { get; set; }
        public string? FullName { get; set; }


        // ghi đè phương thức ToString()
        public override string ToString()
        {
            return $"[{Id}, {FullName}]";
        }
    }
}