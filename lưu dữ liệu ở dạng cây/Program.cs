using System;
using System.Data.SqlClient;
using System.Text;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region thiết lập tiếng Việt
            
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            
            #endregion



            // tạo danh sách
            List<ModelOrg> models = new List<ModelOrg>();



            #region kết nối cơ sở dữ liệu

            // chuỗi kết nối
            string connectionString = @"
                Server = 192.168.60.22,1433;
                Database = VEAM_SQL_DEV;
                User ID = sa;
                Password = MatKhau@123;
                TrustServerCertificate=True";



            // khai báo đối tượng SqlConnection
            using SqlConnection connection = new SqlConnection(connectionString);



            string queryString = @"
                select  ID,
                        CODE,
                        NAME,
                        PARENT_ID
                from    HU_ORGANIZATION
                where   IS_ACTIVE = 1";



            // khai báo đối tượng SqlCommand
            SqlCommand command = new SqlCommand();

            // thiết lập giá trị cho các thuộc tính
            command.CommandText = queryString;

            command.Connection = connection;

            command.CommandType = System.Data.CommandType.Text;



            // viết xong command thì mới mở kết nối
            connection.Open();



            // khai báo đối tượng SqlDataReader
            using SqlDataReader reader = command.ExecuteReader();



            // in kết quả đọc được ra màn hình
            while (reader.Read() == true)
            {
                models.Add(new ModelOrg()
                {
                    Id = Convert.ToInt64(reader["ID"]),
                    Code = reader["CODE"].ToString(),
                    Name = reader["NAME"].ToString(),
                    ParentId = !reader.IsDBNull(reader.GetOrdinal("PARENT_ID")) ? reader.GetInt64(reader.GetOrdinal("PARENT_ID")) : null
                });

                dynamic handleParentId;

                if (reader.IsDBNull(reader.GetOrdinal("PARENT_ID")) == false) handleParentId = reader.GetInt64(reader.GetOrdinal("PARENT_ID"));
                else handleParentId = null;

                Console.WriteLine($"{reader["ID"],-6} {reader["CODE"],-10} {reader["NAME"],-75} {handleParentId,-5}");
            }



            // giải phóng tài nguyên "SqlDataReader"
            reader.Close();

            // đóng kết nối
            connection.Close();

            // giải phóng tài nguyên "SqlConnection"
            connection.Dispose();

            #endregion



            #region Xử lý dữ liệu
            
            OrgTree orgTree = new OrgTree(models);
            
            TreeNode root = orgTree.GetRoot();
            
            #endregion
        }
    }
}