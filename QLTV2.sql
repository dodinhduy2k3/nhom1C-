create table tacgia(
tacgiaID NVARCHAR2(50) primary key,
tenTacGia varchar2(100));

create table theloai(
theLoaiID NVARCHAR2(50) primary key ,
tenTheLoai nvarchar2(100));

create table sach(
sachID int primary Key,
tenSach nvarchar2(100), 
noiDung varchar2(100) ,
tacgiaID NVARCHAR2(50) ,
theLoaiID NVARCHAR2(50) ,
FOREIGN KEY (tacgiaID) REFERENCES tacgia(tacgiaID),
FOREIGN KEY (theLoaiID) REFERENCES theloai(theLoaiID)
)
create table nguoiDung(
nguoiDungID NVARCHAR2(50) primary key,
tenNguoiDung nvarchar2(25) ,
pass nvarchar2(25)

)
--th?m d? li?u cho b?ng t?c gi? 
INSERT INTO tacgia (tacgiaID, tenTacGia) VALUES (9001, '?? ?�nh Duy');
INSERT INTO tacgia (tacgiaID, tenTacGia) VALUES (9002, 'Ng� V?n H?u');
INSERT INTO tacgia (tacgiaID, tenTacGia) VALUES (9003, 'Ho�ng Trung Hi?u');
INSERT INTO tacgia (tacgiaID, tenTacGia) VALUES (9004, 'L� Xu�n H?i');
INSERT INTO tacgia (tacgiaID, tenTacGia) VALUES (9005, '?inh V?n Duy');

select * from tacgia;
-- th?m d? li?u cho b?ng th? lo?i
INSERT INTO theloai (theLoaiID,tenTheLoai) VALUES (8001, 'Kinh D?');
INSERT INTO theloai (theLoaiID,tenTheLoai) VALUES (8002, N's�ch Thi?u Nhi');
INSERT INTO theloai (theLoaiID,tenTheLoai) VALUES (8003, N's?ch T?m L?');
INSERT INTO theloai (theLoaiID,tenTheLoai) VALUES (8004, N's?ch T?n Gi?o');

select * from theloai;
-- th?m d? li?u cho b?ng s?ch 
INSERT INTO sach (sachID, tenSach,noiDung,tacgiaID,theLoaiID) VALUES (7001, N'Ch? ?? Th? 2 ',N'?Ch? ?? th? II? c? th? ban ph?t cho ng??i d?ng nh?ng si?u n?ng l?c',9001,8001);
INSERT INTO sach (sachID, tenSach,noiDung,tacgiaID,theLoaiID) VALUES (7002, N'?c M?ng Kinh Ho?ng ',N'?gi?m ??p l?n nhau v? v? t?nh ph?m v?o quy t?c ?? tr?n ?p s?t kh? n?i ??y',9001,8001);
INSERT INTO sach (sachID, tenSach,noiDung,tacgiaID,theLoaiID) VALUES (7003, N'T?m V?i ?? ',N'?Ch? ?? th? II? c? th? ban ph?t cho ng??i d?ng nh?ng si?u n?ng l?c',9001,8001);
INSERT INTO sach (sachID, tenSach,noiDung,tacgiaID,theLoaiID) VALUES (7004, N'T?m V?i Xanh ',N'?Ch? ?? th? II? c? th? ban ph?t cho ng??i d?ng nh?ng si?u n?ng l?c',9001,8001);
INSERT INTO sach (sachID, tenSach,noiDung,tacgiaID,theLoaiID) VALUES (7005, N'Doraemon ',N'Ng??i ngo�i h�nh tinh',9002,8002);
INSERT INTO sach (sachID, tenSach,noiDung,tacgiaID,theLoaiID) VALUES (7006, N'T�m ??c',N'L?i s?ng gia ?�nh ',9003,8003);
INSERT INTO sach (sachID, tenSach,noiDung,tacgiaID,theLoaiID) VALUES (7007, N'T�n gi�o ',N' 10 lo?i t�n gi�o c?a th? gi?i',9004,8004);
SELECT * FROM sach;


INSERT INTO nguoiDung (nguoiDungID, tennguoidung, pass) VALUES (1, 'admin', '1');
INSERT INTO nguoiDung (nguoiDungID, tennguoidung, pass) VALUES (2, 'doduy', '1');


select * from nguoidung;


