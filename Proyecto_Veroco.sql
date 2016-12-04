Create database Proyecto_Veroco
Use Proyecto_Veroco


	/*Creamos la Tabla Usuarios*/
Create Table Usuarios
(
	userId int primary key identity,
	userEmail varchar(120),
	userPassword varchar(16),
	userType int
);