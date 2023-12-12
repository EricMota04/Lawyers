-- Crear la base de datos
CREATE DATABASE ExamenFinal;
GO

-- Usar la base de datos creada
USE ExamenFinal;
GO



CREATE TABLE EstadoCivil(
IdEstadoCivil int primary key,
Descripcion varchar(15)
)
go
CREATE TABLE TiposDeCasos(
Id int primary key,
TipoDeCaso varchar(25))
go

CREATE TABLE EstadosCasos (
    IdEstado INT PRIMARY KEY,
    Estado VARCHAR(50)
);
go
INSERT INTO EstadosCasos (IdEstado, Estado) VALUES
(1, 'Abierto'),
(2, 'En progreso'),
(3, 'Cerrado'),
(4, 'Pendiente'),
(5, 'Archivado'),
(6, 'Suspendido');



INSERT INTO TiposDeCasos (Id, TipoDeCaso) VALUES
(1, 'Derecho de Familia'),
(2, 'Derecho Penal'),
(3, 'Derecho Laboral'),
(4, 'Derecho Civil'),
(5, 'Derecho Comercial'),
(6, 'Derecho Inmobiliario'),
(7, 'Derecho de Sucesiones'),
(8, 'Derecho de Inmigraci�n');

insert into EstadoCivil values
(1, 'Soltero/a'), 
(2, 'Casado/a'), 
(3, 'Divorciado/a'), 
(4, 'Viudo/a'), 
(5, 'Separado/a'), 
(6, 'Union libre');

go
Create table Roles(
Id int primary key,
Rol varchar(25)
);

go

insert into Roles VALUES
(1, 'admin'),
(2, 'abogado');

go

CREATE TABLE USUARIOS(
Id int primary key identity(1,1), 
UserName varchar(50),
UserPassword varchar(50),
Rol int,
FOREIGN KEY (Rol) References Roles(Id)
)
go
-- Crear la tabla "Abogados"
CREATE TABLE Abogados (
    Id INT PRIMARY KEY identity (1,1),
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Correo VARCHAR(100),
    Telefono VARCHAR(20),
    Celular VARCHAR(20),
	IdUsuario int,
	FOREIGN KEY (IdUsuario) References USUARIOS(Id)
);
GO

-- Crear la tabla "Clientes"
CREATE TABLE Clientes (
    Id INT PRIMARY KEY identity(1,1),
    Cedula VARCHAR(20),
    Nombre VARCHAR(50),
    Apellido VARCHAR(50),
    Correo VARCHAR(100),
    Telefono VARCHAR(20),
    Celular VARCHAR(20),
    Direccion VARCHAR(100),
    EstadoCivil int
	FOREIGN KEY(EstadoCivil) REFERENCES EstadoCivil(IdEstadoCivil)
);
GO

-- Crear la tabla "Casos"
CREATE TABLE Casos (
    Id INT PRIMARY KEY identity(1,1),
    FechaCaso DATE,
    ClienteId INT,
    TipoCaso int,
    Latitud varchar(10),
    Longitud varchar(10),
    Descripcion VARCHAR(500),
    Estado int,
    AbogadoId INT,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
    FOREIGN KEY (AbogadoId) REFERENCES Abogados(Id),
	FOREIGN KEY(TipoCaso) REFERENCES TiposDeCasos(Id),
	FOREIGN KEY(Estado) References EstadosCasos(IdEstado)
);
GO

go

insert into Clientes (Cedula, Nombre, Apellido, Correo, Telefono, Celular, Direccion, EstadoCivil) Values('402-2323323-8', 'Eric', 'Mota', 'prueba@gmail.com','8292391234', '8091231234', 'En su casa', 1),
('001-1234567-8', 'Laura', 'G�mez', 'laura@example.com', '1234567890', '9876543210', 'Calle Principal 123', 2),
('002-2345678-9', 'Carlos', 'S�nchez', 'carlos@example.com', '2345678901', '8765432109', 'Avenida Central 456', 1),
('003-3456789-0', 'Mar�a', 'L�pez', 'maria@example.com', '3456789012', '7654321098', 'Carrera Norte 789', 3),
('004-4567890-1', 'Juan', 'Mart�nez', 'juan@example.com', '4567890123', '6543210987', 'Calle Sur 012', 4),
('005-5678901-2', 'Ana', 'Hern�ndez', 'ana@example.com', '5678901234', '5432109876', 'Avenida Este 345', 5),
('006-6789012-3', 'Pedro', 'Gonz�lez', 'pedro@example.com', '6789012345', '4321098765', 'Carrera Oeste 678', 6),
('007-7890123-4', 'Sof�a', 'Rodr�guez', 'sofia@example.com', '7890123456', '3210987654', 'Calle Principal 789', 2),
('008-8901234-5', 'Luis', 'P�rez', 'luis@example.com', '8901234567', '2109876543', 'Avenida Central 012', 1),
('009-9012345-6', 'Mariana', 'Torres', 'mariana@example.com', '9012345678', '1098765432', 'Carrera Norte 345', 3),
('010-0123456-7', 'Andr�s', 'Vargas', 'andres@example.com', '0123456789', '0987654321', 'Calle Sur 678', 4),
('011-1234567-8', 'Valentina', 'Mendoza', 'valentina@example.com', '1234567890', '9876543210', 'Avenida Este 901', 5),
('012-2345678-9', 'Gabriel', 'Silva', 'gabriel@example.com', '2345678901', '8765432109', 'Carrera Oeste 234', 6),
('013-3456789-0', 'Luc�a', 'Garc�a', 'lucia@example.com', '3456789012', '7654321098', 'Calle Principal 567', 2),
('014-4567890-1', 'Diego', 'Rojas', 'diego@example.com', '4567890123', '6543210987', 'Avenida Central 890', 1);

