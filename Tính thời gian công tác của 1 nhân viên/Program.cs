using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng danh sách
            // các phần tử bên trong danh sách
            // thì có kiểu dữ liệu "QuaTrinhCongTac"
            List<QuaTrinhCongTac> ds = new List<QuaTrinhCongTac>();



            // thêm các phần tử vào danh sách
            ds.Add(new QuaTrinhCongTac {
                StartDate = new DateTime(2023, 1, 1),
                EndDate = new DateTime(2023, 1, 31),

                // ngày hiện tại nhỏ hơn ngày EndDate
                NowDate = new DateTime(2023, 1, 25)
            });

            ds.Add(new QuaTrinhCongTac
            {
                StartDate = new DateTime(2023, 2, 1),
                EndDate = new DateTime(2023, 2, 20),

                // ngày hiện tại lớn hơn ngày EndDate
                NowDate = new DateTime(2023, 2, 25)
            });

            ds.Add(new QuaTrinhCongTac
            {
                StartDate = new DateTime(2023, 3, 1),
                EndDate = new DateTime(2023, 3, 29),

                // ngày hiện tại bằng ngày EndDate
                NowDate = new DateTime(2023, 3, 29)
            });



            // ánh xạ dữ liệu (map data)
            var mapData = ds.Select(item =>
            {
                int result = DateTime.Compare(item.NowDate.Value.Date, item.EndDate.Value.Date);
                //int result = DateTime.Compare(item.NowDate, item.EndDate);

                if (result > 0)
                {
                    return new AnhXaDTO()
                    {
                        ketQua_SoSanh = 1,
                        thong_bao = "NowDate > EndDate",
                        thoiGian_CongTac = (item.StartDate.Value.Date.Subtract(item.EndDate.Value.Date)).TotalDays
                        //thoiGian_CongTac = (item.StartDate.Subtract(item.EndDate)).TotalDays
                    };
                }
                else if (result < 0)
                {
                    return new AnhXaDTO()
                    {
                        ketQua_SoSanh = -1,
                        thong_bao = "NowDate < EndDate",
                        thoiGian_CongTac = (item.StartDate.Value.Date.Subtract(item.NowDate.Value.Date)).TotalDays
                        //thoiGian_CongTac = (item.StartDate.Subtract(item.NowDate)).TotalDays
                    };
                }
                else
                {
                    return new AnhXaDTO()
                    {
                        ketQua_SoSanh = 0,
                        thong_bao = "NowDate == EndDate",
                        thoiGian_CongTac = (item.StartDate.Value.Date.Subtract(item.NowDate.Value.Date)).TotalDays
                        //thoiGian_CongTac = (item.StartDate.Subtract(item.NowDate)).TotalDays

                        // hoặc thời gian công tác bằng như này cũng được
                        // thoiGian_CongTac = item.StartDate.Value.Date.Subtract(item.EndDate.Value.Date)
                    };
                }
            });



            // in ra tiêu đề
            foreach (var item in new AnhXaDTO().GetType().GetProperties())
            {
                Console.Write($"{item.Name, -25}");
            }



            // xuống dòng
            Console.WriteLine();



            // in ra mapData
            foreach (var item in mapData)
            {
                // sử dụng hàm Abs()
                // để lấy giá trị tuyệt đối
                Console.WriteLine($"{item.ketQua_SoSanh, -25}{item.thong_bao, -25}{Math.Abs(item.thoiGian_CongTac)}");
            }



            // xuống dòng
            Console.WriteLine();
        }
    }
}