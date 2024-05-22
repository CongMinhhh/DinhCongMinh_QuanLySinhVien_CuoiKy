use master 
go
drop database if exists QuanLySinhVien_CuoiKy_C
go
create database QuanLySinhVien_CuoiKy_C
go
use QuanLySinhVien_CuoiKy_C
go
--DinhCongMinh - 21115053120334
SET DATEFORMAT dmy;
create table Truong
(
	MaTruong varchar(10) primary key not null,
	TenTruong nvarchar(100),
	Gmail varchar(50) unique
		check (Gmail like '%@%'),
	SDT char(10)
		check (len(SDT) = 10 and (
            left(SDT, 3) in ('090', '098', '091', '031', '035', '038')
        )),
	DiaChi nvarchar(50)
)
create table Khoa
(
	MaKhoa varchar(10) primary key not null,
	TenKhoa nvarchar(100),
	Gmail varchar(50) unique
		check (Gmail like '%@%'),
	SDT char(10)
		check (len(SDT) = 10 and (
            left(SDT, 3) in ('090', '098', '091', '031', '035', '038')
        )),
	MaTruong varchar(10) foreign key (MaTruong) references Truong(MaTruong)
		on update
			no action
		on delete
			no action
)
create table GiaoVien
(
	MaGV varchar(10) primary key not null,
	TenGiaoVien nvarchar(50)
		check (len(TenGiaoVien) >= 10 and len(TenGiaoVien) <= 50),
	Gmail varchar(50) unique
		check (Gmail like '%@%'),
	SDT char(10)
		check (len(SDT) = 10 and (
            left(SDT, 3) in ('090', '098', '091', '031', '035', '038')
        )),
	MaKhoa varchar(10) foreign key (MaKhoa) references Khoa(MaKhoa)
		on update
			no action
		on delete
			no action
)
create table LopSinhHoat
(
	MaLSH varchar(10) primary key not null,
	TenLSH nvarchar(50),
	SoLuong int,
	MaGV varchar(10) foreign key (MaGV) references GiaoVien(MaGV)
		on update
			no action
		on delete
			no action,
	MaKhoa varchar(10) foreign key (MaKhoa) references Khoa(MaKhoa)
		on update
			no action
		on delete
			no action
)
create table LopHocPhan
(
	MaLHP varchar(10) primary key not null,
	TenLHP nvarchar(50),
	SoLuong int,
	SoTinChi int,
	NgayBatDau date,
	MaGV varchar(10) foreign key (MaGV) references GiaoVien(MaGV)
		on update
			no action
		on delete
			no action
)
create table SinhVien
(
	MaSV varchar(10) primary key,
	TenSinhVien nvarchar(50)
		check (len(TenSinhVien) >= 10 and len(TenSinhVien) <= 50),
	NgaySinh DATE CHECK (NgaySinh <= GETDATE() 
                         AND (
                             (DATEPART(MONTH, NgaySinh) IN (4, 6, 9, 11) AND DATEPART(DAY, NgaySinh) <= 30)
                             OR (DATEPART(MONTH, NgaySinh) = 2 AND (
                                 (DATEPART(YEAR, NgaySinh) % 4 = 0 AND (DATEPART(YEAR, NgaySinh) % 100 <> 0 OR DATEPART(YEAR, NgaySinh) % 400 = 0) AND DATEPART(DAY, NgaySinh) <= 29)
                                 OR (DATEPART(YEAR, NgaySinh) % 4 <> 0 AND DATEPART(DAY, NgaySinh) <= 28)
                             ))
                             OR (DATEPART(MONTH, NgaySinh) NOT IN (2, 4, 6, 9, 11) AND DATEPART(DAY, NgaySinh) <= 31)
							)
                        ),
	GioiTinh nvarchar(10) default ('Nam')
		check (GioiTinh in (N'Nam', N'Nữ', N'Khác')),
	QueQuan nvarchar(100),
	SDT char(10)
		check (len(SDT) = 10 and (
            left(SDT, 3) in ('090', '098', '091', '031', '035', '038')
        )),
	Gmail varchar(50) unique
		check (Gmail like '%@%'),
	MaLSH varchar(10) foreign key (MaLSH) references LopSinhHoat(MaLSH)
		on update
			no action
		on delete
			no action
)
create table SV_LHP
(
	MaLHP varchar(10) foreign key (MaLHP) references LopHocPhan(MaLHP)
		on update
			cascade
		on delete
			cascade,
	MaSV varchar(10) foreign key (MaSV) references SinhVien(MaSV)
		on update
			cascade
		on delete
			cascade,
	primary key (MaLHP, MaSV),
	DiemHocPhan int CHECK (DiemHocPhan BETWEEN 0 AND 100)
)

