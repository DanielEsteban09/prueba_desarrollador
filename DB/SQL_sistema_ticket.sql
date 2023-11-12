create database sistema_ticket;

use sistema_ticket;

go

create table Usuario (
	Id int primary key identity(1,1),
	Nombre varchar(100),
	Cedula varchar(100)
);

go

create table Tickets (
	Id int primary key identity(1,1),
	Descripcion varchar(500),
	Numero int,
	Prioridad varchar(100)
);

go

create table EstadoTicket (
	Id int primary key,
	Nombre varchar(100)
);

go

--Insercion de datos de estdo
insert into EstadoTicket(Id, Nombre) values (1, 'En Proceso');
insert into EstadoTicket(Id, Nombre) values (2, 'Suspendido');
insert into EstadoTicket(Id, Nombre) values (3, 'Terminado');
insert into EstadoTicket(Id, Nombre) values (4, 'Vencida');

go

create table AsignadoUsuario (
	Id int primary key identity(1,1),
	Id_usuario int,
	Id_ticket int,
	Fecha datetime,
	Id_Estado int,
	constraint FK_Usuario_Asignado foreign key(Id_usuario) references Usuario (Id)
	on update cascade
	on delete cascade,
	constraint FK_Ticket_Asignado foreign key(Id_ticket) references Tickets (Id)
	on update cascade
	on delete cascade,
	constraint FK_Estado_Asignado foreign key(Id_Estado) references EstadoTicket (Id)
	on update cascade
	on delete cascade
);