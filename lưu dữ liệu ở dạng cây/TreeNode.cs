using System;

namespace MyApp
{
    /// <summary>
    /// lớp TreeNode dùng để làm
    /// các node trên cây
    /// </summary>
    public class TreeNode
    {
        /// <summary>
        /// thuộc tính Data,
        /// dùng để lưu bản ghi
        /// có kiểu dữ liệu ModelOrg
        /// </summary>
        public ModelOrg Data { get; set; }



        /// <summary>
        /// thuộc tính ChildrenOfNode,
        /// dùng để lưu các bản ghi
        /// có kiểu dữ liệu ModelOrg
        /// </summary>
        public List<TreeNode> ChildrenOfNode { get; set; }


        /// <summary>
        /// hàm khởi tạo
        /// với tham số
        /// có kiểu dữ liệu là ModelOrg
        /// </summary>
        public TreeNode(ModelOrg data)
        {
            Data = data;
            ChildrenOfNode = new List<TreeNode>();
        }
    }
}