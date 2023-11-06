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
                    CommandText = "spCreateStudent",

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
                    // cái @Name là tên được định nghĩa trong "stored procedure"
                    ParameterName = "@Name",

                    // thiết lập kiểu dữ liệu cho tham số @Name
                    SqlDbType = SqlDbType.NVarChar,

                    // giá trị để truyền cho tham số @Name
                    Value = "Test",

                    // chỉ định tham số là loại đầu vào (Input)
                    Direction = ParameterDirection.Input
                };


                // thêm tham số
                // vào thuộc tính Parameters
                // của đối tượng SqlCommand
                dt_SqlCommand.Parameters.Add(parameter1);


                // cách 2:
                // để thêm tham số đầu vào
                dt_SqlCommand.Parameters.AddWithValue("@Email", "Test@dotnettutorial.net");
                dt_SqlCommand.Parameters.AddWithValue("@Mobile", "1234567890");


                // tạo đối tượng outParameter
                // có kiểu dữ liệu "SqlParameter"
                SqlParameter outParameter = new SqlParameter
                {
                    // cái @Id là tên được định nghĩa trong "stored procedure"
                    ParameterName = "@Id",

                    // thiết lập kiểu dữ liệu cho tham số @Id
                    SqlDbType = SqlDbType.Int,

                    // không cần chỉ định giá trị cho thuộc tính "Value"
                    // của đối tượng "outParameter"

                    // chỉ định tham số là loại đầu ra (Output)
                    Direction = ParameterDirection.Output
                };


                // thêm tham số
                // vào thuộc tính Parameters
                // của đối tượng SqlCommand
                dt_SqlCommand.Parameters.Add(outParameter);


                // mở kết nối
                dt_KetNoi.Open();


                // gọi phương thức ExecuteNonQuery()
                dt_SqlCommand.ExecuteNonQuery();


                // bây giờ bạn có thể truy cập tham số đầu ra
                // bằng thuộc tính Value
                // của đối tượng outParameter
                Console.WriteLine("ID cua sinh vien moi duoc tao: " + outParameter.Value.ToString());


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