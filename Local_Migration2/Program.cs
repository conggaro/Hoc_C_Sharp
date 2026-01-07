using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

// 1. Khởi tạo Context
using var db = new MyAppContext();

// 2. Tự động áp dụng Migration khi chạy App (không cần gõ lệnh update thủ công)
Console.WriteLine("Dang kiem tra va cap nhat Database...");
db.Database.Migrate();

// 3. Thử thêm dữ liệu để kiểm tra
if (!db.Users.Any())
{
    db.Users.Add(new User { Name = "CongPC", CreatedDate = DateTime.Now });
    db.SaveChanges();
    Console.WriteLine("Da tao Database va them User mau!");
}

Console.WriteLine($"Tong so User hien co: {db.Users.Count()}");

// --- Khai báo cấu trúc bảng (Model) ---
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
}

// --- Khai báo DbContext ---
public class MyAppContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Sử dụng LocalDB (đi kèm Visual Studio)
        options.UseSqlServer(@"Server=localhost;Database=DemoMigrationDB;User Id=sa;Password=123456;TrustServerCertificate=True;");
    }
}