go

INSERT INTO USUARIOS (UserName, UserPassword, Rol) VALUES
('adamix', '123456', 1),
('EricMota', '123456', 1),
('Juanjo', 'perrogato', 2),
('Usuario1', 'contrase�a1', 2),
('Usuario2', 'contrase�a2', 2),
('Usuario3', 'contrase�a3', 2),
('Usuario4', 'contrase�a4', 2),
('Usuario5', 'contrase�a5', 2),
('Usuario6', 'contrase�a6', 2),
('Usuario7', 'contrase�a7', 2),
('Usuario8', 'contrase�a8', 2),
('Usuario9', 'contrase�a9', 2),
('Usuario10', 'contrase�a10', 2),
('Usuario11', 'contrase�a11', 2),
('Usuario12', 'contrase�a12', 2);

go

INSERT INTO Abogados (Nombre, Apellido, Correo, Telefono, Celular, IdUsuario)
VALUES
    ('Amadis', 'Suarez', 'amadis@example.com', '1234567890', '9876543210', 1),
    ('Eric', 'Mota', 'eric@example.com', '2345678901', '8765432109', 2),
    ('Carlos', 'L�pez', 'carlos@example.com', '3456789012', '7654321098', 3),
    ('Laura', 'Hern�ndez', 'laura@example.com', '4567890123', '6543210987', 4),
    ('Pedro', 'Mart�nez', 'pedro@example.com', '5678901234', '5432109876', 5),
    ('Sof�a', 'Rodr�guez', 'sofia@example.com', '6789012345', '4321098765', 6),
    ('Luis', 'P�rez', 'luis@example.com', '7890123456', '3210987654', 7),
    ('Ana', 'Torres', 'ana@example.com', '8901234567', '2109876543', 8),
    ('Diego', 'Vargas', 'diego@example.com', '9012345678', '1098765432', 9),
    ('Mariana', 'Mendoza', 'mariana@example.com', '0123456789', '0987654321', 10),
    ('Andr�s', 'Silva', 'andres@example.com', '1234567890', '9876543210', 11),
    ('Luc�a', 'Garc�a', 'lucia@example.com', '2345678901', '8765432109', 12),
    ('Gabriel', 'Rojas', 'gabriel@example.com', '3456789012', '7654321098', 13),
    ('Valentina', 'G�mez', 'valentina@example.com', '4567890123', '6543210987', 14),
    ('Daniel', 'S�nchez', 'daniel@example.com', '5678901234', '5432109876', 15);

go

INSERT INTO Casos (FechaCaso, ClienteId, TipoCaso, Latitud, Longitud, Descripcion, Estado, AbogadoId)
VALUES
    ('2023-01-01', 1, 1, '18.456789', '-69.123456', 'Luego de un divorcio, Mar�a demanda a su esposo para conseguir la custodia de sus hijos.', 1, 17),
    ('2023-02-02', 2, 2, '19.123456', '-70.234567', 'Juan es acusado de robo en un supermercado y requiere representaci�n legal para su defensa.', 2, 18),
    ('2023-03-03', 3, 3, '18.987654', '-71.345678', 'Carlos busca asesoramiento legal para la redacci�n de un contrato de arrendamiento.', 3, 19),
    ('2023-04-04', 4, 4, '19.876543', '-72.456789', 'Laura ha sufrido un accidente automovil�stico y necesita un abogado para presentar una demanda por lesiones personales.', 4, 20),
    ('2023-05-05', 5, 5, '18.765432', '-73.567890', 'Pedro est� enfrentando cargos por fraude financiero y necesita un abogado experimentado en delitos econ�micos.', 5, 21),
    ('2023-06-06', 6, 6, '19.654321', '-74.678901', 'Mar�a necesita ayuda legal para establecer un plan de sucesi�n y testamento.', 6, 22),
    ('2023-07-07', 7, 7, '18.543210', '-75.789012', 'Ana ha sido despedida injustamente y busca representaci�n legal para presentar una demanda por despido injustificado.', 1, 23),
    ('2023-08-08', 8, 8, '19.432109', '-76.890123', 'Roberto est� involucrado en una disputa de propiedad y necesita un abogado para resolver el conflicto.', 2, 24),
    ('2023-09-09', 9, 1, '18.321098', '-77.901234', 'Luego de un divorcio, Mar�a demanda a su esposo para conseguir la custodia de sus hijos.', 3, 25),
    ('2023-10-10', 10, 2, '19.210987', '-78.012345', 'Juan es acusado de robo en un supermercado y requiere representaci�n legal para su defensa.', 4, 26),
    ('2023-11-11', 11, 3, '18.109876', '-79.123456', 'Carlos busca asesoramiento legal para la redacci�n de un contrato de arrendamiento.', 5, 27),
    ('2023-12-12', 12, 4, '19.098765', '-80.234567', 'Laura ha sufrido un accidente automovil�stico y necesita un abogado para presentar una demanda por lesiones personales.', 6, 28),
    ('2023-01-13', 13, 5, '18.987654', '-81.345678', 'Pedro est� enfrentando cargos por fraude financiero y necesita un abogado experimentado en delitos econ�micos.', 1, 29),
    ('2023-02-14', 14, 6, '19.876543', '-82.456789', 'Mar�a necesita ayuda legal para establecer un plan de sucesi�n y testamento.', 2, 30),
    ('2023-03-15', 15, 7, '18.765432', '-83.567890', 'Ana ha sido despedida injustamente y busca representaci�n legal para presentar una demanda por despido injustificado.', 3, 31);


select * from USUARIOS

select * from Abogados

drop database ExamenFinal

Create database ExamenFinal1