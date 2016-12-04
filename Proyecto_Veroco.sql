Create database Proyecto_Veroco
Use Proyecto_Veroco

							/*LOGIN*/

	/*Creamos la Tabla TiposUsuarios*/
Create Table Tipo_Usuarios
(
	userTypeId int primary key identity,
	userTypeDescription varchar(100)
);
GO


	/*Creamos la Tabla Usuarios*/
Create Table Usuarios
(
	userId int primary key identity,
	userName varchar(80),
	userEmail varchar(120),
	userPassword varchar(16),
	userTypeId int,
	foreign key (userTypeId) references Tipo_Usuarios(userTypeId)
);
GO
	

						/*PRODUCTOS*/

	/*Creamos la tabla Categorias*/
Create Table Categorias
(
	categoryId int primary key identity,
	categoryName varchar(60),
	categoryDescription varchar(180)
);

	/*Creamos la tabla Productos*/
Create Table Productos
(
	productId int primary key identity,
	productName varchar(60),
	productPrice int,
	productStock int,
	categoryId int,
	foreign key (categoryId) references Categorias(categoryId)
);

	/*Creamos la tabla Detalles*/
Create Table Detalles
(
	detailsId int primary key identity,
	productId int,
	detailsQuantity int,
	detailsPrice int
	foreign key (productId) references Productos(productId)
);

	/*Creamos la tabla Facturas*/
Create Table Facturas
(
	invoiceId int primary key identity,
	invoiceDate date,
	detailsId int,
	userId int,
	foreign key (userId) references Usuarios(userId),
	foreign key (detailsId) references Detalles(detailsId)
);