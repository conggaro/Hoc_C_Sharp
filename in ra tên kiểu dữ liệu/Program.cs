using System;
using System.Collections;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Khai báo và khởi tạo biến
            int myInt = 42;
            double myDouble = 3.14;
            string myString = "Hello, world!";
            bool myBool = true;
            float myFloat = 9.999f;
            decimal myDecimal = 100.9m;
            long myLong = 123456789;
            object myObject = new object() { };
            char myChar = 'a';
            ConNguoi myConNguoi = new ConNguoi();
            MauSac myMauSac = new MauSac();
            DateTime myDateTime = new DateTime(2024, 1, 31);
            List<int> myList = new List<int>() { 1, 2, 3, 4, 5, 6};
            Hashtable myHashtable = new Hashtable();
            Dictionary<string, int> myDictionary = new Dictionary<string, int>();
            int[] myArrayInt = new int[3] { 1, 2, 3};
            var myAnonymous = new { Id = 1, Content = "Welcome"};
            (string, int, bool) myTuple = ("This is C#", 22, true);


            // In ra kiểu dữ liệu của mỗi biến
            Console.WriteLine("Kieu int: " + GetDataTypeString(myInt));
            Console.WriteLine("Kieu double: " + GetDataTypeString(myDouble));
            Console.WriteLine("Kieu string: " + GetDataTypeString(myString));
            Console.WriteLine("Kieu bool: " + GetDataTypeString(myBool));
            Console.WriteLine("Kieu float: " + GetDataTypeString(myFloat));
            Console.WriteLine("Kieu decimal: " + GetDataTypeString(myDecimal));
            Console.WriteLine("Kieu long: " + GetDataTypeString(myLong));
            Console.WriteLine("Kieu object: " + GetDataTypeString(myObject));
            Console.WriteLine("Kieu char: " + GetDataTypeString(myChar));
            Console.WriteLine("Kieu ConNguoi: " + GetDataTypeString(myConNguoi));
            Console.WriteLine("Kieu MauSac: " + GetDataTypeString(myMauSac));
            Console.WriteLine("Kieu DateTime: " + GetDataTypeString(myDateTime));
            Console.WriteLine("Kieu List<int>: " + GetDataTypeString(myList));
            Console.WriteLine("Kieu Hashtable: " + GetDataTypeString(myHashtable));
            Console.WriteLine("Kieu Dictionary<TKey, TValue>: " + GetDataTypeString(myDictionary));
            Console.WriteLine("Kieu Array int: " + GetDataTypeString(myArrayInt));
            Console.WriteLine("Kieu Anonymous: " + GetDataTypeString(myAnonymous));
            Console.WriteLine("Kieu Tuple: " + GetDataTypeString(myTuple));


            // kiểu động dynamic, chỉ có tác dụng khi chương trình thực thi
            // giúp có việc gán giá trị trở nên linh hoạt
            dynamic myDynamic = 1;
            Console.WriteLine("\n\nKieu dynamic: " + GetDataTypeString(myDynamic));

            myDynamic = "abc";
            Console.WriteLine("Kieu dynamic: " + GetDataTypeString(myDynamic));
        }

        public static string GetDataTypeString(object variable)
        {
            // Sử dụng GetType() để lấy kiểu dữ liệu và ToString() để chuyển thành chuỗi
            return variable.GetType().ToString();

            // Hoặc sử dụng .GetType().Name
            // return variable.GetType().Name;
        }

        public enum MauSac
        {
            MauDo = 0,
            MauCam = 1,
            MauVang = 2,
            MauLuc = 3,
            MauLam = 4,
            MauCham = 5,
            MauTim = 6
        }
    }

    public class ConNguoi
    {
        public string? name {  get; set; }
        public int? age { get; set; }


        // constructor
        public ConNguoi(string? parameter1 = null, int? parameter2 = null)
        {
            this.name = parameter1;
            this.age = parameter2;
        }
    }
}
