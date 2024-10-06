using System;

/*
    Tính trước tương lai
    
    Đối với bài toán cho 1 danh sách bản ghi phòng ban
    sau đó yêu cầu đếm số nhân viên trong phòng ban
    
    bước 1 cho chạy vòng lặp for,
    gọi hàm tìm các phòng ban con từ ID phòng ban cha đã cho

    bước 2 là từ danh sách phòng ban con đấy chỉ select lấy ID thôi
    
    bước 3 là tìm nhân viên theo phòng ban, có thể dùng hàm Contains()

    bước 4 là gọi phương thức Count

    thế là xong rồi đấy
*/

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // tạo danh sách phòng ban
            List<Node> departments = CreateList.CreateListDepartment();
            
            // Chuyển danh sách thành cây đệ quy
            List<Node> tree = BuildTree(departments, null);

            // In cây ra màn hình
            PrintTree(tree, 0);


            Console.WriteLine("\n\n");



            // Tìm phòng ban cha với Id cụ thể, ví dụ Id = 1
            Node? parent = FindNodeById(tree, 2);

            if (parent != null)
            {
                // Lấy ra tất cả các phòng ban con cháu của phòng ban cha này
                List<Node> descendants = GetAllDescendants(parent);

                // In ra danh sách phòng ban con cháu
                foreach (var department in descendants)
                {
                    Console.WriteLine($"Department Id: {department.Id}, Name: {department.Name}");
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy phòng ban cha với Id đã cho.");
            }
        }

        // Hàm đệ quy để xây dựng cây
        public static List<Node> BuildTree(List<Node> nodes, long? parentId)
        {
            return nodes
                .Where(node => node.ParentId == parentId)  // Lấy các node con của parentId
                .Select(node => {
                    node.Children = BuildTree(nodes, node.Id);  // Gọi đệ quy để tìm các node con của node hiện tại
                    return node;
                })
                .ToList();
        }

        // Hàm đệ quy in cây ra màn hình
        public static void PrintTree(List<Node> nodes, int level)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(new string('-', level * 2) + node.Name);

                if (node.Children.Any())
                {
                    PrintTree(node.Children, level + 1);  // Gọi đệ quy để in các node con
                }
            }
        }

        // Hàm lấy tất cả phòng ban con cháu
        public static List<Node> GetAllDescendants(Node parent)
        {
            List<Node> result = new List<Node>();

            // Hàm đệ quy duyệt qua tất cả các node con
            foreach (var child in parent.Children)
            {
                result.Add(child);  // Thêm node con vào danh sách kết quả
                result.AddRange(GetAllDescendants(child));  // Gọi đệ quy để thêm các con cháu của node này
            }

            return result;
        }

        // Hàm tìm node cha dựa trên Id (để bắt đầu tìm con cháu)
        public static Node? FindNodeById(List<Node> nodes, long id)
        {
            foreach (var node in nodes)
            {
                if (node.Id == id)
                {
                    return node;  // Nếu tìm thấy node với Id trùng, trả về node đó
                }

                // Nếu không phải node hiện tại, duyệt tiếp con của nó
                var foundChild = FindNodeById(node.Children, id);
                if (foundChild != null)
                {
                    return foundChild;  // Trả về node con tìm thấy
                }
            }

            return null;  // Trả về null nếu không tìm thấy node với Id đã cho
        }
    }
}