using System;


/*
    bình thường chúng ta có
    1. dùng class để tạo biến, đối tượng
    2. dùng struct để tạo biến, đối tượng
    
    sau khi học delegate
    thì có thể tạo biến bằng kiểu delegate
    tự định nghĩa
*/


namespace MyApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
                --- GIỚI THIỆU VỀ LẬP TRÌNH SỰ KIỆN ---

                các sự kiện "event"
                là cơ chế
                để một đối tượng này
                thông báo đến đối tượng khác
                có 1 cái điều gì đó
                mà lớp khác quan tâm vừa xảy ra

                lớp mà từ đó gửi đi sự kiện
                thì nó gọi là "publisher"

                các lớp nhận được sự kiện
                gọi là các "subscriber"
            */


            /*
                để làm được việc này
                nó hoạt động giống hệt cơ chế "delegate"
                
                thực tế là trong .NET
                thì các event xây dựng với nền tảng
                chính là delegate

                nên trước khi tìm hiểu event
                hãy vào tìm hiểu "delegate" trước
            */


            // tạo đối tượng phát sự kiện
            Publisher dt_phat = new Publisher();


            // tạo đối tượng nhận sự kiện
            SubscriberA dt_nhan1 = new SubscriberA();

            SubscriberB dt_nhan2 = new SubscriberB();


            // bạn phải đăng ký nhận sự kiện
            // trước khi lập trình phát sự kiện
            dt_nhan1.Sub(dt_phat);
            dt_nhan2.Sub(dt_phat);


            // bây giờ phát sự kiện
            // vì đã đăng ký nhận bằng Sub()
            // ở bên trên
            dt_phat.Send();
        }
    }
}