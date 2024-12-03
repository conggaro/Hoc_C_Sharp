namespace MyApp
{
    public class Node
    {
        public required long Id { get; set; }           // Mã định danh cho phòng ban
        public required string Name { get; set; }       // Tên phòng ban
        public long? ParentId { get; set; }             // Mã định danh của phòng ban cha (có thể null nếu không có)
        public List<Node> Children { get; set; }


        // trước mắt tạm thời thêm cột lương đã
        // nó cũng chỉ như là DTO thôi
        public long Salary { get; set; }


        // thêm trường cấp phòng ban nữa
        // để nó có thể thụt thò
        public int LevelOrg { get; set; }


        public Node()
        {
            Id = 0;
            Name = "";
            Children = new List<Node>();
        }

        public Node(long id, string name, long? parentId)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            Children = new List<Node>();
        }
    }
}