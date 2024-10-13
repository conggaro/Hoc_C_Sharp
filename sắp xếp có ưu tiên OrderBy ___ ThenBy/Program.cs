using System;

namespace MyApp
{
    public class Program
    {
        public static void Main()
        {
            List<Item> items = new List<Item>()
            {
                new Item { Status = 2, OrderNumber = 5, EffectDate = new DateTime(2022, 10, 1) },
                new Item { Status = 1, OrderNumber = 3, EffectDate = new DateTime(2023, 1, 10) },
                new Item { Status = 2, OrderNumber = 1, EffectDate = new DateTime(2021, 5, 5) },
                new Item { Status = 1, OrderNumber = 4, EffectDate = new DateTime(2021, 10, 15) },
                new Item { Status = 3, OrderNumber = 2, EffectDate = new DateTime(2023, 3, 18) }
            };

            var sortedItems = items
                              .OrderBy(i => i.Status)                 // Ưu tiên sắp xếp theo Status
                              .ThenBy(i => i.OrderNumber)             // Sắp xếp tiếp theo OrderNumber
                              .ThenBy(i => i.EffectDate)              // Cuối cùng sắp xếp theo EffectDate
                              .ToList();

            /*
                Giải thích:
                OrderBy(i => i.Status): Sắp xếp đầu tiên theo thuộc tính Status (ưu tiên cao nhất)

                ThenBy(i => i.OrderNumber): Nếu Status bằng nhau, sẽ sắp xếp tiếp theo theo OrderNumber
                
                ThenBy(i => i.EffectDate): Nếu cả Status và OrderNumber bằng nhau, sắp xếp cuối cùng theo EffectDate
            */


            // Trong trường hợp bạn cần sắp xếp giảm dần (descending)
            // cho một trong hai thuộc tính,
            // bạn có thể sử dụng OrderByDescending hoặc ThenByDescending
            // Cách này sẽ sắp xếp Status theo thứ tự tăng dần và OrderNumber theo thứ tự giảm dần
            // var sortedItems = items.OrderBy(i => i.Status).ThenByDescending(i => i.OrderNumber).ToList();

            foreach (var item in sortedItems)
            {
                Console.WriteLine($"Status: {item.Status}, OrderNumber: {item.OrderNumber}, EffectDate: {item.EffectDate.ToShortDateString()}");
            }
        }
    }

    public class Item
    {
        public int Status { get; set; }
        public int OrderNumber { get; set; }
        public DateTime EffectDate { get; set; }
    }
}