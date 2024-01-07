-- ##################################################################################
-- #																				#
-- # BBDD created by Santiago Miguez Cea 											#
-- # Repository GitHub: https://github.com/santiagoieshna/api-rest-libreria-.net 	#
-- #																				#
-- ##################################################################################

-- Data Base
DROP DATABASE IF EXISTS LibreriaNET;
CREATE DATABASE LibreriaNET;
use LibreriaNET;

-- ##################################################################################
-- ##############################  TEMAS  ###########################################
-- ##################################################################################
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

-- ##################################################################################
-- ############################ AUTOR ###############################################
-- ##################################################################################
DROP TABLE IF EXISTS Autores;

CREATE TABLE Autores(
	id int(9) primary key auto_increment,
	nombre varchar(50) NOT NULL
);

-- Añadir restrcicion de nombre unico (Esto se puede hacer al crear la tabla)
ALTER TABLE Autores
ADD CONSTRAINT unique_nombre UNIQUE (nombre);

-- GET
DELIMITER $$
CREATE OR REPLACE PROCEDURE getAutores()
	BEGIN
		SELECT id, nombre FROM Autores;
	END$$
DELIMITER ;

-- POST 
DELIMITER $$
CREATE OR REPLACE PROCEDURE updateAutor(IN id_autor int(9), 
									IN nombreActualizado varchar(50))
	BEGIN
		UPDATE Autores
		SET nombre = nombreActualizado
		WHERE id = id_autor;
	END$$
DELIMITER ;

-- PUT
DELIMITER $$
CREATE OR REPLACE PROCEDURE putAutor( IN nombre_autor varchar(50))
	BEGIN
		INSERT into Autores(nombre) Values(nombre_autor);
	END$$
DELIMITER ;

-- DELETE
DELIMITER $$
CREATE OR REPLACE PROCEDURE deleteAutor(IN id_autor int(9))
	BEGIN
		DELETE from Autores where	id = id_autor;
	END$$
DELIMITER ;

-- ##################################################################################
-- ############################# EDICION ############################################
-- ##################################################################################
-- TABLA
DROP TABLE IF EXISTS Ediciones;
CREATE TABLE Ediciones(
	id int(9) primary key auto_increment,
	tipo varchar(25) NOT NULL
);

-- Procedimientos
-- GET
DELIMITER $$
CREATE OR REPLACE PROCEDURE getEdiciones()
	BEGIN
		SELECT id, tipo 
		FROM ediciones;
	END$$
DELIMITER ;

-- POST
DELIMITER $$
CREATE OR REPLACE PROCEDURE updateEdicion(IN id_edicion int(9),
									IN tipo_edicion varchar(25))
	BEGIN
		UPDATE ediciones
		SET tipo = tipo_edicion
		WHERE id = id_edicion;
	END$$
DELIMITER ;

-- PUT
DELIMITER $$
CREATE OR REPLACE PROCEDURE putEdicion(IN tipo_edicion varchar(25))
	BEGIN
		INSERT into ediciones(tipo) VALUES(tipo_edicion);
	END$$
DELIMITER ;

-- DELETE
DELIMITER $$
CREATE OR REPLACE PROCEDURE deleteEdicion(IN id_edicion int(9))
	BEGIN
		DELETE from ediciones Where id = id_edicion;
	END$$
DELIMITER ;

-- ##################################################################################
-- ############################# FORMATO ############################################
-- ##################################################################################

-- TABLA ----------------------------------
DROP TABLE IF EXISTS Formatos;
CREATE TABLE Formatos(
	id int(9) primary key auto_increment,
	tipo varchar(25) NOT NULL
);

-- RPOCEDURES -----------
-- GET
DELIMITER $$
CREATE OR REPLACE PROCEDURE getFormatos()
	BEGIN
		SELECT id, tipo 
		FROM formatos;
	END$$
DELIMITER ;

-- POST
DELIMITER $$
CREATE OR REPLACE PROCEDURE updateFormato(IN id_formato int(9),
									IN tipo_formato varchar(25))
	BEGIN
		UPDATE formatos
		SET tipo = tipo_formato
		WHERE id = id_formato;
	END$$
DELIMITER ;

-- PUT
DELIMITER $$
CREATE OR REPLACE PROCEDURE putFormato(IN tipo_formato varchar(25))
	BEGIN
		INSERT into formatos(tipo) VALUES(tipo_formato);
	END$$
DELIMITER ;

-- DELETE
DELIMITER $$
CREATE OR REPLACE PROCEDURE deleteFormato(IN id_formato int(9))
	BEGIN
		DELETE from formatos Where id = id_formato;
	END$$
DELIMITER ;


-- Valores por defecto

-- ----------- VALORES POR DEFECTO ------------------------------------
-- TEMAS
call putTema("Fantasia");
call putTema("Terror");
call putTema("Romance");
call putTema("Aventura");

-- AUTORES
call putAutor('Beltran Labios Bonitos');
INSERT INTO Autores(nombre) VALUES('Caballero Chavero')
				, ('Rebecca Yarros'),('J. K. Rowling'),
				 ('Cassandra Clare');


-- FORMATO
call putFormato('Tapa Blanda');
call putFormato('Tapa Dura');
call putFormato('Digital');
call putFormato('De bolsillo');

-- EDICION
call putEdicion('Especial');
call putEdicion('Aniversario');
call putEdicion('Pirata');


-- ###### CREAR USUARIO ###########
-- CREATE USER 'portalo'@'%' -> PAra conectarse desde cualqueir host
CREATE USER 'portalo'@'localhost' IDENTIFIED BY '12345';
GRANT ALL PRIVILEGES ON LibreriaNET.* TO 'portalo'@'localhost';
-- Refrescar privilegios
FLUSH PRIVILEGES; 

