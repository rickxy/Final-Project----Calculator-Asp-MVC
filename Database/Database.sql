Create database Final_Project


create table UsersTbl
(
Uid int identity(1,1) primary key not null,
Username nvarchar(100)Null, 
Password nvarchar(100)Null,
Email nvarchar(100)Null,
)
insert into UsersTbl Values('user','1234','user@yahoo.com')
    
select * from UsersTbl;

create table Calculation
(
Uid int identity(1,1) primary key not null,
FirstNumber int Null, 
SecondNumber int Null,
CommandText nvarchar(100)Null,
Result int Null,
CommandOperator nvarchar(100)Null,
)
