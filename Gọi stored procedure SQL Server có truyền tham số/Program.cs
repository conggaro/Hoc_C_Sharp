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
                SqlCommand dt_SqlCommand = new SqlCommand()
                {
                    // chỉ định tên của stored procedure SQL Server sẽ gọi đến
                    CommandText = "spGetStudentById",
                    
                    // chỉ định đối tượng kết nối
                    Connection = dt_KetNoi,

                    // chỉ định loại lệnh là "StoredProcedure"
                    CommandType = CommandType.StoredProcedure
                };


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


                // tạo đối tượng parameter1
                // có kiểu dữ liệu "SqlParameter"
                SqlParameter parameter1 = new SqlParameter
                {
                    // cái @Id là tên được định nghĩa trong "stored procedure"
                    ParameterName = "@Id",

                    // thiết lập kiểu dữ liệu cho tham số @Id
                    SqlDbType = SqlDbType.Int,

                    // giá trị để truyền cho tham số @Id
                    Value = 101,

                    // chỉ định loại tham số
                    // có 2 loại (tham số đầu vào/tham số đầu ra)
                    // ở đây chỉ định loại tham số là "Input"
                    Direction = ParameterDirection.Input
                };


                // thêm tham số
                // vào thuộc tính Parameters
                // của đối tượng SqlCommand
                dt_SqlCommand.Parameters.Add(parameter1);


                // mở kết nối
                dt_KetNoi.Open();


                // tạo đối tượng có kiểu "SqlDataReader"
                // tôi gọi nó là "đối tượng đọc"
                SqlDataReader dt_doc = dt_SqlCommand.ExecuteReader();


                // sử dụng vòng lặp while
                // để đọc dữ liệu trả về
                while (dt_doc.Read())
                {
                    // in dữ liệu ra màn hình
                    Console.WriteLine(
                        $"{dt_doc["Id"],-10}"
                        + $"{dt_doc["Name"],-15}"
                        + $"{dt_doc["Email"],-35}"
                        + $"{dt_doc["Mobile"],-15}"
                    );
                }


                // đóng chuỗi kết nối
                dt_KetNoi.Close();
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