--Truong
INSERT INTO Truong (MaTruong, TenTruong, Gmail, SDT, DiaChi) 
VALUES
	('T001', N'Đại học Sư phạm Kỹ thuật Đà Nẵng', 'dhspktdn@ute.edu.vn', '0912345678', N'48 Cao Thắng, Thanh Châu, Đà Nẵng'),
	('T002', N'Đại học Quốc Gia Hà Nội', 'dhqg@vnu.edu.vn', '0988456789', N'144 Xuân Thủy, Cầu Giấy, Hà Nội'), 
	('T003', N'Đại học Kinh Tế Quốc Dân', 'dhtc@neu.edu.vn', '0913456789', N'207 Giải Phóng, Đồng Tâm, Hai Bà Trưng, Hà Nội'),
	('T004', N'Đại học Công Nghệ Thông Tin', 'dhcntt@uet.vnu.edu.vn', '0988123456', N'144 Xuân Thủy, Cầu Giấy, Hà Nội'),
	('T005', N'Đại học Nông Lâm Thái Nguyên', 'dhnl@tuaf.edu.vn', '0908456789', N'Đường Trịnh Văn Bô, Thái Nguyên'),
	('T006', N'Trường Đại Học Điện Lực', 'dhđl@epu.edu.vn', '0912387123', N'235 Hoàng Quốc Việt, Cầu Giấy, Hà Nội'),
	('T007', N'Trường Đại Học Y Dược Thái Nguyên', 'dhyd@uthn.edu.vn', '0908654321', N'Số 2 Lương Ngọc Quyến, Thái Nguyên'),
	('T008', N'Trường Đại Học Sư Phạm Hà Nội', 'dhsp@hnue.edu.vn', '0913159753', N'136 Xuân Thủy, Cầu Giấy, Hà Nội'),
	('T009', N'Trường Đại Học Giao Thông Vận Tải', 'dhgtvt@utc.edu.vn', '0913753159', N'3 Cầu Giấy, Cầu Giấy, Hà Nội'),
	('T010', N'Trường Đại Học Kiến Trúc Hà Nội', 'dhkt@hau.edu.vn', '0913951753', N'Số 132 Xuân Thủy, Cầu Giấy, Hà Nội');

--Khoa
INSERT INTO Khoa (MaKhoa, TenKhoa, Gmail, SDT, MaTruong) 
VALUES
	('K001', N'Khoa Công Nghệ Số', 'cns@ute.edu.vn', '0912345678', 'T001'),
	('K002', N'Khoa Kinh Tế', 'kinhte@vnu.edu.vn', '0988456789', 'T001'), 
	('K003', N'Khoa Quản Trị Kinh Doanh', 'qtkinhdoanh@neu.edu.vn', '0913456789', 'T001'),
	('K004', N'Khoa Luật', 'luat@uet.vnu.edu.vn', '0358123456', 'T004'),
	('K005', N'Khoa Nông Nghiệp', 'nongnghiep@tuaf.edu.vn', '0908456789', 'T005'),
	('K006', N'Khoa Điện', 'dien@epu.edu.vn', '0912387123', 'T006'),
	('K007', N'Khoa Y Dược', 'y-duoc@uthn.edu.vn', '0908654321', 'T007'),
	('K008', N'Khoa Sư Phạm', 'su-pham@hnue.edu.vn', '0913159753', 'T008'),
	('K009', N'Khoa Giao Thông Vận Tải', 'giaothong@utc.edu.vn', '0913753159', 'T009'),
	('K010', N'Khoa Kiến Trúc', 'kien-truc@hau.edu.vn', '0913951753', 'T010');

--GiaoVien
INSERT INTO GiaoVien (MaGV, TenGiaoVien, Gmail, SDT, MaKhoa) 
VALUES
	('GV001', N'Đỗ Phú Huy', 'dph@ute.edu.vn', '0912345678', 'K001'),
	('GV002', N'Trần Thị Bích Hằng', 'hangttb@vnu.edu.vn', '0988456789', 'K001'),
	('GV003', N'Lê Minh Hoàng', 'hoangmin@neu.edu.vn', '0913456789', 'K001'),
	('GV004', N'Phạm Thị Thu Hương', 'huongptt@uet.vnu.edu.vn', '0358123456', 'K004'),
	('GV005', N'Nguyễn Đức Toàn', 'toannd@tuaf.edu.vn', '0908456789', 'K005'),
	('GV006', N'Trần Văn Cường', 'cuongtv@epu.edu.vn', '0912387123', 'K006'),
	('GV007', N'Lê Thị Thanh Tú', 'tutlt@uthn.edu.vn', '0908654321', 'K007'),
	('GV008', N'Phạm Thị Thanh Vân', 'vanptt@hnue.edu.vn', '0913159753', 'K008'),
	('GV009', N'Nguyễn Đình Hiệp', 'hiepnd@utc.edu.vn', '0913753159', 'K009'),
	('GV010', N'Trần Hồng Nhung', 'nhungth@hau.edu.vn', '0913951753', 'K010');

