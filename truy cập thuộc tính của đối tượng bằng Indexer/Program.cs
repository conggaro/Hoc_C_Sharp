using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Human myObj = new Human();

            // Sử dụng indexer để lấy và đặt giá trị của thuộc tính name và age
            myObj["name"] = "John";
            myObj["age"] = 25;

            Console.WriteLine($"Name: {myObj["name"]}, Age: {myObj["age"]}");
        }
    }


    class Human
    {
        private string name;
        private int age;

        // Indexer cho việc truy cập các thuộc tính
        public object this[string propertyName]
        {
            get
            {
                switch (propertyName)
                {
                    case "name":
                        return name;
                    case "age":
                        return age;
                    default:
                        throw new ArgumentException("Invalid property name");
                }
            }
            set
            {
                switch (propertyName)
                {
                    case "name":
                        name = (string)value;
                        break;
                    case "age":
                        age = (int)value;
                        break;
                    default:
                        throw new ArgumentException("Invalid property name");
                }
            }
        }
    }
}