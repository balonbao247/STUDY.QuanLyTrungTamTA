use master ;DROP database QuanLyTrungTamTA;
go
create database QuanLyTrungTamTA
go
USE QuanLyTrungTamTA
go

CREATE TABLE Accounts (
    Username VARCHAR(9) PRIMARY KEY, -- Chính là TeacherID
    Password NVARCHAR(100) NOT NULL,
    IsActive BIT DEFAULT 1,
    Role NVARCHAR(20) NOT NULL
);
CREATE TABLE Students (
    StudentID VARCHAR(9) PRIMARY KEY,  
    FullName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE,
    Gender NVARCHAR(10),
    PhoneNumber NVARCHAR(15),
    Email NVARCHAR(100),
    Address NVARCHAR(255),
    IdentityNumber NVARCHAR(20) UNIQUE, 
	IsActive BIT DEFAULT 1
);


CREATE TABLE Teachers (
    TeacherID VARCHAR(9) PRIMARY KEY,          -- Khóa chính, tự tăng
    FullName NVARCHAR(100) NOT NULL,                  -- Họ tên
    Gender NVARCHAR(10) NOT NULL,                     -- Giới tính
    DateOfBirth DATE NOT NULL,                        -- Ngày sinh
    PhoneNumber NVARCHAR(15) NOT NULL,                -- SĐT
    Email NVARCHAR(100) NOT NULL,                     -- Email
    Address NVARCHAR(200),                            -- Địa chỉ
    IdentityNumber NVARCHAR(20) NOT NULL,             -- Số CCCD/CMND
    Specialty NVARCHAR(100) NOT NULL    ,              -- Chuyên môn
	Salary int,
	IsActive BIT DEFAULT 1,
	FOREIGN KEY (TeacherID) REFERENCES Accounts(Username)
);

CREATE TABLE SUBJECTS (
    SubjectID VARCHAR(9) PRIMARY KEY,
    SubjectName NVARCHAR(100) NOT NULL,
    Description NVARCHAR(500)
);



CREATE TABLE Courses (
    CourseID VARCHAR(8) PRIMARY KEY,
    CourseName NVARCHAR(100) NOT NULL,
    SubjectID VARCHAR(9), 
    TeacherID VARCHAR(9), 
	NumberOfMeetings int,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    Price DECIMAL(18, 2) NOT NULL,
    IsActive BIT DEFAULT 1,

    CONSTRAINT FK_Courses_Subject FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID),
    CONSTRAINT FK_Courses_Teacher FOREIGN KEY (TeacherID) REFERENCES Teachers(TeacherID)
);
CREATE TABLE TimeSlot (
    TimeSlotID VARCHAR(8) PRIMARY KEY,     -- Mã ca học (TS001, TS002, ...)
    TimeSlotName NVARCHAR(100) NOT NULL,   -- Tên gọi: "Ca 1", "Ca sáng", "Ca chiều"
    StartTime TIME NOT NULL,               -- Giờ bắt đầu (ví dụ: 08:00)
    EndTime TIME NOT NULL                  -- Giờ kết thúc (ví dụ: 09:30)
);

CREATE TABLE Rooms (
    RoomID VARCHAR(10) PRIMARY KEY,
    RoomName NVARCHAR(50),
    Capacity INT,
	IsActive BIT DEFAULT 1
);

CREATE TABLE CourseSchedule (
    ScheduleID INT IDENTITY PRIMARY KEY,
    CourseID VARCHAR(8),
    TimeSlotID VARCHAR(8),  
	RoomID VARCHAR(10),
    DayOfWeek INT,           

    CONSTRAINT FK_Schedule_Course FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    CONSTRAINT FK_Schedule_TimeSlot FOREIGN KEY (TimeSlotID) REFERENCES TimeSlot(TimeSlotID),
	CONSTRAINT FK_Schedule_Room  FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
);

CREATE TABLE CourseStudent (
    CourseID VARCHAR(8),
    StudentID VARCHAR(9),
    EnrollDate DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (CourseID, StudentID),
    FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    FOREIGN KEY (StudentID) REFERENCES Students(StudentID)
);

CREATE TABLE Payments (
    PaymentID NVARCHAR(50) PRIMARY KEY,    
    StudentID VARCHAR(9) NOT NULL,     
	CourseID VARCHAR(8) NOT NULL,
    TotalAmount DECIMAL(18, 2) NOT NULL,      
	PaymentDate VARCHAR(20),      
    PaymentStatus NVARCHAR(20),        
	PaymentMethod NVARCHAR(20),
    CONSTRAINT FK_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID), 
    CONSTRAINT FK_Course FOREIGN KEY (CourseID) REFERENCES Courses(CourseID)       
);

