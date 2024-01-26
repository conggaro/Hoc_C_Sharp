using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // tạo đối tượng "model_1"
            Model1 model_1 = new Model1();

            // lấy vùng nhớ chứa giá trị của "model_1"
            // gán vào "clone_1"
            Model1 clone_1 = model_1;

            // thiết lập model_1.Id = 1
            model_1.Id = 1;

            // sửa thử "clone_1" xem "model_1" có bị thay đổi không
            clone_1.Id = 2;

            // nếu không bị sửa thì sẽ in ra 1
            Console.WriteLine("model_1: " + model_1.Id);          // in ra 2



            // tạo đối tượng "model_2"
            Model2 model_2 = new Model2();

            // lấy vùng nhớ chứa giá trị của "model_2"
            // gán vào "clone_2"
            Model2 clone_2 = model_2;

            // thiết lập model_2.Id = 1
            model_2.Id = 1;

            // sửa thử "clone_2" xem "model_2" có bị thay đổi không
            clone_2.Id = 2;

            // nếu không bị sửa thì sẽ in ra 1
            Console.WriteLine("\nmodel_2: " + model_2.Id);          // in ra 1


            // kết luận:
            // class là kiểu tham chiếu
            // sửa cái này thì cái kia bị ảnh hưởng

            // struct là kiểu tham trị
            // sửa cái này thì cái kia KHÔNG bị ảnh hưởng
        }
    }

    public class Model1
    {
        public int Id { get; set; }
    }

    public struct Model2
    {
        public int Id { get; set; }
    }
}