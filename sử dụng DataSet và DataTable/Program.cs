using System;
using System.Data;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // cho một danh sách bản ghi
            List<object[]> list = new List<object[]>()
            {
                new object[] {1, "Nguyễn Văn A", true, new DateTime(2024, 1, 31)},
                new object[] {2, "Nguyễn Thị B", false, new DateTime(1999, 12, 30)},
                new object[] {3, "Nguyễn Văn C", true, new DateTime(1888, 6, 20)},
                new object[] {4, "Nguyễn Thị D", false, new DateTime(1945, 8, 25)},
                new object[] {5, "Nguyễn Văn E", true, new DateTime(2012, 11, 10)}
            };



            // tạo đối tượng DataTable
            DataTable dataTable = new DataTable();

            // đặt tên cho DataTable
            dataTable.TableName = "PERSON_ENTITY";

            // định nghĩa cột
            dataTable.Columns.Add("ID", typeof(int));
            dataTable.Columns.Add("FULL_NAME", typeof(string));
            dataTable.Columns.Add("GENDER", typeof(bool));
            dataTable.Columns.Add("BIRTH_DATE", typeof(DateTime));

            // thêm các bản ghi
            foreach (var item in list)
            {
                dataTable.Rows.Add(item);
            }

            // hoặc bạn có thể thêm bản ghi như này
            dataTable.Rows.Add(6, "Nguyễn Thị F", false, DateTime.Now);



            // tạo đối tượng DataSet
            // để đưa DataTable vào trong DataSet
            DataSet dataSet = new DataSet();

            // đặt tên cho dataSet
            dataSet.DataSetName = "HUMAN_DATABASE_MANAGEMENT";

            // thêm DataTable
            dataSet.Tables.Add(dataTable);



            // khi bạn muốn lấy DataTable ra sử dụng
            var table = dataSet.Tables[0];

            // thiết lập cho in ra Tiếng Việt
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // khi bạn muốn in các dòng dữ liệu
            // ở trong bảng ra màn hình
            for (int i = 0; i < table.Rows.Count; i++)
            {
                // nếu dùng var để khai báo thì sẽ lỗi ngay
                // bắt buộc phải dùng DataRow
                DataRow item = table.Rows[i];

                // dùng indexer
                // để truy cập đến ID, FULL_NAME, GENDER, BIRTH_DATE
                int id = Convert.ToInt32(item["ID"]);
                string fullName = Convert.ToString(item["FULL_NAME"]);
                bool gender = Convert.ToBoolean(item["GENDER"]);
                DateTime birthDate = Convert.ToDateTime(item["BIRTH_DATE"]);

                // in kết quả ra màn hình
                Console.Write(id + ", ");
                Console.Write(fullName + ", ");
                Console.Write(gender + ", ");
                Console.Write(birthDate.ToString("dd/MM/yyyy") + "\n");
            }
        }
    }
}