-- tạo cơ sở dữ liệu
CREATE DATABASE StudentDB;
GO


-- sử dụng cơ sở dữ liệu
USE StudentDB;
GO


-- tạo bảng
CREATE TABLE Student(
 [Id] [int] IDENTITY(100,1) PRIMARY KEY,
 [Name] [varchar](100) NULL,
 [Email] [varchar](50) NULL,
 [Mobile] [varchar](50) NULL,
);
GO


-- thêm dữ liệu vào bảng
INSERT INTO Student VALUES ('Anurag','Anurag@dotnettutorial.net','1234567890');
INSERT INTO Student VALUES ('Priyanka','Priyanka@dotnettutorial.net','2233445566');
INSERT INTO Student VALUES ('Preety','Preety@dotnettutorial.net','6655443322');
INSERT INTO Student VALUES ('Sambit','Sambit@dotnettutorial.net','9876543210');


-- tạo stored procedure
CREATE PROCEDURE spGetStudents
AS
BEGIN
     SELECT Id, Name, Email, Mobile
     FROM Student
END


-- tạo stored procedure có truyền tham số
CREATE PROCEDURE spGetStudentById
(
   @Id INT
)
AS
BEGIN
     SELECT Id, Name, Email, Mobile
     FROM Student
     WHERE Id = @Id
END


-- tạo stored procedure
-- có truyền tham số đầu vào (Input)
-- và tham số đầu ra (Output)
CREATE PROCEDURE spCreateStudent
(
    @Name VARCHAR(100),
    @Email VARCHAR(50),
    @Mobile VARCHAR(50),
    @Id int Out
)
AS
BEGIN
	 -- chèn dữ liệu vào bảng
     INSERT INTO Student VALUES (@Name,@Email,@Mobile)


	 -- điều chúng ta muốn ở đây
	 -- là chúng ta cần trả về Id sinh viên
	 -- mới được tạo
	 -- và đây là lúc tham số đầu ra xuất hiện

	 -- ở đây, chúng ta đặt giá trị
	 -- tham số đầu ra với Id sinh viên mới được tạo
	 -- bằng cách sử dụng hàm SCOPE_IDENTITY()
     SELECT @Id = SCOPE_IDENTITY()
END