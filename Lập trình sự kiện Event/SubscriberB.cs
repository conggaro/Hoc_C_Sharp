using System;

namespace MyApp
{
    public class SubscriberB
    {
        void Receiver_From_Publisher(object data)
        {
            Console.WriteLine("SubscriberB: " + data.ToString());
        }

        public void Sub(Publisher p)
        {
            p.event_news += Receiver_From_Publisher;
        }
    }
}
