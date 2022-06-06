CREATE DATABASE SWP391
GO 
USE SWP391
GO
-----------------------------------------------------------------------------------------------------------
CREATE TABLE STAFF_USER
(
	staffID int primary key NOT NULL,
	username varchar(30) unique, 
	password varchar(32) not null check(len(password)>=8),
)
go
-----------------------------------------------------------------------------------------------------------
CREATE TABLE CUSTOMER_USER
(
	customerID int primary key NOT NULL,
	name nvarchar(50),
	gender nvarchar(6),
	dateofbirth datetime,
	identity_number int,
	email varchar(50),
	phone varchar(15),
	address nvarchar(128),
	username varchar(30) unique, 
	password varchar(40) not null check(len(password)>=8),
	staffID int foreign key references STAFF_USER(staffID)
)
go


CREATE TABLE HISTORY(
    [historyID] int primary key NOT NULL,
	[name] nvarchar(500) NOT NULL,
	[username] varchar(32) NOT NULL,
	[type_history] nvarchar(100) NOT NULL,
	customerID int foreign key references CUSTOMER_USER(customerID)
)
go

CREATE TABLE PAYMENTHISTORY(
    [user_id] int primary key NOT NULL,
	[name] [nvarchar] (50) NOT NULL,
	[user_name] [varchar](50) NOT NULL,
	[user_phone] varchar(20) NOT NULL,
	[amount] decimal(15, 4) NOT NULL,
	[date] datetime NOT NULL,
	[payment_info] nvarchar(50),
	[status] nvarchar(50) NOT NULL,
	historyID int foreign key references HISTORY(historyID)
)
go

CREATE TABLE COMPENSATIONHISTORY(
    [user_id] int primary key NOT NULL,
	[name] [nvarchar] (50) NOT NULL,
	[user_name] [varchar](50) NOT NULL,
	[user_phone] varchar(20) NOT NULL,
	[amount] decimal(15, 4) NOT NULL,
	[date] datetime NOT NULL,
	[compensation_info] nvarchar(50),
	[status] nvarchar(50) NOT NULL,
	historyID int foreign key references HISTORY(historyID)
)
go

CREATE TABLE PUNISHMENTHISTORY(
    [user_id] int primary key NOT NULL,
	[name] [nvarchar] (50) NOT NULL,
	[user_name] [varchar](50) NOT NULL,
	[user_phone] varchar(20) NOT NULL,
	[amount] decimal(15, 4) NOT NULL,
	[date] datetime NOT NULL,
	[punishment_info] nvarchar(50),
	[status] nvarchar(50) NOT NULL,
	historyID int foreign key references HISTORY(historyID)
)
go

CREATE TABLE ACCIDENTHISTORY(
    [user_id] int primary key NOT NULL,
	[name] [nvarchar] (50) NOT NULL,
	[user_name] [varchar](50) NOT NULL,
	[user_phone] varchar(20) NOT NULL,
	[amount] decimal(15, 4) NOT NULL,
	[date] datetime NOT NULL,
	[accident_info] nvarchar(50),
	[status] nvarchar(50) NOT NULL,
	historyID int foreign key references HISTORY(historyID)
)
go

CREATE TABLE [dbo].[CONTRACT]
(
	[id] [bigint] NOT NULL,
	[name] [nvarchar] (50) NOT NULL,
	[user_name] [varchar](50) NOT NULL,
	[user_email] [varchar](50) NOT NULL,
	[user_phone] [varchar](20) NOT NULL,
	[amount] [decimal](15, 4) NOT NULL,
	[payment_info] [nvarchar](50) NOT NULL,
	[created] [datetime] NOT NULL,
	staffID int foreign key references STAFF_USER(staffID),
    customerID int foreign key references CUSTOMER_USER(customerID)
) 
go
-------------------------------------------------------------------------------------------------------------------
INSERT INTO STAFF_USER VALUES
(01, 'cuongnb', '99999999'),
(02, 'hunghx', '99999999')

INSERT INTO CUSTOMER_USER VALUES
(01, N'Phạm Đức Trung', 'Nam', '01-01-2001', '', 'trungpd@email.com', 0987654321, N'Ninh Bình', 'trungpd', '99999999', 01),
(02, N'Hoàng Quang Hiếu', 'Nam', '02-02-2001', '', 'hieuhq@email.com', 0123456789, N'Yên Bái', 'hieuhq', '99999999', 01),
(03, N'Nguyễn Minh Hoàng', 'Nam', '03-03-2001', '', 'hoangnm@email.com', 0543216789, N'Quảng Ninh', 'hoangnm', '99999999', 02),
(04, N'Đào Anh Dũng', 'Nam', '04-04-2001', '', 'hieuhq@email.com', 0567891234, N'Hà Giang', 'dungda', '99999999', 02)

INSERT INTO HISTORY VALUES
(01, N'Phạm Đức Trung', 'trungpd', 'Payment History', 01),
(02, N'Hoàng Quang Hiếu', 'hieuhq', 'Compensation History', 02),
(03, N'Nguyến Minh Hoàng', 'hoangnm', 'Punishment History', 03),
(04, N'Đào Anh Dũng', 'dungda', 'Accident History', 04)

INSERT INTO PAYMENTHISTORY VALUES
(01, N'Phạm Đức Trung', 'trungpd', 0987654321, 900, '01-01-2021', N'Điều khoản', N'Thành công', 01)

INSERT INTO COMPENSATIONHISTORY VALUES
(01, N'Hoàng Quang Hiếu', 'hieuhq', 0123456789, 1000, '02-01-2021', N'Điều khoản', N'Thất bại', 02)

INSERT INTO PUNISHMENTHISTORY VALUES
(01, N'Nguyễn Minh Hoàng', 'hoangnm', 0543216789, 500, '02-01-2021', N'Điều khoản', N'Thành công', 03)

INSERT INTO ACCIDENTHISTORY VALUES
(01, N'Đào Anh Dũng', 'dungda', 0567891234, 1500, '02-01-2021', N'Điều khoản', N'Thất bại', 04)

INSERT INTO	CONTRACT VALUES
(01, N'Nguyễn Minh Hoàng', 'hoangnm', 'hoangnm@gmail.com', 078932193, 700, 'thanh toan bang tien mat', '01-01-2021', 01, 01),
(02, N'Ngô Bá Cường', 'cuongnb', 'cuongnb@gmail.com', 078932178, 800, 'thanh toan bang tien mat', '01-01-2021', 01, 02)







