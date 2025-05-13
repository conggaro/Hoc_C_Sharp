# Cách xem Console.WriteLine() trong dự án WEB API (IDE là Visual Studio 2022)
View => Output => Chọn API - ASP.NET Core Web Server

# Cách quay lại code cũ trong Visual Studio 2022
1. Mở View All Commits (ấn giữ Ctrl + 0 + Y)
2. Chuột phải vào commit mà bạn muốn revert (quay lại)
3. Chọn Revert, Chọn Yes
4. Nếu code xung đột với nhau, thì chuột phải vào commit đó tiếp
5. Chọn Reset, chọn Delete Changes

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
<pre>public static string RemoveDiacritics(string input)
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
Đầu vào: "Nguyễn Văn Ánh", đầu ra: "Nguyen Van Anh"

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

# COM reference là gì?
Component Object Model reference

# Mẫu BeginTransactionAsync
<pre>public async Task ProcessDataAsync()
{
    using (var transaction = await _dbContext.Database.BeginTransactionAsync())
    {
        try
        {
            // Thêm bản ghi vào bảng A
            var entityA = new TableA { Name = "Test A", CreatedAt = DateTime.Now };
            _dbContext.TableAs.Add(entityA);
            await _dbContext.SaveChangesAsync();

            // Thêm bản ghi vào bảng B
            var entityB = new TableB { Name = "Test B", TableAId = entityA.Id };
            _dbContext.TableBs.Add(entityB);
            await _dbContext.SaveChangesAsync();

            // Lưu giao dịch nếu tất cả thành công
            await transaction.CommitAsync();
            Console.WriteLine("Transaction committed successfully.");
        }
        catch (Exception ex)
        {
            // Hủy giao dịch nếu có lỗi xảy ra
            await transaction.RollbackAsync();
            Console.WriteLine($"Transaction rolled back due to error: {ex.Message}");
        }
    }
}
</pre>

<pre>BeginTransactionAsync(): Bắt đầu giao dịch.
CommitAsync(): Lưu giao dịch nếu không có lỗi.
RollbackAsync(): Hủy giao dịch nếu xảy ra lỗi.
SaveChangesAsync(): Thực hiện các thay đổi đối với cơ sở dữ liệu.</pre>

<pre>transaction đảm bảo tính toàn vẹn dữ liệu.
using tự động giải phóng tài nguyên liên quan đến giao dịch.</pre>

# 1 To 00001
<pre>string value = String.Format("{0:D5}", 1);</pre>

# Thêm tháng, giảm tháng
<pre>// Khởi tạo một đối tượng DateTime
        DateTime currentDate = DateTime.Now;
        Console.WriteLine("Ngày hiện tại: " + currentDate);

        // Trừ 1 tháng
        DateTime previousMonth = currentDate.AddMonths(-1);
        Console.WriteLine("Ngày sau khi trừ 1 tháng: " + previousMonth);</pre>

# Chuyển chữ gạch chân _ sang định dạng camelCase
<pre>using System;
using System.Globalization;

class Program
{
    static void Main()
    {
        string[] inputs = 
        {
            "WD_BHXH_SALARY_DIFFERENCE",
            "WD_BHYT_SALARY_DIFFERENCE",
            "WD_BHTN_SALARY_DIFFERENCE",
            "WD_BHTNLD_BNN_SALARY_DIFFERENCE"
        };

        foreach (var input in inputs)
        {
            string camelCase = ConvertToCamelCase(input);
            Console.WriteLine(camelCase);
        }
    }

    static string ConvertToCamelCase(string input)
    {
        // Tách chuỗi bằng dấu gạch dưới
        var parts = input.Split('_');

        // Chuyển đổi từng phần
        for (int i = 0; i < parts.Length; i++)
        {
            if (i == 0)
            {
                parts[i] = parts[i].ToLower(); // Phần đầu tiên viết thường
            }
            else
            {
                parts[i] = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(parts[i].ToLower()); // Các phần còn lại viết hoa ký tự đầu
            }
        }

        // Ghép lại thành chuỗi
        return string.Join("", parts);
    }
}</pre>

# Kiểm tra bị NULL hoặc bị khoảng trắng
<pre>using System;

public class Example
{
   public static void Main()
   {
      string[] values = { null, String.Empty, "ABCDE", 
                          new String(' ', 20), "  \t   ", 
                          new String('\u2000', 10) };
      foreach (string value in values)
         Console.WriteLine(String.IsNullOrWhiteSpace(value));
   }
}
// The example displays the following output:
//       True
//       True
//       False
//       True
//       True
//       True</pre>

