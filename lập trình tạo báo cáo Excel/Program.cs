using System;
using System.ComponentModel;
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
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;


                // khai báo đường dẫn
                string filePath = @"C:\DemoExcel\ReportDemo.xlsx";


                // tạo đối tượng "file"
                FileInfo file = new FileInfo(filePath);


                // khai báo đối tượng danh sách
                List<TheReport> list = GetSetupData();


                // gọi hàm SaveExcelFile()
                // để tạo ra file excel
                // và lưu file đó theo đường dẫn
                // "C:\DemoExcel\ReportDemo.xlsx"
                await SaveExcelFile(list, file);


                // gọi hàm LoadExcelFile()
                // để lấy dữ liệu từ file excel
                // rồi đổ dữ liệu vào
                // đối tượng danh sách listFromExcel
                List<TheReport> listFromExcel = await LoadExcelFile(file);


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
        public static List<TheReport> GetSetupData()
        {
            // tạo đối tượng danh sách
            // mặc định bên trong có sẵn 3 phần tử
            List<TheReport> list = new List<TheReport>()
            {
                new TheReport() { ho_ten = "Nguyen Van A", muc_luong = 8000000, pctn_pccv = 0, diem_cd_cv = 20, lam_viec = 21.5, nghi_phep = 0, nghiLe_Tet = 1.5, vr_cl = 0 },
                new TheReport() { ho_ten = "Nguyen Van B", muc_luong = 12000000, pctn_pccv = 0, diem_cd_cv = 45, lam_viec = 22, nghi_phep = 1, nghiLe_Tet = 0, vr_cl = 0 },
                new TheReport() { ho_ten = "Nguyen Van C", muc_luong = 6000000, pctn_pccv = 0, diem_cd_cv = 78, lam_viec = 20, nghi_phep = 0, nghiLe_Tet = 0, vr_cl = 0 }
            };

            // thêm phần tử vào đối tượng danh sách
            list.Add(new TheReport() { ho_ten = "Nguyen Van D", muc_luong = 7500000, pctn_pccv = 0, diem_cd_cv = 60, lam_viec = 22, nghi_phep = 0, nghiLe_Tet = 0, vr_cl = 0 });
            list.Add(new TheReport() { ho_ten = "Nguyen Van E", muc_luong = 10255000, pctn_pccv = 0, diem_cd_cv = 85, lam_viec = 19, nghi_phep = 0, nghiLe_Tet = 0, vr_cl = 0 });
            list.Add(new TheReport() { ho_ten = "Nguyen Van F", muc_luong = 2175000, pctn_pccv = 0, diem_cd_cv = 58, lam_viec = 17, nghi_phep = 0, nghiLe_Tet = 0, vr_cl = 0 });

            return list;
        }

        // tạo hàm lưu file excel
        public static async Task SaveExcelFile(List<TheReport> list, FileInfo file)
        {
            // gọi hàm xóa nếu đã tồn tại file
            DeleteIfExist(file);

            // sử dụng tài nguyên
            // bằng từ khóa "using"
            using (ExcelPackage package = new ExcelPackage(file))
            {
                // tạo đối tượng ExcelWorksheet
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("Đây là báo cáo");


                // giả sử ngày làm việc trong tháng đấy là 22
                int ngay_lam_viec = 22;


                // cột lương tháng này sẽ được tính toán theo công thức
                // (mức lương + PCTN_PCCV) + (điểm_CD_CV * 75000)
                // (tổng bên trên) / tổng số ngày làm việc trong tháng đấy
                // sau đó nhân với (làm việc + nghỉ phép + nghỉ lễ, tết + VR CL)
                foreach (var item in list)
                {
                    var tinh_luong =  ((item.muc_luong + item.pctn_pccv) + (item.diem_cd_cv * 75000))
                                      / ngay_lam_viec
                                      * (item.lam_viec + item.nghi_phep + item.nghiLe_Tet + item.vr_cl);

                    item.luong_thang_nay = (long)RoundToNearestMultiple((double)tinh_luong, -2);
                }


                // Thiết lập font chữ cho toàn bộ worksheet
                ws.Cells.Style.Font.Name = "Times New Roman";           // Tên font chữ
                ws.Cells.Style.Font.Size = 12;                          // Kích thước font chữ
                ws.Cells.Style.Font.Color.SetColor(Color.Black);        // Màu chữ


                // tạo đối tượng ExcelRangeBase
                // và bắt đầu đổ dữ liệu vào excel từ dòng A9
                // dòng 9 sẽ là tiêu đề
                // từ dòng 10 trở đi mới là bản ghi
                ExcelRangeBase range = ws.Cells["A8"].LoadFromCollection(list, true);


                // AutoFitColumns sẽ tự động điều chỉnh kích thước của cột
                // để vừa vặn với nội dung lớn nhất trong cột
                range.AutoFitColumns();


                // viết tiêu đề cho báo cáo vào ô A1
                ws.Cells["A1"].Value = "TỔNG CÔNG TY THÉP VIỆT NAM - CTCP";


                // thiết lập gộp từ ô A1 đến ô F1
                ws.Cells["A1:F1"].Merge = true;


                // thiết lập "căn trái" cho cột A
                // cột A thì tương đương với số 1
                // Horizontal là "nằm ngang"
                // Alignment là "căn chỉnh"
                ws.Column(1).Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;


                // thiết lập cỡ chữ cho dòng 1
                // ws.Row(1).Style.Font.Size = 12;


                // thiết lập màu chữ "đen" cho dòng 1
                // ws.Row(1).Style.Font.Color.SetColor(Color.Black);


                // thiết lập chữ đậm cho dòng 1
                ws.Row(1).Style.Font.Bold = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["A3"].Value = $"THANH TOÁN TIỀN LƯƠNG VÀ PHỤ CẤP - THÁNG {DateTime.Now.Month}/{DateTime.Now.Year}";

                // gộp từ ô A3 đến R3
                ws.Cells["A3:R3"].Merge = true;

                // căn giữa ô A3 theo chiều ngang
                ws.Cells["A3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn giữa ô A3 theo chiều dọc
                // Vertical là thẳng đứng
                // Alignment là căn chỉnh
                ws.Cells["A3"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // thiết lập in đậm cho ô A3
                ws.Cells["A3"].Style.Font.Bold = true;

                // thiết lập độ rộng cho dòng 3
                ws.Row(3).Height = 27;



                // thiết lập nội dung theo ý thích
                ws.Cells["A4"].Value = "Ban công nghệ thông tin";

                // gộp ô A4 đến ô R4
                ws.Cells["A4:R4"].Merge = true;

                // căn chỉnh giữa ô A4 theo chiều ngang
                ws.Cells["A4:R4"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // thiết lập in đậm ô A4
                ws.Cells["A4"].Style.Font.Bold = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["A6"].Value = "STT";

                // căn chỉnh ô A6 ra giữa theo chiều ngang
                ws.Cells["A6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô A6 ra giữa theo chiều dọc
                ws.Cells["A6"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô A6 đến A8
                ws.Cells["A6:A8"].Merge = true;



                // thiết lập cho trường STT
                // của các bản ghi căn ra giữa
                ws.Cells[9, 1, 9 + (list.Count - 1), 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;



                // thiết lập nội dung theo ý thích
                ws.Cells["B6"].Value = "Họ và tên";

                // căn chỉnh ô B6 ra giữa theo chiều ngang
                ws.Cells["B6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô B6 ra giữa theo chiều dọc
                ws.Cells["B6"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô B6 đến B8
                ws.Cells["B6:B8"].Merge = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["C6"].Value = "Mức lương TBL";

                // căn chỉnh ô C6 ra giữa theo chiều ngang
                ws.Cells["C6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô C6 ra giữa theo chiều dọc
                ws.Cells["C6"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô C6 đến D6
                ws.Cells["C6:D6"].Merge = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["C7"].Value = "Mức lương";

                // căn chỉnh ô C7 ra giữa theo chiều ngang
                ws.Cells["C7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô C7 ra giữa theo chiều dọc
                ws.Cells["C7"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô C7 đến C8
                ws.Cells["C7:C8"].Merge = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["D7"].Value = "PCTN PCCV";

                // căn chỉnh ô D7 ra giữa theo chiều ngang
                ws.Cells["D7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô D7 ra giữa theo chiều dọc
                ws.Cells["D7"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô D7 đến D8
                ws.Cells["D7:D8"].Merge = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["E6"].Value = "Điểm CD CV";

                // căn chỉnh ô E6 ra giữa theo chiều ngang
                ws.Cells["E6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô E6 ra giữa theo chiều dọc
                ws.Cells["E6"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô E6 đến E8
                ws.Cells["E6:E8"].Merge = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["F6"].Value = "Ngày công";

                // căn chỉnh ô F6 ra giữa theo chiều ngang
                ws.Cells["F6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô F6 ra giữa theo chiều dọc
                ws.Cells["F6"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô F6 đến I6
                ws.Cells["F6:I6"].Merge = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["F7"].Value = "Làm việc";

                // căn chỉnh ô F7 ra giữa theo chiều ngang
                ws.Cells["F7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô F7 ra giữa theo chiều dọc
                ws.Cells["F7"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô F7 đến F8
                ws.Cells["F7:F8"].Merge = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["G7"].Value = "Nghỉ phép";

                // căn chỉnh ô G7 ra giữa theo chiều ngang
                ws.Cells["G7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô G7 ra giữa theo chiều dọc
                ws.Cells["G7"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô G7 đến G8
                ws.Cells["G7:G8"].Merge = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["H7"].Value = "Nghỉ lễ, Tết";

                // căn chỉnh ô H7 ra giữa theo chiều ngang
                ws.Cells["H7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô H7 ra giữa theo chiều dọc
                ws.Cells["H7"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô H7 đến H8
                ws.Cells["H7:H8"].Merge = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["I7"].Value = "VR CL";

                // căn chỉnh ô I7 ra giữa theo chiều ngang
                ws.Cells["I7"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô I7 ra giữa theo chiều dọc
                ws.Cells["I7"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô I7 đến I8
                ws.Cells["I7:I8"].Merge = true;



                // thiết lập nội dung theo ý thích
                ws.Cells["J6"].Value = "Lương tháng này";

                // căn chỉnh ô J6 ra giữa theo chiều ngang
                ws.Cells["J6"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // căn chỉnh ô J6 ra giữa theo chiều dọc
                ws.Cells["J6"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                // gộp từ ô J6 đến J8
                ws.Cells["J6:J8"].Merge = true;



                // thiết lập in đậm dòng 6, 7, 8
                ws.Row(6).Style.Font.Bold = true;
                ws.Row(7).Style.Font.Bold = true;
                ws.Row(8).Style.Font.Bold = true;



                // thiết lập cho chữ tự xuống dòng
                ws.Cells["A6:R8"].Style.WrapText = true;



                // thiết lập chiều cao dòng 6 là 27
                ws.Row(6).Height = 27;



                // tính toán số lượng cột
                int quantity_column = new TheReport().GetType().GetProperties().Count();



                // thiết lập đường viền
                // Thick là "đường viền dày"
                // Hair là "đường viền kiểu chấm chấm"
                // Thin là "đường viền kiểu mỏng"
                ws.Cells[6, 1, 9 + (list.Count - 1), quantity_column].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                ws.Cells[6, 1, 9 + (list.Count - 1), quantity_column].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                ws.Cells[6, 1, 9 + (list.Count - 1), quantity_column].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                ws.Cells[6, 1, 9 + (list.Count - 1), quantity_column].Style.Border.Left.Style = ExcelBorderStyle.Thin;



                // thiết lập độ rộng cho các cột
                for (int i = 1; i <= quantity_column; i++)
                {
                    ws.Column(i).Width = 20;
                }



                // thiết lập độ rộng cho cột B là 20
                // cột B thì tương đương với số 2
                // ws.Column(2).Width = 20;



                /*
                    nếu bạn thích viết 1 + 1
                    rồi trên excel nó sẽ tính ra số 2
                    thì viết code như này

                    ws.Cells["A18"].Formula = "= 1 + 1";
                    ws.Cells["A19"].Formula = "= ROUND(123456, -2)";
                */



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
        public static async Task<List<TheReport>> LoadExcelFile(FileInfo file)
        {
            // tạo đối tượng danh sách
            List<TheReport> list = new List<TheReport>();


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
                int row = 9;
                int col = 1;


                // sử dụng vòng lặp while()
                // để thêm phần tử vào danh sách
                while (string.IsNullOrWhiteSpace(ws.Cells[row, col].Value?.ToString()) == false)
                {
                    // tạo đối tượng "obj_report"
                    TheReport obj_report = new TheReport();

                    // gán giá trị cho các thuộc tính
                    obj_report.stt = int.Parse(ws.Cells[row, col].Value.ToString());
                    obj_report.ho_ten = ws.Cells[row, col + 1].Value.ToString();
                    obj_report.muc_luong = long.Parse(ws.Cells[row, col + 2].Value.ToString());
                    obj_report.pctn_pccv = long.Parse(ws.Cells[row, col + 3].Value.ToString());
                    obj_report.diem_cd_cv = double.Parse(ws.Cells[row, col + 4].Value.ToString());
                    obj_report.lam_viec = double.Parse(ws.Cells[row, col + 5].Value.ToString());
                    obj_report.nghi_phep = double.Parse(ws.Cells[row, col + 6].Value.ToString());
                    obj_report.nghiLe_Tet = double.Parse(ws.Cells[row, col + 7].Value.ToString());
                    obj_report.vr_cl = double.Parse(ws.Cells[row, col + 8].Value.ToString());
                    obj_report.luong_thang_nay = long.Parse(ws.Cells[row, col + 9].Value.ToString());

                    // thêm phần tử vào trong danh sách
                    list.Add(obj_report);

                    // tăng dòng lên 1
                    row = row + 1;
                }


                // giải phóng tài nguyên
                package.Dispose();
            }

            return list;
        }


        // hàm làm tròn giống ROUND(x; -2) của excel
        public static double RoundToNearestMultiple(double value, int roundTo)
        {
            double multiplier = Math.Pow(10, -roundTo);
            return Math.Round(value / multiplier) * multiplier;
        }
    }
}