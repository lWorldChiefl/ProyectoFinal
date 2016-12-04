Create database Proyecto_Veroco
Use Proyecto_Veroco


	/*Creamos la Tabla Usuarios*/
Create Table Usuarios
(
	userId int primary key identity,
	userName varchar(80),
	userEmail varchar(120),
	userPassword varchar(16),
	userType int
);

	/*Creamos la Tabla TiposUsuarios*/

Create Table Tipo_Usuarios
(
	userTypeId int primary key identity,
	userTypeDescription varchar(100)
);