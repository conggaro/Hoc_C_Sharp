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
2. Lấy 1 bản ghi .DefaultIfEmpty()
3. Còn .AsNoTracking() thì để không theo dõi, dể đóng 1 lần truy vấn, mục đích là để mở 1 truy vấn khác, không để nó lỗi.

# Gọi stored procedure trong C#
1. Gọi stored procedure (không có tham số truyền vào).
2. Gọi stored procedure (có tham số truyền vào).

# Cách sử dụng toán tử null coalescing ??
int? x = null;<br>
Console.WriteLine(x);<br>
x = x ?? 10;<br>
Console.WriteLine(x);

# Truy cập thuộc tính bằng indexer (Bộ đánh chỉ mục)
Thay vì viết: đối_tượng.name = "Nguyen Van A";<br>
Thì bây giờ viết là: đối_tượng["name"] = "Nguyen Van A";
