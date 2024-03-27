using System;

namespace MyApp
{
    public class TreeNode
    {
        public ModelOrg Data { get; set; }
        public List<TreeNode> Children { get; set; }

        public TreeNode(ModelOrg data)
        {
            Data = data;
            Children = new List<TreeNode>();
        }
    }
}