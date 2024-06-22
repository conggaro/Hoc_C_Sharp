using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // bây giờ, tôi muốn lấy ra giá trị
            // của thuộc tính
            // nhưng phải dùng phương thức GetType()
            // và phương thức GetProperties()


            // create a new object
            Person person = new Person();

            // set a value for each the property
            person.Id = 1;
            person.Name = "C Sharp";

            // get value of "Id"
            object? x = person
                        .GetType()
                        .GetProperty("Id")!
                        .GetValue(person);

            // get value of "Name"
            object? y = person
                        .GetType()
                        .GetProperty("Name")!
                        .GetValue(person);

            int Id = Convert.ToInt32(x);

            string Name = "Name is null";
            if (y != null) Name = y.ToString();

            Console.WriteLine(Id);
            Console.WriteLine(Name);
            Console.WriteLine(person);
        }
    }


    // ví dụ cho 1 lớp Person
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }


        // constructor
        public Person() { }


        // constructor 2
        public Person(int parameter1, string parameter2)
        {
            Id = parameter1;
            Name = parameter2;
        }


        // override method ToString()
        public override string ToString()
        {
            int id = this.Id;
            string name = (this.Name != null) ? this.Name : "";

            return $"[Id = {id}, Name = {name}]";
        }
    }
}