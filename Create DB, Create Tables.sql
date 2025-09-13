CREATE DATABASE IntelligentDevicesDB;

USE IntelligentDevicesDB;

CREATE TABLE Devices (
	 Id INT PRIMARY KEY IDENTITY(1,1),
	 Nombre VARCHAR(MAX) NOT NULL,
	 Descripcion NVARCHAR(MAX) NOT NULL,
	 Precio Decimal(12,2) NOT NULL,
	 Anio INT,
	 Marca VARCHAR(20) NOT NULL,
	 Imagen NVARCHAR(MAX)
 );

 INSERT INTO Devices (Nombre, Descripción, Precio, Anio, MarcaId, Imagen) VALUES
('Computador Portatil HP 15.6" Pulgadas', 'Intel Core i3 - RAM 8GB - Disco SSD 512GB - Azul', 1499000, 
2023, 1, 'https://www.alkosto.com/medias/198122843688-001-750Wx750H?context=bWFzdGVyfGltYWdlc3wxODM5NHxpbWFnZS93ZWJwfGFEYzBMMmc0TXk4eE5EazVPRFEwTmpnek16WTVOQzh4T1RneE1qSTRORE0yT0RoZk1EQXhYemMxTUZkNE56VXdTQXwxMzA3ZTczMmIxMzdhMTAxM2RjM2VkYTkzZGQ2MjIwZWIwNzBkZTdkNjViNDk0NGQ5OTVhMTJkMTg5ODBjMDFj'),
('Computador Portatil ASUS VivoBook 14" Pulgadas', 'AMD Ryzen 7 - RAM 16GB - Disco SSD 512 GB - Plateado', 2399000, 
2024, 2, 'https://www.ktronix.com/medias/4711387783979-001-1400Wx1400H?context=bWFzdGVyfGltYWdlc3w4NzQ0MnxpbWFnZS93ZWJwfGFEUXlMMmc0T0M4eE5UQTBOVGt4TmpFMk5ERXlOaTgwTnpFeE16ZzNOemd6T1RjNVh6QXdNVjh4TkRBd1YzZ3hOREF3U0F8MWVjYjI4MmUzOWVmM2NjZTU1OGI3ZjI1Yjk2NGZlMzAyM2QxNDhkOGQ1YTkyMTgwNDMzY2YwODZmZmU5OTkzOQ'),
('Computador Portatil ACER ASPIRE 15.6" Pulgadas', 'Intel Core i7 - RAM 16GB - Disco SSD 512GB - Plateado', 2489000, 
2024, 3, 'https://www.alkosto.com/medias/4711474142320-001-750Wx750H?context=bWFzdGVyfGltYWdlc3wyMjAyMHxpbWFnZS93ZWJwfGFEazJMMmd3WWk4eE5URTFOek01TXpjMU1qQTVOQzgwTnpFeE5EYzBNVFF5TXpJd1h6QXdNVjgzTlRCWGVEYzFNRWd8NzE3YzVjMDVlMWM1ODFmYWVmZWIzYTM1YTI1YjBiMDM5NWRhZWY3YWE5YmNiZjVhMTU5NzNkNTNjN2QwYzFkZQ'),
('MACBOOK Air de 13" Pulgadas', 'RAM 8GB Disco Estado Solido 256 GB - Gris', 2489000, 
2020, 4, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQjODQMt9ebp8WfHg5Ix4LwoL3GHIR9LXU5Ui1GizN_ms5iejJkKVDHgiNeOvPMQ4dD2T8&usqp=CAU'),
('Computador Portatil HP 15" Pulgadas', 'Intel Core Ultra 5 - RAM 16GB - Disco SSD 512GB - Plateado', 2489000, 
2024, 1, 'https://co-media.hptiendaenlinea.com/catalog/product/cache/74c1057f7991b4edb2bc7bdaa94de933/6/1/612B9LA-1_T1680540217.png'),
('Computador Portatil Gamer ASUS 16" Pulgadas', 'Intel Core 5 - RAM 16 GB - Disco SSD 512GB - Negro', 3499000, 
2023, 2, 'https://www.ktronix.com/medias/4711636030427-002-750Wx750H?context=bWFzdGVyfGltYWdlc3wyMzgyNnxpbWFnZS93ZWJwfGFHRm1MMmhoT0M4eE5URTFNVGswTXpNeE9UVTRNaTgwTnpFeE5qTTJNRE13TkRJM1h6QXdNbDgzTlRCWGVEYzFNRWd8NjBjYzQ4NzdhZGYxODM2N2U4NTBkNmQxOWNlYzE2NzI4OWRlNmZmYzlhMWZlODgzZDNmNmY2ODE5OGE2ZGRhMg'),
('Computador Portatil LENOVO IdeaPad 15.3" Pulgadas', 'IdeaPad Slim 3 - 15.3" Pulgadas Táctil - Intel Core i5 - RAM 16GB - Disco SSD 512GB - Azul', 2299000, 
2023, 5, 'https://www.alkosto.com/medias/196804839974-001-750Wx750H?context=bWFzdGVyfGltYWdlc3wxODYzNHxpbWFnZS93ZWJwfGFERmlMMmd3TlM4eE5UQTBOVFUzTkRjeU1UVTJOaTh4T1RZNE1EUTRNems1TnpSZk1EQXhYemMxTUZkNE56VXdTQXwyMjY2YmM4MjIyNjliYzFhMjEwM2U4ZWNiNDQ2Yzg0OTZhMWI4YjVkYmQ5YjFkN2UyOWQyODEyYWM2Y2RjZTAz'),
('Computador Portatil 2 en 1 HP Pavilion 14" Pulgadas', 'Intel Core i5 - RAM 8GB - Disco SSD 512GB - Azul', 2249000, 
2023, 6, 'https://www.alkosto.com/medias/198122843749-001-750Wx750H?context=bWFzdGVyfGltYWdlc3wxNjI5MHxpbWFnZS93ZWJwfGFETmtMMmhrTWk4eE5EazROekV6TXpNeU1USTBOaTh4T1RneE1qSTRORE0zTkRsZk1EQXhYemMxTUZkNE56VXdTQXw4NjJiZmNiNzNiYzA2ZjU4MWQ1YmQ3NThhYjEwODQ1ZDE3NGUzMzNlODkyOTFiNTBiMDNiMGMxOTNmNWVjMmU3'),
('Computador Portatil Gamer ACER NITRO 16" Pulgadas', 'Intel Core i5 - RAM 16GB - Disco SSD 512GB - Rojo - Negro', 3599000, 
2025, 7, 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ8pYfkkMFsHKKWFaUppknA5ilp-zBBZttwDA&s');

 CREATE TABLE Comentarios (
	Id INT PRIMARY KEY IDENTITY(1,1),
	DevicesId INT NOT NULL,
	Usuario VARCHAR(100) NOT NULL,
	Comentario NVARCHAR(MAX) NOT NULL,
	Fecha DATETIME DEFAULT GETDATE(),
	FOREIGN KEY (DeviceId) REFERENCES Devices(Id)
 );

 CREATE TABLE Usuarios (
	Id INT PRIMARY KEY IDENTITY(1,1),
	TipoDocumento VARCHAR(2) NOT NULL,
	NumeroDocumento INT NOT NULL,
	Nombres VARCHAR(100) NOT NULL,
	Email VARCHAR(100) UNIQUE NOT NULL,
	Clave VARCHAR(MAX) NOT NULL,
	CreatedDate DATETIME,
);

ALTER TABLE Devices DROP COLUMN Marca;

CREATE TABLE Marcas (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
);

INSERT INTO Marcas (Nombre) VALUES 
('HP'),
('ASUS'),
('ACER'),
('APPLE'),
('LENOVO'),
('HP PAVILION'),
('ACER NITRO');

SELECT * FROM Comentarios;

ALTER TABLE Devices
ADD MarcasId Int;

ALTER TABLE Devices
ADD CONSTRAINT FK_Devices_Marcas FOREIGN KEY (MarcasId) REFERENCES Marcas(Id);

SELECT * FROM  Usuarios

SELECT d.Nombre, d.Descripcion, d.Precio, d.Anio, m.Nombre AS Marca, d.Imagen
FROM Devices d
JOIN Marcas m ON d.MarcasId = m.Id;

SELECT * FROM Comentarios
SELECT * FROM  Usuarios
SELECT * FROM Devices
SELECT * FROM Marcas

