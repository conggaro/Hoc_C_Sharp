using System;

namespace MyApp
{
    public class Subscriber
    {
        public void Receive_From_Publisher(object sender, EventArgs e)
        {
            Console.WriteLine("Subscriber: " + e.ToString());
        }

        public void Sub(Publisher p)
        {
            p.variable_event += Receive_From_Publisher;
        }
    }
}
