CREATE DATABASE PracticaWEBAPI

USE PracticaWEBAPI

CREATE TABLE Producto(
ProductoId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
SKU VARCHAR(200) NOT NULL,
Fert VARCHAR(200) NOT NULL,
Modelo VARCHAR(200) NOT NULL,
Tipo SMALLINT NOT NULL,
Serie VARCHAR(200) NOT NULL,
Fecha DATE NOT NULL
)
