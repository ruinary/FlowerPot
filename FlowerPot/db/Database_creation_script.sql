--use master; 
--create database FlowerPot;

use FlowerPot

----------------------------------------------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------------------------------------------
	
	create table UserAuth
(
	id_user int  primary key not null,
	login  nvarchar(20),
	password  nvarchar(128),
	
);

	create table Users
(
	id_user int foreign key references UserAuth(id_user),
	is_admin bit not null, --0-user, 1-admin
	First_Name nvarchar(20) not null,
	Last_Name nvarchar(20) not null,
	Midle_Name nvarchar(20),
	email nvarchar(100),
	phone_num nvarchar(13),
	user_img_path nvarchar(200),
);
insert into UserAuth (id_user,login,password) values (1,'admin','53CB8E39EF9E476251024464D3EBC482A584756C2F14B87839E9A967666FEDCC854116E4EA12F4796FD9B7CA48E82EDFFC8F42E45C1792BD9E868E0CF9EFF02E'),(2,'remeral','53CB8E39EF9E476251024464D3EBC482A584756C2F14B87839E9A967666FEDCC854116E4EA12F4796FD9B7CA48E82EDFFC8F42E45C1792BD9E868E0CF9EFF02E');
insert into Users values (1,1,'admin','admin','admin','admin','admin','D:\git\FP\FlowerPot\picusers\userdefault.png'),(2,0,'Елизавета','Артём','Владимировна','nelope@mail.ru','+375291477513','D:\git\FP\FlowerPot\picusers\13.jpg');


--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

create table Catagory
(
id_flower_type int identity(1,1) primary key,
type_of_flower nvarchar(20)
);
insert into Catagory (type_of_flower) values ('Комнатные'),('Сухоцветы'),('Папоротники'),('Суккуленты'),('Кактусы'),('Пальмовые'),('Букетные');

--drop create table Color
create table Color
(
id_color_type int identity(1,1) primary key,
type_of_color nvarchar(20)
);
insert into Color (type_of_color) values ('Красный'),('Оранжевый'),('Жёлтый'),('Голубой'),('Синий'),('Фиолетовый'),('Розовый');

--drop table Products
create table Products
(
	id_product int primary key,
	name_product nvarchar(20) unique,
	fullname_product nvarchar(80) unique,
	discription_product nvarchar(200),
	price_product money,
	img_path nvarchar(200),
	amount int,
	model_path nvarchar(200),
	id_flower_type int foreign key references Catagory(id_flower_type),
	id_color_type int foreign key references Color(id_color_type),
);

--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

create table Cart
(
	id_cart int primary key,
	id_user int foreign key references UserAuth(id_user),
	id_product int foreign key references Products(id_product),
	total_amount int,
	total_price money,
);


create table СonfirmOrder
(
	id_conforder int primary key,
	id_user int foreign key references UserAuth(id_user),
	id_product int foreign key references Products(id_product),
	total_amount int,
	total_price money,
);

--------------------------------------------------------------------------------------------------------------------------
--------------------------------------------------------------------------------------------------------------------------

create table OrderStatus
(
	id_order_status int primary key,
	type_of_status nvarchar(20) not null
);
insert into OrderStatus (id_order_status, type_of_status) values (1,'Получено'),(2,'Формируется'),(3,'Обрабатывается');

create table Orders
(
	id_order int primary key,
	id_conforder int foreign key references СonfirmOrder(id_conforder),
	now_date date default CONVERT (date, SYSDATETIME()) not null,
	id_order_status int not null foreign key references OrderStatus(id_order_status)
);