CREATE TABLE StudentAttendance (
    AttendanceID VARCHAR(10) PRIMARY KEY,      -- Khóa chính tự tăng
    CourseID VARCHAR(8) NOT NULL,               -- Mã khóa học
    StudentID VARCHAR(9) NOT NULL,              -- Mã học viên
    AttendanceDate DATE NOT NULL,               -- Ngày điểm danh
    Status NVARCHAR(20) NOT NULL,               -- Trạng thái: 'Present', 'Absent', 'Late'
    CONSTRAINT FK_Attendance_Course FOREIGN KEY (CourseID) REFERENCES Courses(CourseID),
    CONSTRAINT FK_Attendance_Student FOREIGN KEY (StudentID) REFERENCES Students(StudentID),

);



INSERT INTO Accounts (Username, Password, IsActive, Role)
VALUES ('TEA000001', 'bcb15f821479b4d5772bd0ca866c00ad5f926e3580720659cc80d39c9d09802a', 1, N'Teacher'),
('TEA000002', 'bcb15f821479b4d5772bd0ca866c00ad5f926e3580720659cc80d39c9d09802a', 1, N'Teacher'),
('TEA000003', 'bcb15f821479b4d5772bd0ca866c00ad5f926e3580720659cc80d39c9d09802a', 1, N'Teacher'),
('EMP000001','bcb15f821479b4d5772bd0ca866c00ad5f926e3580720659cc80d39c9d09802a',1,'Admin');






INSERT INTO Students (StudentID, FullName, Gender, DateOfBirth, PhoneNumber, Email, Address, IdentityNumber)
VALUES 
    ('STU000001', N'Nguyễn Văn A', N'Nam', '2005-08-15', '0123456789', 'vana@example.com', N'123 Lê Lợi, Q.1, TP.HCM', '123456789'),
    ('STU000002', N'Hoàng Văn B', N'Nam', '2005-08-15', '0123456789', 'vana@example.com', N'123 Lê Lợi, Q.1, TP.HCM', '123456782'),
    ('STU000003', N'Nguyễn Mỹ C', N'Nữ', '2005-08-15', '0123456789', 'vana@example.com', N'123 Lê Lợi, Q.1, TP.HCM', '123456780');

INSERT INTO Teachers (TeacherID, FullName, Gender, DateOfBirth, PhoneNumber, Email, Address, IdentityNumber, Specialty,Salary)
VALUES
('TEA000001', N'Nguyễn Văn A', N'Nam', '1985-01-15', '0912345678', 'nguyenvana@gmail.com', N'Hà Nội', '012345678901', N'Ngữ pháp cơ bản',300000),
('TEA000002', N'Trần Thị B', N'Nữ', '1990-05-20', '0934567890', 'tranthib@gmail.com', N'TP. Hồ Chí Minh', '123456789012', N'Giao tiếp',250000),
('TEA000003', N'Lê Minh C', N'Nam', '1988-08-10', '0978123456', 'leminhc@gmail.com', N'Đà Nẵng', '234567890123', N'IELTS',200000);

INSERT INTO TimeSlot (TimeSlotID, TimeSlotName, StartTime, EndTime)
VALUES 
('TS001', N'Ca 1 - Sáng', '08:00', '09:30'),
('TS002', N'Ca 2 - Sáng', '10:00', '11:30'),
('TS003', N'Ca 3 - Chiều', '14:00', '15:30'),
('TS004', N'Ca 4 - Chiều', '16:00', '17:30'),
('TS005', N'Ca 5 - Tối',   '18:00', '19:30');




INSERT INTO SUBJECTS (SubjectID, SubjectName, Description)
VALUES
('S01', N'Tiếng Anh cơ bản', N'Khóa học tiếng Anh dành cho người mới bắt đầu'),
('S02', N'Tiếng Anh A1', N'Khóa học Tiếng Anh cấp độ A1 cho người mới học'),
('S03', N'Tiếng Anh A2', N'Khóa học Tiếng Anh cấp độ A2'),
('S04', N'Tiếng Anh B1', N'Khóa học Tiếng Anh cấp độ B1'),
('S05', N'Tiếng Anh B2', N'Khóa học Tiếng Anh cấp độ B2'),
('S06', N'Tiếng Anh C1', N'Khóa học Tiếng Anh cấp độ C1'),
('S07', N'Tiếng Anh C2', N'Khóa học Tiếng Anh cấp độ C2'),
('S08', N'Tiếng Anh giao tiếp', N'Khóa học Tiếng Anh giao tiếp thực hành');


