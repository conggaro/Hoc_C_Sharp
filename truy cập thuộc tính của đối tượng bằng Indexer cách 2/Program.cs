using System;
using System.Collections.Generic;

namespace MyApp
{
    class Program
    {
        static void Main()
        {
            Human myObj = new Human();

            // Sử dụng indexer để lấy và đặt giá trị của các thuộc tính
            myObj["name"] = "John";
            myObj["age"] = 25;
            myObj["gender"] = true;

            Console.WriteLine($"Name: {myObj["name"]}, Age: {myObj["age"]}, Gender: {myObj["gender"]}");
        }
    }



    class Human
    {
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        // Indexer cho việc truy cập các thuộc tính
        public object this[string propertyName]
        {
            get
            {
                if (properties.ContainsKey(propertyName))
                {
                    return properties[propertyName];
                }
                else
                {
                    throw new ArgumentException($"Property '{propertyName}' not found");
                }
            }
            set
            {
                properties[propertyName] = value;
            }
        }
    }
}