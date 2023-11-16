USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = 'LibraryManagementPteam')
BEGIN
    DROP DATABASE LibraryManagementPteam;
END;


CREATE DATABASE LibraryManagementPteam
GO

USE LibraryManagementPteam
GO

CREATE TABLE Gender
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DisplayName NVARCHAR(max)
)
GO

INSERT INTO dbo.Gender (DisplayName )
VALUES  ( N'Nam')
GO

INSERT INTO dbo.Gender (DisplayName )
VALUES  ( N'Nữ')
GO

INSERT INTO dbo.Gender (DisplayName )
VALUES  ( N'Không xác định')
GO

CREATE TABLE Bookshelves
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DisplayName NVARCHAR(max)
)
GO

CREATE TABLE Supliers
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DisplayName NVARCHAR(max),
	PhoneNumber VARCHAR(20),
	Address NVARCHAR(max),
	Email NVARCHAR(200),
	MoreInfo NVARCHAR(max),
	ContractDate DATETIME
)
GO

CREATE TABLE Objects
(
	ID VARCHAR(128) PRIMARY KEY NOT NULL,
	DisplayName NVARCHAR(max),
	Author NVARCHAR(max),
	Kind NVARCHAR(100),
	PublishingYear NVARCHAR(50),
	Pages NVARCHAR(50),
	Copies NVARCHAR(50),
	Catagories NVARCHAR(100),
	IDBookshelf INT,
	IDSuplier INT

	FOREIGN KEY(IDBookshelf) REFERENCES dbo.Bookshelves(ID),
	FOREIGN KEY(IDSuplier) REFERENCES dbo.Supliers(ID)
)
GO

CREATE TABLE Readers
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DisplayName NVARCHAR(max),
	PhoneNumber VARCHAR(20),
	Address NVARCHAR(max),
	IDGender INT NOT NULL,
	Email NVARCHAR(200),
	Facebook NVARCHAR(max),
	MoreInfo NVARCHAR(max),
	BookBorrowCount INT

	FOREIGN KEY(IDGender) REFERENCES dbo.Gender(ID)
)
GO

CREATE TABLE Position
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DisplayName NVARCHAR(max)
)
GO

INSERT INTO	dbo.Position
        ( DisplayName )
VALUES  ( N'Thủ kho'  -- DisplayName - nvarchar(max)
          )
INSERT INTO	dbo.Position
        ( DisplayName )
VALUES  ( N'Nhân viên'  -- DisplayName - nvarchar(max)
          )

CREATE TABLE Staff
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DisplayName NVARCHAR(max),
	Address NVARCHAR(max),
	Email NVARCHAR(200),
	IDGender INT NOT NULL,
	Zalo NVARCHAR(100),
	IDPosition INT, -- Chức vụ
	MoreInfo NVARCHAR(max),
	ContractDate DATETIME,

	FOREIGN KEY(IDPosition) REFERENCES Position(ID),
	FOREIGN KEY(IDGender) REFERENCES dbo.Gender(ID)
)
GO

INSERT dbo.Staff
        ( DisplayName ,
          Address ,
          Email ,
          Zalo ,
		  IDGender,
          IDPosition ,
          MoreInfo ,
          ContractDate
        )
VALUES  ( N'Văn Phát' , -- DisplayName - nvarchar(max)
          N'Đồng Nai' , -- Address - nvarchar(max)
          N'lvphat.it@gmail.com' , -- Email - nvarchar(200)
          N'01257139116' , -- Zalo - nvarchar(100)
		  1,
          1 , -- Position - nvarchar(max)
          N'Rất thông minh và đẹp trai =))' , -- MoreInfo - nvarchar(max)
          GETDATE()  -- ContractDate - datetime
        )
INSERT dbo.Staff
        ( DisplayName ,
          Address ,
          Email ,
		  IDGender,
          Zalo ,
          IDPosition ,
          MoreInfo ,
          ContractDate
        )
VALUES  ( N'Nhân viên' , -- DisplayName - nvarchar(max)
          N'Đồng Nai' , -- Address - nvarchar(max)
          N'nv01@gmail.com' , -- Email - nvarchar(200)
		  2,
          N'0125463987' , -- Zalo - nvarchar(100)
          2 , -- Position - nvarchar(max)
          N'' , -- MoreInfo - nvarchar(max)
          GETDATE()  -- ContractDate - datetime
        )
GO

CREATE TABLE Input
(
	ID VARCHAR(128) PRIMARY KEY NOT NULL,
	DateInput DATETIME,
	IDObjects VARCHAR(128) NOT NULL,
	Count INT,
	InputPrice FLOAT DEFAULT 0,
	OutputPrice FLOAT DEFAULT 0,
	Status NVARCHAR(max),

	FOREIGN KEY(IDObjects) REFERENCES dbo.Objects(ID)
)
GO

CREATE TABLE BookBorrow
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	BorrowDate DATETIME NOT NULL,
	IDBook VARCHAR(128) NOT NULL,
	IDReader INT NOT NULL,
	Count INT,

	FOREIGN KEY(IDBook) REFERENCES dbo.Objects(ID),
	FOREIGN KEY(IDReader) REFERENCES dbo.Readers(ID)
)
GO

CREATE TABLE UserRoles
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DisplayName NVARCHAR(max)
)
GO

CREATE TABLE Users
(
	ID INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
	DisplayName NVARCHAR(max),
	UserName NVARCHAR(100),
	Password NVARCHAR(max), -- string to base64 to MD5
	Avt NVARCHAR(max),
	IDGender INT NOT NULL,
	IDUserRoles INT NOT NULL

	FOREIGN KEY(IDUserRoles) REFERENCES dbo.UserRoles(ID),
	FOREIGN KEY(IDGender) REFERENCES dbo.Gender(ID)
)
GO

INSERT INTO dbo.UserRoles ( DisplayName )
VALUES  ( N'Admin'  -- DisplayName - nvarchar(max)
		)
INSERT INTO dbo.UserRoles ( DisplayName )
VALUES  ( N'Staff'  -- DisplayName - nvarchar(max)
		)
GO

INSERT INTO	dbo.Users
        ( DisplayName ,
          UserName ,
          Password ,
          Avt ,
		  IDGender,
          IDUserRoles
        )
VALUES  ( N'Văn Phát' , -- DisplayName - nvarchar(max)
          N'admin' , -- UserName - nvarchar(100)
          N'db69fc039dcbd2962cb4d28f5891aae1' , -- Password - nvarchar(max)
          N'' , -- Avt - nvarchar(max)
		  1,
          1    -- IDUserRoles - int
		)
INSERT INTO	dbo.Users
        ( DisplayName ,
          UserName ,
          Password ,
          Avt ,
		  IDGender,
          IDUserRoles
        )
VALUES  ( N'Nhân viên' , -- DisplayName - nvarchar(max)
          N'staff' , -- UserName - nvarchar(100)
          N'978aae9bb6bee8fb75de3e4830a1be46' , -- Password - nvarchar(max)
          N'' , -- Avt - nvarchar(max)
		  2,
          2    -- IDUserRoles - int
		)
GO

