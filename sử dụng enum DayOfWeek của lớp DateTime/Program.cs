using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DateTime monday = new DateTime(2024, 7, 15);
            DateTime tuesday = new DateTime(2024, 7, 16);
            DateTime wednesday = new DateTime(2024, 7, 17);
            DateTime thursday = new DateTime(2024, 7, 18);
            DateTime friday = new DateTime(2024, 7, 19);
            DateTime saturday = new DateTime(2024, 7, 20);
            DateTime sunday = new DateTime(2024, 7, 21);

            var index_mon = monday.DayOfWeek;
            var index_tues = tuesday.DayOfWeek;
            var index_wednes = wednesday.DayOfWeek;
            var index_thurs = thursday.DayOfWeek;
            var index_friday = friday.DayOfWeek;
            var index_satur = saturday.DayOfWeek;
            var index_sun = sunday.DayOfWeek;

            // in ra mặc định
            Console.WriteLine(index_mon);
            Console.WriteLine(index_tues);
            Console.WriteLine(index_wednes);
            Console.WriteLine(index_thurs);
            Console.WriteLine(index_friday);
            Console.WriteLine(index_satur);
            Console.WriteLine(index_sun);

            // in ra số
            Console.WriteLine((int)index_mon);
            Console.WriteLine((int)index_tues);
            Console.WriteLine((int)index_wednes);
            Console.WriteLine((int)index_thurs);
            Console.WriteLine((int)index_friday);
            Console.WriteLine((int)index_satur);
            Console.WriteLine((int)index_sun);
        }
    }
}