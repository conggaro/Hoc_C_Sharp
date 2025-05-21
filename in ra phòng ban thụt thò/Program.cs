using System.Text;

namespace MyApp
{
    public class Program
    {
        public static void Main()
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            // Khởi tạo danh sách phòng ban
            var departments = BuildDepartmentList();

            // Gọi hàm và in ra cây phòng ban
            var hierarchy = GetDepartmentHierarchy(departments, null, 0);

            foreach (var item in hierarchy)
            {
                Console.WriteLine(item);
            }
        }

        public static List<string> GetDepartmentHierarchy(List<HU_ORGANIZATION> departments, long? parentId, int level)
        {
            var result = new List<string>();
            var currentDepartments = departments
                .Where(d => d.PARENT_ID == parentId)
                .OrderBy(x => x.ORDER_NUM)
                .ToList();

            foreach (var department in currentDepartments)
            {
                result.Add(new string(' ', level * 4) + department.NAME); // 4 khoảng trắng cho mỗi cấp
                result.AddRange(GetDepartmentHierarchy(departments, department.ID, level + 1));
            }

            return result;
        }

        public static List<HU_ORGANIZATION> BuildDepartmentList()
        {
            var departments = new List<HU_ORGANIZATION>
            {
                new HU_ORGANIZATION { ID = 1, NAME = "Công ty ABC", PARENT_ID = null, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 2, NAME = "Phòng Kinh Doanh", PARENT_ID = 1, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 3, NAME = "Phòng Kỹ Thuật", PARENT_ID = 1, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 4, NAME = "Phòng Hành Chính", PARENT_ID = 2, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 5, NAME = "Phòng Marketing", PARENT_ID = 2, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 6, NAME = "Phòng Phát Triển Sản Phẩm", PARENT_ID = 3, ORDER_NUM = 1 },
                // Thêm các phòng ban con
                new HU_ORGANIZATION { ID = 7, NAME = "Phòng Bán Hàng 1", PARENT_ID = 2, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 8, NAME = "Phòng Bán Hàng 2", PARENT_ID = 2, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 9, NAME = "Phòng Dịch Vụ Khách Hàng", PARENT_ID = 2, ORDER_NUM = 3 },
                new HU_ORGANIZATION { ID = 10, NAME = "Phòng Kỹ Thuật 1", PARENT_ID = 3, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 11, NAME = "Phòng Kỹ Thuật 2", PARENT_ID = 3, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 12, NAME = "Phòng Nghiên Cứu và Phát Triển", PARENT_ID = 3, ORDER_NUM = 3 },
                new HU_ORGANIZATION { ID = 13, NAME = "Phòng Tài Chính", PARENT_ID = 1, ORDER_NUM = 3 },
                new HU_ORGANIZATION { ID = 14, NAME = "Phòng Nhân Sự", PARENT_ID = 1, ORDER_NUM = 4 },
                new HU_ORGANIZATION { ID = 15, NAME = "Phòng IT", PARENT_ID = 1, ORDER_NUM = 5 },
                new HU_ORGANIZATION { ID = 16, NAME = "Phòng Kinh Doanh Quốc Tế", PARENT_ID = 2, ORDER_NUM = 4 },
                new HU_ORGANIZATION { ID = 17, NAME = "Phòng Kinh Doanh Nội Địa", PARENT_ID = 2, ORDER_NUM = 5 },
                new HU_ORGANIZATION { ID = 18, NAME = "Phòng Marketing Online", PARENT_ID = 5, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 19, NAME = "Phòng Marketing Offline", PARENT_ID = 5, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 20, NAME = "Phòng Hành Chính 1", PARENT_ID = 4, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 21, NAME = "Phòng Hành Chính 2", PARENT_ID = 4, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 22, NAME = "Phòng Kỹ Thuật 3", PARENT_ID = 10, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 23, NAME = "Phòng Kỹ Thuật 4", PARENT_ID = 11, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 24, NAME = "Phòng Kỹ Thuật 5", PARENT_ID = 12, ORDER_NUM = 3 },
                new HU_ORGANIZATION { ID = 25, NAME = "Phòng Kinh Doanh 3", PARENT_ID = 2, ORDER_NUM = 6 },
                new HU_ORGANIZATION { ID = 26, NAME = "Phòng Kinh Doanh 4", PARENT_ID = 2, ORDER_NUM = 7 },
                new HU_ORGANIZATION { ID = 27, NAME = "Phòng Hỗ Trợ Kỹ Thuật", PARENT_ID = 10, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 28, NAME = "Phòng Hỗ Trợ Khách Hàng", PARENT_ID = 9, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 29, NAME = "Phòng Phát Triển Thị Trường", PARENT_ID = 5, ORDER_NUM = 3 },
                new HU_ORGANIZATION { ID = 30, NAME = "Phòng Tư Vấn Khách Hàng", PARENT_ID = 9, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 31, NAME = "Phòng Đào Tạo", PARENT_ID = 14, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 32, NAME = "Phòng Tuyển Dụng", PARENT_ID = 14, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 33, NAME = "Phòng Kế Toán", PARENT_ID = 13, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 34, NAME = "Phòng Kiểm Soát Nội Bộ", PARENT_ID = 13, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 35, NAME = "Phòng Quản Lý Dự Án", PARENT_ID = 1, ORDER_NUM = 6 },
                new HU_ORGANIZATION { ID = 36, NAME = "Phòng Phân Tích Dữ Liệu", PARENT_ID = 15, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 37, NAME = "Phòng Phát Triển Ứng Dụng", PARENT_ID = 15, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 38, NAME = "Phòng An Ninh Mạng", PARENT_ID = 15, ORDER_NUM = 3 },
                new HU_ORGANIZATION { ID = 39, NAME = "Phòng Quản Trị Hệ Thống", PARENT_ID = 15, ORDER_NUM = 4 },
                new HU_ORGANIZATION { ID = 40, NAME = "Phòng Quản Lý Rủi Ro", PARENT_ID = 13, ORDER_NUM = 3 },
                new HU_ORGANIZATION { ID = 41, NAME = "Phòng Phát Triển Nguồn Nhân Lực", PARENT_ID = 14, ORDER_NUM = 3 },
                new HU_ORGANIZATION { ID = 42, NAME = "Phòng Chăm Sóc Khách Hàng 1", PARENT_ID = 28, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 43, NAME = "Phòng Chăm Sóc Khách Hàng 2", PARENT_ID = 28, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 44, NAME = "Phòng Đối Tác Chiến Lược", PARENT_ID = 1, ORDER_NUM = 7 },
                new HU_ORGANIZATION { ID = 45, NAME = "Phòng Quản Lý Sản Phẩm", PARENT_ID = 29, ORDER_NUM = 1 },
                new HU_ORGANIZATION { ID = 46, NAME = "Phòng Nghiên Cứu Thị Trường", PARENT_ID = 29, ORDER_NUM = 2 },
                new HU_ORGANIZATION { ID = 47, NAME = "Phòng Quản Lý Quan Hệ Khách Hàng", PARENT_ID = 28, ORDER_NUM = 3 },
                new HU_ORGANIZATION { ID = 48, NAME = "Phòng Hỗ Trợ Kinh Doanh", PARENT_ID = 2, ORDER_NUM = 8 },
                new HU_ORGANIZATION { ID = 49, NAME = "Phòng Tư Vấn Chiến Lược", PARENT_ID = 1, ORDER_NUM = 8 },
                new HU_ORGANIZATION { ID = 50, NAME = "Phòng Phân Tích Kinh Doanh", PARENT_ID = 1, ORDER_NUM = 9 }
            };

            return departments;
        }
    }

    public class HU_ORGANIZATION
    {
        public long ID { get; set; }
        public string? NAME { get; set; }
        public long? PARENT_ID { get; set; }
        public int? ORDER_NUM { get; set; } // Thứ tự
    }
}