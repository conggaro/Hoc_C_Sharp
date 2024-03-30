using System;
using System.Collections.Generic;


/*
    QUY TRÌNH ĐỂ XÂY DỰNG CÂY "SƠ ĐỒ TỔ CHỨC"
                
    bước 1: tạo ra 1 cái gốc,
            nó cũng chính là phần tử đầu tiên,
            phần tử gốc có đặc điểm
            là "Data = null"

    bước 2: từ danh sách bản ghi được truyền vào
            thì lấy ra danh sách các bản ghi
            không có parentId,
            tức là ban đầu "parentId = null"

    bước 3: sau khi lấy được danh sách
            thì dùng vòng lặp foreach
            để duyệt qua từng phần tử

    bước 4: ở bên trong vòng lặp foreach,
            tạo đối tượng nodeMini
            có kiểu dữ liệu TreeNode
            được truyền 1 tham số khi khởi tạo,
            nodeMini có đặc điểm
            là "Data = item"

    bước 5: thực hiện đệ quy
            để lấy danh sách con
            của node hiện tại

    bước 6: điều kiện dừng đệ quy
            là phương thức Where()
            trả về danh sách có
            số lượng phần tử bằng 0,
            lúc này nó sẽ không gọi
            phương thức BuildTree() nữa

    bước 7: tại cái node cuối cùng,
            nó sẽ không
            gọi phương thức BuildTree()
            để đệ quy
            mà nó sẽ trả về node
            có kiểu dữ liệu TreeNode

    bước 8: sau khi có kết quả trả về
            của phương thức BuildTree()
            cuối cùng,
            thì cái kết quả trả về đấy
            được gán cho biến children
                        
    bước 9: kiểm tra xem
            có con nào được thêm vào không

    bước 10: nếu có
             thì thêm các con
             vào danh sách con của nodeMini

    bước 11: thêm nodeMini
             vào trong node

    bước 12: return node

    bước 13: gán giá trị
             cho thuộc tính root
*/


namespace MyApp
{
    public class OrgTree
    {
        private TreeNode root;

        public OrgTree(List<ModelOrg> records)
        {
            // tạo một cây
            // từ danh sách các bản ghi
            // danh sách bản ghi thì được lấy từ database
            root = BuildTree(records, null);
        }

        private TreeNode BuildTree(List<ModelOrg> records, long? parentId)
        {
            // tạo đối tượng node
            // có kiểu dữ liệu TreeNode,
            // phần tử đầu tiên sẽ có "Data = null"
            TreeNode node = new TreeNode(null);


            // lấy ra danh sách các bản ghi
            // theo parentId
            var list = records.Where(r => r.ParentId == parentId);


            // sau khi lấy ra danh sách
            // các bản ghi theo parentId
            // thì dùng vòng lặp foreach
            // để duyệt qua các phần tử
            foreach (var item in list)
            {
                TreeNode nodeMini = new TreeNode(item);

                // thực hiện đệ quy
                // để lấy danh sách con của node hiện tại
                TreeNode children = BuildTree(records, item.Id);

                // kiểm tra xem có con nào được thêm vào không
                if (children.ChildrenOfNode.Count > 0)
                {
                    // thêm các con vào danh sách con của nodeMini
                    nodeMini.ChildrenOfNode.AddRange(children.ChildrenOfNode);
                }
                
                node.ChildrenOfNode.Add(nodeMini);
            }

            return node;
        }



        /// <summary>
        /// phương thức GetRoot()
        /// dùng để lấy gốc
        /// </summary>
        public TreeNode GetRoot()
        {
            return root;
        }
    }
}