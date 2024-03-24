# Bắt đầu tạo project .NET console
Bước 1: Tạo thư mục
(Đặt tên không có dấu tiếng Việt, không có dấu cách)
Ví dụ: Nhap_DuLieu đặt như này thì ok đó.
<br>

Bước 2: Mở thư mục đấy bằng Visual Studio Code (VS Code).
<br>

Bước 3: Mở Terminal trong Visual Studio Code.
<br>

Bước 4: gõ "dotnet new console".
<br>

Bước 5: Viết code tùy ý.
<br>

Bước 6: Lưu code.
<br>

Bước 7: Chạy chương trình thì gõ "dotnet run"
# Xuất ra chương trình .exe và .dll
Nếu bạn muốn xuất ra 1 thư mục chứa chương trình .exe và .dll
<br>

Bước 1: gõ dotnet publish -c tên_thư_mục
<br>

Bước 2: Tìm cái thư mục được xuất ra trong thư mục bin
<br>

--> Nếu chạy chương trình .exe thì gõ tên_chương_trình.exe là xong.
<br>

--> Nếu chạy chương trình .dll thì gõ "dotnet tên_chương_trình.dll" mới được.

# Truy vấn trong C#
1. Lấy 1 bản ghi .FirstOrDefault()
2. Dùng .DefaultIfEmpty() khi kết hợp dữ liệu, giống như khi viết join trong SQL ấy
3. Còn .AsNoTracking() thì để không theo dõi, dể đóng 1 lần truy vấn, mục đích là để mở 1 truy vấn khác, không để nó lỗi.
4. Nếu có .AsNoTracking() thì khi .SaveChanges(), dữ liệu sẽ không bị lưu vào Database.

# Gọi stored procedure trong C#
1. Gọi stored procedure (không có tham số truyền vào).
2. Gọi stored procedure (có tham số truyền vào).

# Cách sử dụng toán tử null coalescing ??
int? x = null;<br>
Console.WriteLine(x);<br>
x = x ?? 10;<br>
Console.WriteLine(x);

# Truy cập thuộc tính bằng indexer (Bộ đánh chỉ mục)
Thay vì viết:<br>
đối_tượng.name = "Nguyen Van A";<br><br>
Thì bây giờ viết là:<br>
đối_tượng["name"] = "Nguyen Van A";

# Sử dụng kiểu dữ liệu dynamic
Ví dụ 1:<br>
<code>public static dynamic TinhTien(dynamic a, dynamic b)
{
    &emsp;&emsp;&emsp;&emsp;return a + b;
}</code>
<br><br>
Ví dụ 2:<br>
<code>public static dynamic TinhTien(dynamic a, dynamic b, dynamic c)
{
    &emsp;&emsp;&emsp;&emsp;return a + b + c;
}</code>
<br><br>
Ví dụ 3:<br>
<code>dynamic dynamicData;
dynamicData = 1;
Console.WriteLine(dynamicData);
dynamicData = "C Sharp";
Console.WriteLine(dynamicData);</code>

# In chữ tiếng Việt có dấu ra ngoài Console của Command Prompt
<code>Console.InputEncoding = Encoding.Unicode;
Console.OutputEncoding = Encoding.Unicode;
Console.WriteLine("Nguyễn Văn A");</code>

# Chuyển JSON sang Object
Ví dụ: cho lớp Person<br>
<code>Person? p = JsonSerializer.Deserialize<Person>(content);</code>

# Chuyển Object sang JSON
Ví dụ: cho lớp Person<br>
<code>string p_str = JsonSerializer.Serialize<Person>(p);</code>

# Kiến thức tiếng Anh
/t∫/<br>
Cách đọc tương tự âm CH.<br>
Nhưng khác là môi hơi tròn, khi nói phải chu ra về phía trước.<br>
Khi luồng khí thoát ra thì môi tròn nửa,<br>
lưỡi thẳng và chạm vào hàm dưới,<br>
để khí thoát ra ngoài trên bề mặt lưỡi<br>
mà không ảnh hưởng đến dây thanh.<br><br>

/dʒ/<br>
Phát âm giống / t∫ / nhưng có rung dây thanh quản.<br>
Cách đọc tương tự: Môi hơi tròn, chi về trước.<br>
Khi khí phát ra, môi nửa tròn,<br>
lưỡi thẳng,<br>
chạm hàm dưới để luồng khí thoát ra trên bề mặt lưỡi.<br>
