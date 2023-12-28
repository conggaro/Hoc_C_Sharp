using System;

namespace MyApp
{
    public class Program
    {
        public static unsafe void Main()
        {
            int myVariable = 42;

            // Sử dụng từ khóa unsafe để sử dụng con trỏ
            unsafe
            {
                // Lấy địa chỉ của biến
                int* address = &myVariable;


                // cách 1:
                // In địa chỉ (không hoàn toàn chính xác - AI nói vậy)
                Console.WriteLine($"Dia chi cua bien la: 0x{(ulong)address:X}");



                // Để in ra địa chỉ của một biến trong C#
                // bạn cần sử dụng phép ép kiểu địa chỉ IntPtr
                // và sử dụng phương thức ToString() với đối số "X"
                // để in ra giá trị dưới dạng số hexa.

                // cách 2: chính xác hơn cách 1
                Console.WriteLine($"\nDia chi cua bien la: 0x{new IntPtr(address):X}");
            }
        }
    }
}


/*
    Ghi chú 1:
    
    Đoạn mã trên có tác dụng sử dụng từ khóa unsafe
    trong C# để thực hiện các thao tác liên quan đến con trỏ.

    Trong C#, việc sử dụng con trỏ được coi là không an toàn
    và mặc định là bị cấm.

    Tuy nhiên, bằng cách sử dụng từ khóa unsafe,
    bạn có thể bỏ qua các ràng buộc an toàn
    và thao tác trực tiếp với bộ nhớ.
*/


/*
    Ghi chú 2:
    
    Trong C#, bạn không thể trực tiếp
    in ra địa chỉ của một biến
    như trong một số ngôn ngữ khác như C hoặc C++.

    C# được thiết kế để cung cấp mức độ trừu tượng
    và an toàn hơn.

    Do đó, các chi tiết về địa chỉ bộ nhớ
    thường không được tiếp cận trực tiếp
    từ mã nguồn C# thông thường.

    Tuy nhiên, bạn có thể sử dụng một số công cụ hỗ trợ
    để theo dõi địa chỉ của đối tượng
    trong quá trình chạy,
    nhưng điều này thường không được khuyến khích
    và chỉ nên được sử dụng
    trong môi trường phát triển hoặc debug.

    Lưu ý rằng để biên dịch chương trình trên,
    bạn cần bật tùy chọn "Allow unsafe code"
    trong thiết lập dự án của bạn.

    Tuy nhiên, hãy nhớ rằng việc sử dụng con trỏ
    và unsafe code có thể gây ra
    các vấn đề an toàn và nên được thực hiện cẩn thận.
*/