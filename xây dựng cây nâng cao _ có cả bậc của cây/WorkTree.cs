using System.Xml.Linq;

namespace MyApp
{
    public class WorkTree
    {
        public static void DisplayTreeOnConsole()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // tạo danh sách phòng ban
            List<Node> departments = CreateList.CreateListDepartment();

            // Chuyển danh sách thành cây đệ quy
            List<Node> tree = BuildTree(departments, null);

            // In cây ra màn hình
            // PrintTree(tree, 0);


            // chuyển cây về danh sách
            var list = FlattenTree(tree);

            Console.WriteLine("\n\n");

            

            // Tìm phòng ban cha với Id cụ thể, ví dụ Id = 1
            //Node? parent = FindNodeById(tree, 2);

            //if (parent != null)
            //{
            //    // Lấy ra tất cả các phòng ban con cháu của phòng ban cha này
            //    List<Node> descendants = GetAllDescendants(parent);

            //    // In ra danh sách phòng ban con cháu
            //    foreach (var department in descendants)
            //    {
            //        Console.WriteLine($"Department Id: {department.Id}, Name: {department.Name}");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Không tìm thấy phòng ban cha với Id đã cho.");
            //}
        }

        // Hàm đệ quy để xây dựng cây và thiết lập bậc (LevelOrg)
        public static List<Node> BuildTree(List<Node> nodes, long? parentId, int level = 0)
        {
            return nodes
                .Where(node => node.ParentId == parentId) // Lấy các node con của parentId
                .Select(node => {
                    node.LevelOrg = level;               // Thiết lập cấp độ cho node hiện tại
                    node.Children = BuildTree(nodes, node.Id, level + 1); // Gọi đệ quy để tìm các node con và tăng cấp độ
                    return node;
                })
                .ToList();
        }


        // Hàm đệ quy in cây ra màn hình
        public static void PrintTree(List<Node> nodes, int level)
        {
            foreach (var node in nodes)
            {
                Console.WriteLine(new string('-', level * 2) + node.Name + " _ " + node.Salary);

                if (node.Children.Any())
                {
                    PrintTree(node.Children, level + 1);  // Gọi đệ quy để in các node con
                }
            }
        }

        public static void PrintTreeToExcel(List<Node> nodes, int level)
        {
            foreach (var node in nodes)
            {
                // cấu hình cấp cho phòng ban
                // để sau này in ra excel
                // không biết nó có tham chiếu không nữa
                // thử xem thì biết
                node.LevelOrg = level * 2;

                Console.WriteLine(new string('-', level * 2) + node.Name + " _ " + node.Salary);

                if (node.Children.Any())
                {
                    PrintTreeToExcel(node.Children, level + 1);  // Gọi đệ quy để in các node con
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

        // hàm chuyển cây về danh sách
        public static List<Node> FlattenTree(List<Node> tree)
        {
            var flatList = new List<Node>();

            foreach (var node in tree)
            {
                // Thêm node hiện tại vào danh sách
                flatList.Add(node);

                // Gọi đệ quy để lấy các phần tử con và thêm chúng vào danh sách
                if (node.Children != null && node.Children.Count > 0)
                {
                    flatList.AddRange(FlattenTree(node.Children));
                }
            }

            return flatList;
        }

        // hàm lấy ra tất cả ID của phòng ban con
        // với đầu vào là Node cha
        public static List<long> GetChildIds(long parentId)
        {
            List<long> childIds = new List<long>();

            // Gọi hàm đệ quy để tìm tất cả các ID
            FindChildIds(parentId, childIds);

            return childIds;
        }

        private static void FindChildIds(long parentId, List<long> childIds)
        {
            // Tìm các phòng ban con của phòng ban cha hiện tại
            var children = CreateList.CreateListDepartment().Where(n => n.ParentId == parentId).ToList();

            foreach (var child in children)
            {
                // Thêm ID của phòng ban con vào danh sách
                childIds.Add(child.Id);
                // Đệ quy để tìm phòng ban con của phòng ban con
                FindChildIds(child.Id, childIds);
            }
        }
    }
}