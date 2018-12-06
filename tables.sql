create database ProjectsFootmark
GO

use  ProjectsFootmark
GO

create table [User]
(
	ID int primary key identity(1,1),
	Name nvarchar(50) not null,
	NickName nvarchar(50) null,
	[Password] nvarchar(200) not null,
	CreateTime datetime default getdate(),
	Validity bit not null
)

create table Project
(
	ID int primary key identity(1,1),
	Name nvarchar(50) not null,
	CreateTime datetime default getdate(),
	Validity bit not null
)

create table UserProject
(
	ID int primary key identity(1,1),
	UserID int not null,
	ProjectID int not null
)

create table Footmark
(
	ID int primary key identity(1,1),
	ProjectID int not null,
	Content nvarchar(200) null,
	[Year] int not null,
	[Month] int not null,
	[Day] int not null,
	[Hour] int not null,
	[Minute] int not null,
	MarkTime datetime default getdate()
)

create table [Log]
(
	ID int primary key identity(1,1),
	UserID int not null,
	ProjectID int not null,
	[Action] nvarchar(100) null,
	FootmarkID int not null,
)