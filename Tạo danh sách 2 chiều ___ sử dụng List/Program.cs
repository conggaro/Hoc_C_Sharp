using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo danh sách con
            List<string> list_child1 = new List<string>();
            list_child1.Add("ABC");
            list_child1.Add("DEF");
            list_child1.Add("GHI");

            List<string> list_child2 = new List<string>();
            list_child2.Add("JKL");
            list_child2.Add("MNO");
            list_child2.Add("PQR");

            List<string> list_child3 = new List<string>();
            list_child3.Add("STU");
            list_child3.Add("VXY");
            list_child3.Add("ZZZ");


            // tạo danh sách cha
            // hay còn gọi là danh sách 2 chiều
            List<List<string>> list_parent = new List<List<string>>();

            list_parent.Add(list_child1);
            list_parent.Add(list_child2);
            list_parent.Add(list_child3);


            foreach (var row in list_parent)
            {
                foreach (var col in row)
                {
                    Console.Write(col + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}