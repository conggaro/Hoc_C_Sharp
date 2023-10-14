using System;

namespace MyApp
{
    // muốn truyền được đối tượng
    // vào trong phương thức Invoke()
    // thì lớp ConNguoi
    // phải kế thừa lớp EventArgs
    public class ConNguoi : EventArgs
    {
        public string ho_ten {  get; set; }
        public int tuoi { get; set; }
        public bool gioi_tinh { get; set; }


        // hàm khởi tạo
        public ConNguoi()
        {
            ho_ten = string.Empty;
            tuoi = 0;
            gioi_tinh = true;
        }


        // ghi đè phương thức khởi tạo
        public override string ToString()
        {
            string gioiTinh = gioi_tinh ? "Nam" : "Nu";

            return $"[Ho ten: {ho_ten}, tuoi: {tuoi}, gioi tinh: {gioiTinh}]";
        }
    }
}
