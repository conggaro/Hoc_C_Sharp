using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> list1 = new List<string>()
            {
                "abc", "def", "ghi", "jkl"
            };

            List<int> list2 = new List<int>()
            {
                1 , 2, 3, 4, 5, 6, 7, 8, 9, 10
            };

            List<Color> list3 = new List<Color>()
            {
                Color.Black, Color.Red, Color.Green, Color.Blue
            };

            List<bool> list4 = new List<bool>()
            {
                true, false, false, false, true
            };


            // cách sử dụng SelectMany()
            var mergeList = list1
                            
                            .SelectMany(l1 => list2,
                            (l1, l2) => new { l1, l2 })
                            
                            .SelectMany(l1_l2 => list3,
                            (l1_l2, l3) => new { l1_l2.l1, l1_l2.l2, l3 })
                            
                            .SelectMany(l1_l2_l3 => list4,
                            (l1_l2_l3_l4, l4) => new {
                                l1_l2_l3_l4.l1,
                                l1_l2_l3_l4.l2,
                                l1_l2_l3_l4.l3,
                                l4
                            })
                            
                            .ToList();

            // lúc này đã chọn được nhiều list
            // cách list này đã trở thành phần tử
            // của danh sách mergeList
            var l1 = mergeList.Select(x => x.l1);
            var l2 = mergeList.Select(x => x.l2);
            var l3 = mergeList.Select(x => x.l3);
            var l4 = mergeList.Select(x => x.l4);


            // khi dùng SelectMany()
            // thì nó sẽ biến các list thành các cột
            // còn cái đối tượng mergeList sẽ trở thành danh sách
        }
    }

    public enum Color
    {
        Red = 0,
        Green = 1,
        Blue = 2,
        Yellow = 3,
        White = 4,
        Black = 5,
        Pink = 6
    }
}