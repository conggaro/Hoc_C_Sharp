using System;
using System.Data;
using System.Data.SqlClient;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                // tạo biến chứa chuỗi kết nối
                string connection_str = @"
                    Server = localhost;
                    Database = StudentDB;
                    User ID = sa;
                    Password = 123456
                ";


                // tạo đối tượng có kiểu "SqlConnection"
                SqlConnection dt_KetNoi = new SqlConnection(connection_str);


                // tạo đối tượng có kiểu "SqlCommand"
                // để gọi stored procedure trong SQL Server
                SqlCommand dt_SqlCommand = new SqlCommand("spGetStudents", dt_KetNoi);


                // chỉ định loại lệnh là "StoredProcedure"
                dt_SqlCommand.CommandType = CommandType.StoredProcedure;


                /*
                    mặc định SqlCommand sẽ coi
                    nội dung trong thuộc tính CommandText
                    là câu lệnh SQL

                    vì nó đã thiết lập CommandType
                    bằng CommandType.Text

                    nếu muốn gọi đến Procedure
                    thì thiết lập nó
                    bằng CommandType.StoredProcedure
                */


                // cách 2:
                // SqlCommand dt_SqlCommand = new SqlCommand("spGetStudents", dt_KetNoi)
                // {
                //     CommandType = CommandType.StoredProcedure
                // };


                // mở kết nối
                dt_KetNoi.Open();


                // tạo đối tượng có kiểu "SqlDataReader"
                // tôi gọi nó là "đối tượng đọc"
                SqlDataReader dt_doc = dt_SqlCommand.ExecuteReader();


                // tạo danh sách
                List<Student> ds = new List<Student>();


                // sử dụng vòng lặp while
                // để đọc dữ liệu trả về
                while (dt_doc.Read())
                {
                    // tạo đối tượng item
                    Student item = new Student()
                    {
                        Id = (int)dt_doc["Id"],
                        Name = (string)dt_doc["Name"],
                        Email = (string)dt_doc["Email"],
                        Mobile = (string)dt_doc["Mobile"]
                    };


                    // thêm đối tượng item vào trong danh sách
                    ds.Add(item);
                }


                // đóng chuỗi kết nối
                dt_KetNoi.Close();


                // in ra danh sách
                Console.WriteLine("Danh sach:");

                foreach (Student item in ds)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            catch (
                // tạo đối tượng ex
                // có kiểu dữ liệu "Exception"
                Exception ex
            )
            {
                // "Exception Occurred" là xảy ra ngoại lệ
                Console.WriteLine($"Exception Occurred: {ex.Message}");
            }
        }
    }
}