# Cách fix server khi publish bị lỗi, lỗi vì lệch phiên bản
<pre>Dùng lệnh sau đây để kiểm tra trên 2 máy là server và máy build hiện tại
dotnet --list-runtimes

sau đó kiểm tra file API.runtimeconfig.json
xem có khớp với phiên bản runtime trên server không

nếu lệch thì Chỉnh sửa file .csproj để dùng đúng phiên bản
&ltPropertyGroup>
    &ltTargetFramework>net9.0&lt/TargetFramework>
    &ltRuntimeFrameworkVersion>9.0.2&lt/RuntimeFrameworkVersion>
&lt/PropertyGroup>

build lại rồi kiểm tra file API.runtimeconfig.json</pre>

# Hàm trả về số lượng ngày trong tháng
<pre>int year = 2024;
int month = 2;
int days = DateTime.DaysInMonth(year, month);
Console.WriteLine($"Số ngày trong tháng {month}/{year} là: {days}"); // Kết quả: 29</pre>

# Lấy ra số thứ tự của một ngày bất kỳ trong năm
<pre>DateTime indexDate1 = new DateTime(2025, 12, 31);
DateTime indexDate2 = new DateTime(2025, 1, 1);
DateTime indexDate3 = new DateTime(2025, 6, 15);

Console.WriteLine(indexDate1.ToString("dd/MM/yyyy")); // 31/12/2025
Console.WriteLine(indexDate2.ToString("dd/MM/yyyy")); // 01/01/2025
Console.WriteLine(indexDate3.ToString("dd/MM/yyyy")); // 15/06/2025

Console.WriteLine(indexDate1.DayOfYear); // 365
Console.WriteLine(indexDate2.DayOfYear); // 1
Console.WriteLine(indexDate3.DayOfYear); // 166</pre>

# Nếu viết code liên quan đến lấy ra số lượng bản ghi thông báo thì nên tham khảo code này
<pre>var list = await (from o in _dbContext.AtNotifications
    from c in _dbContext.HuEmployees.Where(x => x.ID == o.EMP_CREATE_ID).DefaultIfEmpty()
    from cv in _dbContext.HuEmployeeCvs.Where(x => x.ID == c.PROFILE_ID).DefaultIfEmpty()
    where o.EMP_NOTIFY_ID!.Contains(employeeId.ToString())
            && o.ACTION == action
            && ((DateTime.UtcNow.DayOfYear - o.CREATED_DATE!.Value.DayOfYear) <= 30)
            && o.CREATED_DATE!.Value.Year == DateTime.UtcNow.Year
                  orderby (o.UPDATED_DATE ?? o.CREATED_DATE) descending
    select new
    {
        Id = o.ID,
        CreatedDate = o.CREATED_DATE,
        UpdatedDate = o.UPDATED_DATE,
        Name = c.CODE + " - " + cv.FULL_NAME,
        Action = o.ACTION,
        Type = o.TYPE,
        RefId = o.REF_ID,
        StatusNotify = o.STATUS_NOTIFY,
        Title = o.TITLE,
        ModelChange = o.MODEL_CHANGE,
        IsRead = o.IS_READ
    }).ToListAsync();</pre>

# BCrypt.Net.BCrypt.HashPassword
Hash passwords in ASP.NET Core

# Ánh xạ kiểu dữ liệu trong Entity Framework
<div class="modal-card modal-card-full fill-mobile" id="expand-table-modal">
		<div class="modal-card-head padding-xxs buttons buttons-right margin-bottom-none">
			<div><!----> <button data-autofocus="" class="modal-close button button-clear button-sm margin-bottom-none display-flex gap-xxs">
		<span class="icon" aria-hidden="true">
			<span class="docon docon-collapse color-primary"></span>
		</span>
		<span><!---->Collapse table<!----></span>
	</button><!----></div>
		</div>
		<div class="modal-content margin-none margin-xs-tablet content"><!----><div class="has-inner-focus table-wrapper" tabindex="0" role="group" aria-label="Horizontally scrollable data"><table aria-label="Table 1" class="table table-sm margin-top-none">
