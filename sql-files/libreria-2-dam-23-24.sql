-- ###############################################################
-- #
-- # BBDD created by Santiago Miguez Cea
-- # Repository GitHub: 
-- #
-- ###############################################################
DROP DATABASE IF EXISTS LibreriaNET;
CREATE DATABASE LibreriaNET;
use LibreriaNET;

-- TEMAS
-- Crear Tabla Temas
CREATE TABLE Temas(
 Id int(9) primary key auto_increment,
 Tema varchar(50) NOT NULL UNIQUE 
);



-- Crear Procedimientos de almacenamiento

-- GET
DELIMITER $$
CREATE OR REPLACE PROCEDURE getTemas()
BEGIN
	Select Tema FROM Temas;
END$$
DELIMITER ;

-- PUT
DELIMITER $$
CREATE OR REPLACE PROCEDURE putTema( IN temaNuevo Varchar(50))
BEGIN
	INSERT into Temas(Tema) Values(temaNuevo);
END$$
DELIMITER ;

-- DELETE
DELIMITER $$
CREATE OR REPLACE PROCEDURE deleteTema(IN temaBorrar int(9))
BEGIN
	DELETE from Temas WHERE id=temaBorrar;
END$$
DELIMITER ;

-- POST
DELIMITER $$
CREATE OR REPLACE PROCEDURE updateTema(IN id_temaViejo int(9),
										IN temaNuevo varchar(9))
BEGIN 
	UPDATE Temas
	SET tema = temaNuevo
	WHERE id=id_temaViejo;
END$$
DELIMITER ;


-- ############################ AUTOR ###################################
-- TABLA Autores
DROP TABLE IF EXISTS Autor;

CREATE TABLE Autor(
	id int(9) primary key auto_increment,
	nombre varchar(50)
)

-- GET
DELIMITER $$
CREATE OR REPLACE PROCEDURE getAutor()
	BEGIN
		SELECT id, nombre FROM Autor;
	END$$
DELIMITER ;

-- POST 
DELIMITER $$
CREATE OR REPLACE PROCEDURE updateAutor(IN id_autor int(9), 
									IN nombreActualizado varchar(50))
BEGIN
	UPDATE Autor
	SET nombre = nombreActualizado
	WHERE id = id_autor;
END$$
DELIMITER ;

-- PUT
DELIMITER $$
CREATE OR REPLACE PROCEDURE putAutor( IN nombre_autor varchar(50))
BEGIN
	INSERT into Autor(nombnre) Values(nombre_autor);
END$$
DELIMITER ;

-- DELETE
DELIMITER $$
CREATE OR REPLACE PROCEDURE deleteAutor(IN id_autor int(9))
BEGIN
	DELETE from Temas where	id = id_autor;
END$$
DELIMITER ;

-- ############################# EDICION #################################

-- TABLA
DROP IF EXISTS 


-- Valores por defecto

-- ----------- VALORES POR DEFECTO ------------------------------------
-- TEMAS
call putTema("Fantasia");
call putTema("Terror");
call putTema("Romance");
call putTema("Aventura");

-- AUTORES
INSERT INTO Autor(nombre) VALUES('Caballero Chavero')
		, ('Rebecca Yarros'),('J. K. Rowling'), ('Cassandra Clare');

-- FORMATO


-- EDICION