--LopSinhHoat
INSERT INTO LopSinhHoat (MaLSH, TenLSH, SoLuong, MaGV, MaKhoa) 
VALUES
	('LSH001', N'21T1', 25, 'GV001', 'K001'),
	('LSH002', N'21T2', 30, 'GV002', 'K001'),
	('LSH003', N'21T3', 20, 'GV003', 'K001'),
	('LSH004', N'Câu lạc bộ Hóa học', 22, 'GV004', 'K004'),
	('LSH005', N'Câu lạc bộ Sinh học', 28, 'GV005', 'K005'),
	('LSH006', N'Câu lạc bộ Kinh tế', 27, 'GV006', 'K006'),
	('LSH007', N'Câu lạc bộ Luật', 24, 'GV007', 'K007'),
	('LSH008', N'Câu lạc bộ Ngoại ngữ', 29, 'GV008', 'K008'),
	('LSH009', N'Câu lạc bộ Kỹ thuật', 26, 'GV009', 'K009'),
	('LSH010', N'Câu lạc bộ Nông nghiệp', 23, 'GV010', 'K010');

--LopHocPhan
INSERT INTO LopHocPhan (MaLHP, TenLHP, SoLuong, SoTinChi, NgayBatDau, MaGV) 
VALUES
	('LHP001', N'Lập trình C#', 45, 2, '22-08-2023', 'GV001'),
	('LHP002', N'Lập trình C++', 50, 4, '22-08-2023', 'GV002'),
	('LHP003', N'Vật lý đại cương', 42, 4, '22-08-2023', 'GV003'),
	('LHP004', N'Hóa học đại cương', 38, 4, '22-08-2023', 'GV004'),
	('LHP005', N'Sinh học tế bào', 35, 3, '22-08-2023', 'GV005'),
	('LHP006', N'Kinh tế vi mô', 40, 3, '22-08-2023', 'GV006'),
	('LHP007', N'Luật hiến pháp', 47, 3, '22-08-2023', 'GV007'),
	('LHP008', N'Tiếng Anh 1', 55, 3, '22-08-2023', 'GV008'),
	('LHP009', N'Kỹ thuật nhiệt', 43, 4, '22-08-2023', 'GV009'),
	('LHP010', N'Nông học đại cương', 40, 3, '22-08-2023', 'GV010');

--SinhVien
INSERT INTO SinhVien (MaSV, TenSinhVien, NgaySinh, GioiTinh, QueQuan, SDT, Gmail, MaLSH)
VALUES
	('SV001', N'Đinh Công Minh', '02-07-2003', N'Nam', N'Quảng Bình', '0901234567', 'dinhcongminh@gmail.com', 'LSH001'),
	('SV002', N'Trần Thị Bình', '20-08-2002', N'Nữ', N'TP. Hồ Chí Minh', '0982345678', 'tranthibinh@gmail.com', 'LSH002'),
	('SV003', N'Lê Hoàng Dương', '15-03-2003', N'Nam', N'Đà Nẵng', '0912456789', 'lehoangduong@gmail.com', 'LSH003'),
	('SV004', N'Nguyễn Thị Hoa', '01-11-2000', N'Nữ', N'Cần Thơ', '0905678905', 'nguyenthihoa@gmail.com', 'LSH004'),
	('SV005', N'Trần Đăng Khoa', '25-06-2001', N'Nam', N'Đà Lạt', '0358901234', 'trandangkhoa@gmail.com', 'LSH005'),
	('SV006', N'Phạm Thị Lan', '10-09-2002', N'Nữ', N'Huế', '0912345678', 'phamthilan@gmail.com', 'LSH006'),
	('SV007', N'Nguyễn Quốc Minh', '05-04-2003', N'Nam', N'Quảng Ninh', '0985678901', 'nguyenquocminh@gmail.com', 'LSH007'),
	('SV008', N'Trần Thị Ngọc', '18-12-2000', N'Nữ', N'Bình Dương', '0905678901', 'tranthingoc@gmail.com', 'LSH008'),
	('SV009', N'Lê Văn Tài', '30-07-2001', N'Nam', N'Nghệ An', '0912678901', 'levantan@gmail.com', 'LSH009'),
	('SV010', N'Phạm Thị Tâm', '08-10-2002', N'Nữ', N'Đắk Lắk', '0915901234', 'phamthitam@gmail.com', 'LSH010');


--SV_LHP
INSERT INTO SV_LHP (MaLHP, MaSV, DiemHocPhan) 
VALUES
	('LHP001', '001', 90),
	('LHP002', '002', 75),
	('LHP003', '003', 82),
	('LHP004', '004', 76),
	('LHP005', '005', 85),
	('LHP006', '006', 85),
	('LHP007', '007', 95),
	('LHP008', '008', 80),
	('LHP009', '009', 75),
	('LHP010', '010', 85);