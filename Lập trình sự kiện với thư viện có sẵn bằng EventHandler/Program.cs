using System;

namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
                trong lập trình sự kiện của C#
                
                lớp phát đi sự kiện là Publisher
                
                lớp nhận sự kiện là Subscriber
            */

            
            // tạo đối tượng phát sự kiện
            Publisher dt_phat = new Publisher();


            // tạo đối tượng nhận sự kiện
            Subscriber dt_nhan = new Subscriber();


            // đăng ký sự kiện
            // phải đăng ký trước
            // thì trình biên dịch nó mới đứng trước
            // để chờ sự kiện đến
            // đến là đón
            dt_nhan.Sub(dt_phat);


            // phát sự kiện
            dt_phat.Send();
        }
    }
}