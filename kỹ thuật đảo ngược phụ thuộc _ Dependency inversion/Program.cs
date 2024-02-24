using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // tạo đối tượng "c"
                // có kiểu dữ liệu "IClassC"
                // nhưng nó lại trỏ vào vùng nhớ "ClassC"
                IClassC c = new ClassC();


                // tạo đối tượng "b"
                // có kiểu dữ liệu "IClassB"
                // nhưng nó lại trỏ vào vùng nhớ "ClassB"
                IClassB b = new ClassB(c);


                // tạo đối tượng "a"
                ClassA a = new ClassA(b);


                // gọi phương thức MessageA()
                a.MessageA();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }


    // tạo lớp ClassA
    public class ClassA
    {
        // tạo thuộc tính "b_dependency"
        private IClassB b_dependency;

        // hàm khởi tạo
        public ClassA(IClassB iClassB)
        {
            b_dependency = iClassB;
        }

        // tạo phương thức MessageA()
        public void MessageA()
        {
            Console.WriteLine("Message: from ClassA");

            // gọi phương thức MessageB();
            b_dependency.MessageB();
        }
    }


    // tạo giao diện IClassB
    public interface IClassB
    {
        public void MessageB();
    }


    // tạo lớp ClassB
    // kế thừa giao diện IClassB
    public class ClassB : IClassB
    {
        // tạo thuộc tính "c_dependency"
        private IClassC c_dependency;

        // hàm khởi tạo
        public ClassB(IClassC iClassC)
        {
            c_dependency = iClassC;
        }

        // tạo phương thức MessageB()
        public void MessageB()
        {
            Console.WriteLine("Message: from ClassB");

            // gọi phương thức MessageC();
            c_dependency.MessageC();
        }
    }


    // tạo giao diện IClassC
    public interface IClassC
    {
        public void MessageC();
    }


    // tạo lớp ClassC
    // kế thừa giao diện IClassC
    public class ClassC : IClassC
    {
        // tạo phương thức MessageC()
        public void MessageC()
        {
            Console.WriteLine("Message: from ClassC");
        }
    }
}