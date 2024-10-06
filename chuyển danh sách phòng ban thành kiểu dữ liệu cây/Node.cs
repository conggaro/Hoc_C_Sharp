namespace MyApp
{
    public class Node
    {
        public required long Id { get; set; }           // Mã định danh cho phòng ban
        public required string Name { get; set; }       // Tên phòng ban
        public long? ParentId { get; set; }             // Mã định danh của phòng ban cha (có thể null nếu không có)
        public List<Node> Children { get; set; }

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