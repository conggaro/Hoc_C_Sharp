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

# Chuyển giờ trong máy tính sang định dạng AM PM
Bước 1: Mở Control Panel<br>
Bước 2: Bấm vào Region<br>
Bước 3: Bấm vào Additional Setting...<br>
Bước 4: Bấm vào tab Time ở bên trên của hộp thoại Customize Format<br>
Bước 5: cái drop down list "AM Symbol" thì chọn AM<br>
Bước 6: cái drop down list "BM Symbol" thì chọn BM

# Thêm thuộc tính, phương thức cho đối tượng sau khi khởi tạo
Sử dụng lớp ExpandoObject ở trong namespace System.Dynamic

# Kỹ năng dùng tham số để in ra Console
<code>Console.WriteLine("{0} + {1} = {2}", 1, 5, 6);</code>

<br>
<code>int x = 1;
int y = 6;
int z = 7;
Console.WriteLine($"{x} + {y} = {z}");</code>

# Truyền tham số điều kiện là string cho phương thức Where()
Cách 1:<br>
<code>string condition = "x => x.Length > 5";
var result = words.AsQueryable().Where(condition);</code>

Cách 2:<br>
<code>var result2 = words.AsQueryable().Where("x => x.Length > @0", 5);</code>

# Viết mô tả cho lớp, thuộc tính, phương thức
<code>/// &lt;summary&gt;<br>
/// lớp ModelOrg dùng để làm khuôn mẫu<br>
/// cho các bản ghi<br>
/// &lt;/summary&gt;</code>

# Làm việc với lớp DateTime
lớp DateTime có hỗ trợ toán tử <code><=</code><br>
Nếu bạn muốn tạo đối tượng DateTime là 31/01/2004 00:00 AM<br>
Cách 1: DateTime dt = new DateTime(2004, 1, 31, 0, 0, 0);<br>
Cách 2: Sử dụng thuộc tính Date của đối tượng DateTime luôn, đỡ phải tạo đối tượng

# Định dạng số
<pre>decimal x = 123;
string str = string.Format("{0:000000}", x);
Console.WriteLine(str);</pre>

# Hàm xóa hết dấu
<pre>private static string RemoveDiacritics(string input)
{
    string normalized = input.Normalize(NormalizationForm.FormD);
    StringBuilder builder = new StringBuilder();

    foreach (char c in normalized)
    {
        if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
        {
            builder.Append(c);
        }
    }

    return builder.ToString();
}</pre>

# Làm việc với hàm VLOOKUP trong Excel
VLOOKUP(tham_số_1; tham_số_2; tham_số_3; tham_số_4)<br><br>
tham số 1: ô excel bạn chọn để đem đi so sánh với vùng sẽ select<br>
tham số 2: vùng dữ liệu mà bạn select<br>
tham số 3: cột ở trong vùng select (thường được điền là 1, 2, 3 tương ứng với cột A, cột B hoặc cột C)<br>
tham số 4: tìm tương đối thì điền 0, tìm đúng tuyệt đối thì điền 1<br>

<br>chỗ điền tham số 2 thì bạn nên để dấu đô la vào, vì dấu đô la là địa chỉ tuyệt đối không đổi<br>
ví dụ: VLOOKUP(A1; $D$6:$E$8; 2; FALSE)

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
