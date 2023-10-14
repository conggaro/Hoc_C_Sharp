using System;

namespace MyApp
{
    // SubscriberA
    // lớp này đăng ký nhận sự kiện từ Publisher
    // nhận sự kiện bằng cách nào?
    // nhận bằng phương thức Sub()
    // khi sự kiện xảy ra nó sẽ gọi ReceiverFromPublisher()
    public class SubscriberA
    {
        /*
            Receive                     => là "nhận"
            From                        => là "từ"
            Publisher                   => là "bộ phát"
            Receive From Publisher      => là "nhận sự kiện từ bộ phát"
        */
        void Receive_From_Publisher(object data)
        {
            Console.WriteLine("SubscriberA: " + data.ToString());
        }

        public void Sub(Publisher p)
        {
            p.event_news += Receive_From_Publisher;
        }
    }
}