<thead>
<tr>
<th>SQL Server Database Engine type</th>
<th>.NET Framework type</th>
<th>SqlDbType enumeration</th>
<th>SqlDataReader SqlTypes typed accessor</th>
<th>DbType enumeration</th>
<th>SqlDataReader DbType typed accessor</th>
</tr>
</thead>
<tbody>
<tr>
<td>bigint</td>
<td>Int64</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-bigint" class="no-loc" data-linktype="absolute-path">BigInt</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlint64" class="no-loc" data-linktype="absolute-path">GetSqlInt64</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-int64" class="no-loc" data-linktype="absolute-path">Int64</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getint64" class="no-loc" data-linktype="absolute-path">GetInt64</a></td>
</tr>
<tr>
<td>binary</td>
<td>Byte[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-varbinary" class="no-loc" data-linktype="absolute-path">VarBinary</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlbinary" class="no-loc" data-linktype="absolute-path">GetSqlBinary</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-binary" class="no-loc" data-linktype="absolute-path">Binary</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getbytes" class="no-loc" data-linktype="absolute-path">GetBytes</a></td>
</tr>
<tr>
<td>bit</td>
<td>Boolean</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-bit" class="no-loc" data-linktype="absolute-path">Bit</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlboolean" class="no-loc" data-linktype="absolute-path">GetSqlBoolean</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-boolean" class="no-loc" data-linktype="absolute-path">Boolean</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getboolean" class="no-loc" data-linktype="absolute-path">GetBoolean</a></td>
</tr>
<tr>
<td>char</td>
<td>String<br><br> Char[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-char" class="no-loc" data-linktype="absolute-path">Char</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlstring" class="no-loc" data-linktype="absolute-path">GetSqlString</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-ansistringfixedlength" class="no-loc" data-linktype="absolute-path">AnsiStringFixedLength</a>,<br><br> <a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-string" class="no-loc" data-linktype="absolute-path">String</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getstring" class="no-loc" data-linktype="absolute-path">GetString</a><br><br> <a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getchars" class="no-loc" data-linktype="absolute-path">GetChars</a></td>
</tr>
<tr>
<td>date <sup>1</sup><br><br> (SQL Server 2008 and later)</td>
<td>DateTime</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-date" class="no-loc" data-linktype="absolute-path">Date</a> <sup>1</sup></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqldatetime" class="no-loc" data-linktype="absolute-path">GetSqlDateTime</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-date" class="no-loc" data-linktype="absolute-path">Date</a> <sup>1</sup></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getdatetime" class="no-loc" data-linktype="absolute-path">GetDateTime</a></td>
</tr>
<tr>
<td>datetime</td>
<td>DateTime</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-datetime" class="no-loc" data-linktype="absolute-path">DateTime</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqldatetime" class="no-loc" data-linktype="absolute-path">GetSqlDateTime</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-datetime" class="no-loc" data-linktype="absolute-path">DateTime</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getdatetime" class="no-loc" data-linktype="absolute-path">GetDateTime</a></td>
</tr>
<tr>
<td>datetime2<br><br> (SQL Server 2008 and later)</td>
<td>DateTime</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-datetime2" class="no-loc" data-linktype="absolute-path">DateTime2</a></td>
<td>None</td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-datetime2" class="no-loc" data-linktype="absolute-path">DateTime2</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getdatetime" class="no-loc" data-linktype="absolute-path">GetDateTime</a></td>
</tr>
<tr>
<td>datetimeoffset<br><br> (SQL Server 2008 and later)</td>
<td>DateTimeOffset</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-datetimeoffset" class="no-loc" data-linktype="absolute-path">DateTimeOffset</a></td>
<td>none</td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-datetimeoffset" class="no-loc" data-linktype="absolute-path">DateTimeOffset</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getdatetimeoffset" class="no-loc" data-linktype="absolute-path">GetDateTimeOffset</a></td>
</tr>
<tr>
<td>decimal</td>
<td>Decimal</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-decimal" class="no-loc" data-linktype="absolute-path">Decimal</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqldecimal" class="no-loc" data-linktype="absolute-path">GetSqlDecimal</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-decimal" class="no-loc" data-linktype="absolute-path">Decimal</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getdecimal" class="no-loc" data-linktype="absolute-path">GetDecimal</a></td>
</tr>
<tr>
<td>FILESTREAM attribute (varbinary(max))</td>
<td>Byte[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-varbinary" class="no-loc" data-linktype="absolute-path">VarBinary</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlbytes" class="no-loc" data-linktype="absolute-path">GetSqlBytes</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-binary" class="no-loc" data-linktype="absolute-path">Binary</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getbytes" class="no-loc" data-linktype="absolute-path">GetBytes</a></td>
</tr>
<tr>
<td>float</td>
<td>Double</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-float" class="no-loc" data-linktype="absolute-path">Float</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqldouble" class="no-loc" data-linktype="absolute-path">GetSqlDouble</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-double" class="no-loc" data-linktype="absolute-path">Double</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getdouble" class="no-loc" data-linktype="absolute-path">GetDouble</a></td>
</tr>
<tr>
<td>image</td>
<td>Byte[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-binary" class="no-loc" data-linktype="absolute-path">Binary</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlbinary" class="no-loc" data-linktype="absolute-path">GetSqlBinary</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-binary" class="no-loc" data-linktype="absolute-path">Binary</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getbytes" class="no-loc" data-linktype="absolute-path">GetBytes</a></td>
</tr>
<tr>
<td>int</td>
<td>Int32</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-int" class="no-loc" data-linktype="absolute-path">Int</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlint32" class="no-loc" data-linktype="absolute-path">GetSqlInt32</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-int32" class="no-loc" data-linktype="absolute-path">Int32</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getint32" class="no-loc" data-linktype="absolute-path">GetInt32</a></td>
</tr>
<tr>
<td>money</td>
<td>Decimal</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-money" class="no-loc" data-linktype="absolute-path">Money</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlmoney" class="no-loc" data-linktype="absolute-path">GetSqlMoney</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-decimal" class="no-loc" data-linktype="absolute-path">Decimal</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getdecimal" class="no-loc" data-linktype="absolute-path">GetDecimal</a></td>
</tr>
<tr>
<td>nchar</td>
<td>String<br><br> Char[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-nchar" class="no-loc" data-linktype="absolute-path">NChar</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlstring" class="no-loc" data-linktype="absolute-path">GetSqlString</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-stringfixedlength" class="no-loc" data-linktype="absolute-path">StringFixedLength</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getstring" class="no-loc" data-linktype="absolute-path">GetString</a><br><br> <a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getchars" class="no-loc" data-linktype="absolute-path">GetChars</a></td>
</tr>
<tr>
<td>ntext</td>
<td>String<br><br> Char[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-ntext" class="no-loc" data-linktype="absolute-path">NText</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlstring" class="no-loc" data-linktype="absolute-path">GetSqlString</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-string" class="no-loc" data-linktype="absolute-path">String</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getstring" class="no-loc" data-linktype="absolute-path">GetString</a><br><br> <a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getchars" class="no-loc" data-linktype="absolute-path">GetChars</a></td>
</tr>
<tr>
<td>numeric</td>
<td>Decimal</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-decimal" class="no-loc" data-linktype="absolute-path">Decimal</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqldecimal" class="no-loc" data-linktype="absolute-path">GetSqlDecimal</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-decimal" class="no-loc" data-linktype="absolute-path">Decimal</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getdecimal" class="no-loc" data-linktype="absolute-path">GetDecimal</a></td>
</tr>
<tr>
<td>nvarchar</td>
<td>String<br><br> Char[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-nvarchar" class="no-loc" data-linktype="absolute-path">NVarChar</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlstring" class="no-loc" data-linktype="absolute-path">GetSqlString</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-string" class="no-loc" data-linktype="absolute-path">String</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getstring" class="no-loc" data-linktype="absolute-path">GetString</a><br><br> <a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getchars" class="no-loc" data-linktype="absolute-path">GetChars</a></td>
</tr>
<tr>
<td>real</td>
<td>Single</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-real" class="no-loc" data-linktype="absolute-path">Real</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlsingle" class="no-loc" data-linktype="absolute-path">GetSqlSingle</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-single" class="no-loc" data-linktype="absolute-path">Single</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getfloat" class="no-loc" data-linktype="absolute-path">GetFloat</a></td>
</tr>
<tr>
<td>rowversion</td>
<td>Byte[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-timestamp" class="no-loc" data-linktype="absolute-path">Timestamp</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlbinary" class="no-loc" data-linktype="absolute-path">GetSqlBinary</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-binary" class="no-loc" data-linktype="absolute-path">Binary</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getbytes" class="no-loc" data-linktype="absolute-path">GetBytes</a></td>
</tr>
<tr>
<td>smalldatetime</td>
<td>DateTime</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-datetime" class="no-loc" data-linktype="absolute-path">DateTime</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqldatetime" class="no-loc" data-linktype="absolute-path">GetSqlDateTime</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-datetime" class="no-loc" data-linktype="absolute-path">DateTime</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getdatetime" class="no-loc" data-linktype="absolute-path">GetDateTime</a></td>
</tr>
<tr>
<td>smallint</td>
<td>Int16</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-smallint" class="no-loc" data-linktype="absolute-path">SmallInt</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlint16" class="no-loc" data-linktype="absolute-path">GetSqlInt16</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-int16" class="no-loc" data-linktype="absolute-path">Int16</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getint16" class="no-loc" data-linktype="absolute-path">GetInt16</a></td>
</tr>
<tr>
<td>smallmoney</td>
<td>Decimal</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-smallmoney" class="no-loc" data-linktype="absolute-path">SmallMoney</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlmoney" class="no-loc" data-linktype="absolute-path">GetSqlMoney</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-decimal" class="no-loc" data-linktype="absolute-path">Decimal</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getdecimal" class="no-loc" data-linktype="absolute-path">GetDecimal</a></td>
</tr>
<tr>
<td>sql_variant</td>
<td>Object <sup>2</sup></td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-variant" class="no-loc" data-linktype="absolute-path">Variant</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlvalue" class="no-loc" data-linktype="absolute-path">GetSqlValue</a> <sup>2</sup></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-object" class="no-loc" data-linktype="absolute-path">Object</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getvalue" class="no-loc" data-linktype="absolute-path">GetValue</a> <sup>2</sup></td>
</tr>
<tr>
<td>text</td>
<td>String<br><br> Char[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-text" class="no-loc" data-linktype="absolute-path">Text</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlstring" class="no-loc" data-linktype="absolute-path">GetSqlString</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-string" class="no-loc" data-linktype="absolute-path">String</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getstring" class="no-loc" data-linktype="absolute-path">GetString</a><br><br> <a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getchars" class="no-loc" data-linktype="absolute-path">GetChars</a></td>
</tr>
<tr>
<td>time<br><br> (SQL Server 2008 and later)</td>
<td>TimeSpan</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-time" class="no-loc" data-linktype="absolute-path">Time</a></td>
<td>none</td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-time" class="no-loc" data-linktype="absolute-path">Time</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.gettimespan" class="no-loc" data-linktype="absolute-path">GetTimeSpan</a></td>
</tr>
<tr>
<td>timestamp</td>
<td>Byte[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-timestamp" class="no-loc" data-linktype="absolute-path">Timestamp</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlbinary" class="no-loc" data-linktype="absolute-path">GetSqlBinary</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-binary" class="no-loc" data-linktype="absolute-path">Binary</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getbytes" class="no-loc" data-linktype="absolute-path">GetBytes</a></td>
</tr>
<tr>
<td>tinyint</td>
<td>Byte</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-tinyint" class="no-loc" data-linktype="absolute-path">TinyInt</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlbyte" class="no-loc" data-linktype="absolute-path">GetSqlByte</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-byte" class="no-loc" data-linktype="absolute-path">Byte</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getbyte" class="no-loc" data-linktype="absolute-path">GetByte</a></td>
</tr>
<tr>
<td>uniqueidentifier</td>
<td>Guid</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-uniqueidentifier" class="no-loc" data-linktype="absolute-path">UniqueIdentifier</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlguid" class="no-loc" data-linktype="absolute-path">GetSqlGuid</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-guid" class="no-loc" data-linktype="absolute-path">Guid</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getguid" class="no-loc" data-linktype="absolute-path">GetGuid</a></td>
</tr>
<tr>
<td>varbinary</td>
<td>Byte[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-varbinary" class="no-loc" data-linktype="absolute-path">VarBinary</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlbinary" class="no-loc" data-linktype="absolute-path">GetSqlBinary</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-binary" class="no-loc" data-linktype="absolute-path">Binary</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getbytes" class="no-loc" data-linktype="absolute-path">GetBytes</a></td>
</tr>
<tr>
<td>varchar</td>
<td>String<br><br> Char[]</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-varchar" class="no-loc" data-linktype="absolute-path">VarChar</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlstring" class="no-loc" data-linktype="absolute-path">GetSqlString</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-ansistring" class="no-loc" data-linktype="absolute-path">AnsiString</a>, <a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-string" class="no-loc" data-linktype="absolute-path">String</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getstring" class="no-loc" data-linktype="absolute-path">GetString</a><br><br> <a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getchars" class="no-loc" data-linktype="absolute-path">GetChars</a></td>
</tr>
<tr>
<td>xml</td>
<td>Xml</td>
<td><a href="/en-us/dotnet/api/system.data.sqldbtype#system-data-sqldbtype-xml" class="no-loc" data-linktype="absolute-path">Xml</a></td>
<td><a href="/en-us/dotnet/api/system.data.sqlclient.sqldatareader.getsqlxml" class="no-loc" data-linktype="absolute-path">GetSqlXml</a></td>
<td><a href="/en-us/dotnet/api/system.data.dbtype#system-data-dbtype-xml" class="no-loc" data-linktype="absolute-path">Xml</a></td>
<td>none</td>
</tr>
</tbody>
</table></div><!----></div>
	</div>
