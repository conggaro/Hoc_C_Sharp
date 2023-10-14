using System;

namespace MyApp
{
    // Publisher là lớp phát đi sự kiện
    // phát sự kiện bằng cách nào?
    // bằng cách gọi một deleage
    // trong phương thức Send()
    public class Publisher
    {
        public delegate void NotifyNews(object data);

        // trong lập trình sự kiện
        // thì không được gán event_news = null
        // bạn chỉ có thể thêm sự kiện mới bằng toán tử +=
        // hoặc hủy đi sự kiện bằng toán tử -=
        public event NotifyNews event_news;

        public void Send()
        {
            // phương thức Invoke()
            // là 1 phương thức có sẵn trong .NET
            // Invoke dịch ra tiếng Việt là "gọi"
            event_news?.Invoke("Co tin moi");
        }
    }
}
