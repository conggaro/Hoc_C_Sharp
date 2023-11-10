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

                if (result > 0)
                {
                    return new
                    {
                        du_lieu = 1,
                        thong_bao = "NowDate > EndDate"
                    };
                }
                else if (result < 0)
                {
                    return new
                    {
                        du_lieu = -1,
                        thong_bao = "NowDate < EndDate"
                    };
                }
                else
                {
                    return new
                    {
                        du_lieu = 0,
                        thong_bao = "NowDate == EndDate"
                    };
                }
            });


            // in ra mapData
            foreach (var item in mapData)
            {
                Console.WriteLine($"{item.du_lieu, -10} - {item.thong_bao}");
            }
        }
    }
}