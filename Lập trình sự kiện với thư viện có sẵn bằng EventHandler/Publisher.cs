using System;

namespace MyApp
{
    public class Publisher
    {
        // bình thường
        // thì phải khai báo như này
        // mới có "EventHandler" để mà dùng
        // nhưng .NET có sẵn rồi
        // nên không cần khai báo lại
        // public delegate void EventHandler(object sender?, EventArgs e);


        // tạo biến variable_event
        public event EventHandler variable_event;


        public void Send()
        {
            // tạo đối tượng
            ConNguoi dt = new ConNguoi();
            dt.ho_ten = "Nguyen Van A";
            dt.tuoi = 20;
            dt.gioi_tinh = true;


            // muốn truyền được đối tượng
            // vào trong phương thức Invoke()
            // thì lớp ConNguoi
            // phải kế thừa lớp EventArgs


            // this là đối tượng hiện thời
            // của lớp Publisher
            // bạn có thể this.Send() được luôn
            // bạn cũng có thể this.variable_event được nữa
            // hoàn toàn hợp lý trong
            // lập trình hướng đối tượng
            variable_event?.Invoke(this, dt);
        }
    }
}
