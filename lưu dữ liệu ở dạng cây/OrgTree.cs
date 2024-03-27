using System;
using System.Collections.Generic;

namespace MyApp
{
    public class OrgTree
    {
        private TreeNode root;

        public OrgTree(List<ModelOrg> records)
        {
            // Tạo một cây từ danh sách các bản ghi
            root = BuildTree(records, null);
        }

        private TreeNode BuildTree(List<ModelOrg> records, long? parentId)
        {
            TreeNode node = new TreeNode(null);

            foreach (var record in records.Where(r => r.ParentId == parentId))
            {
                var childNode = new TreeNode(record);

                // Thực hiện đệ quy để lấy danh sách con của node hiện tại
                var children = BuildTree(records, record.Id);

                // Kiểm tra xem có con nào được thêm vào không
                if (children.Children.Count > 0)
                {
                    // Thêm các con vào danh sách con của childNode
                    childNode.Children.AddRange(children.Children);
                }
                
                node.Children.Add(childNode);
            }

            return node;
        }

        public TreeNode GetRoot()
        {
            return root;
        }
    }
}