INSERT INTO Courses (CourseID, CourseName, SubjectID,TeacherID,NumberOfMeetings,StartDate, EndDate,  Price, IsActive)
VALUES
('C0001', N'Khóa học Tiếng Anh cơ bản', 'S01','TEA000001', 24,'2025-05-01', '2025-06-24', 1000000, 1);


-- Giả sử đã có RoomID = 'R001'
INSERT INTO Rooms (RoomID, RoomName, Capacity)
VALUES 
('R001', N'Phòng 1', 30),
('R002', N'Phòng 2', 30),
('R003', N'Phòng 3', 2);

INSERT INTO CourseSchedule (CourseID, TimeSlotID, RoomID, DayOfWeek)
VALUES 
('C0001', 'TS001', 'R001', 2),  
('C0001', 'TS001', 'R001', 4),  
('C0001', 'TS001', 'R001', 6);  

INSERT INTO CourseStudent (CourseID, StudentID)
VALUES
('C0001', 'STU000001');

INSERT INTO Payments (PaymentID, StudentID,CourseID, TotalAmount, PaymentDate, PaymentStatus, PaymentMethod)
VALUES
    ('PM000001', 'STU000001','C0001', 1000000.00,'', 'Pending','');
GO

CREATE PROCEDURE InsertAttendanceForCourse
    @CourseID VARCHAR(8), -- Mã khóa học
    @NumberOfClasses INT  -- Số buổi học (ví dụ: 24 buổi)
AS
BEGIN
    DECLARE @StartDate DATE;
	SET DATEFIRST 1; 
    -- Lấy ngày bắt đầu khóa học
    SELECT @StartDate = StartDate FROM Courses WHERE CourseID = @CourseID;

    -- Lấy danh sách thứ học trong tuần (DayOfWeek) của khóa học
    DECLARE @DayOfWeeks TABLE (DayOfWeek INT);
    INSERT INTO @DayOfWeeks (DayOfWeek)
    SELECT DISTINCT DayOfWeek
    FROM CourseSchedule
    WHERE CourseID = @CourseID;

    -- Tạo bảng tạm lưu ngày điểm danh hợp lệ (theo lịch học)
    DECLARE @DateTable TABLE (AttendanceDate DATE);
    DECLARE @Date DATE = @StartDate;
    DECLARE @Count INT = 0;

    -- Tạo các ngày học cho khóa học
    WHILE @Count < @NumberOfClasses
    BEGIN
        -- Kiểm tra nếu ngày hiện tại là một trong những ngày học của khóa học
        IF EXISTS (
            SELECT 1 FROM @DayOfWeeks WHERE DayOfWeek = DATEPART(WEEKDAY, @Date)
        )
        BEGIN
            -- Nếu đúng thì chèn ngày vào bảng tạm
            INSERT INTO @DateTable (AttendanceDate) VALUES (@Date);
            SET @Count += 1;
        END
        -- Tiến hành cộng thêm một ngày vào @Date
        SET @Date = DATEADD(DAY, 1, @Date);

        -- Kiểm tra nếu vòng lặp không thể tìm thấy ngày hợp lệ sau một số lần chạy
        IF @Date > DATEADD(DAY, @NumberOfClasses * 7, @StartDate)
        BEGIN
            PRINT 'Không thể tạo đủ số buổi học trong khoảng thời gian này';
            BREAK; -- Thoát khỏi vòng lặp khi không thể tạo đủ buổi học
        END
    END

    -- Lấy số thứ tự hiện tại để sinh mã AttendanceID tiếp theo
    DECLARE @StartIndex INT = (
        SELECT ISNULL(MAX(CAST(SUBSTRING(AttendanceID, 4, 6) AS INT)), 0) FROM StudentAttendance
    );

    -- Chèn dữ liệu điểm danh cho học viên
    INSERT INTO StudentAttendance (AttendanceID, CourseID, StudentID, AttendanceDate, Status)
    SELECT
        'ATD' + RIGHT('000000' + CAST(ROW_NUMBER() OVER (ORDER BY cstu.StudentID, dt.AttendanceDate) + @StartIndex AS VARCHAR), 6),
        @CourseID,
        cstu.StudentID,
        dt.AttendanceDate,
        'Absent'
    FROM 
        @DateTable dt
    JOIN 
        CourseStudent cstu ON cstu.CourseID = @CourseID;
END
GO
EXEC InsertAttendanceForCourse @CourseID = 'C0001', @NumberOfClasses = 24;




