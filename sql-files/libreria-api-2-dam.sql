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
		Select Id, Tema FROM Temas;
	END$$
DELIMITER ;

-- POST
DELIMITER $$
CREATE OR REPLACE PROCEDURE  createTema( IN temaNuevo Varchar(50))
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

-- PUT
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

-- PUT
DELIMITER $$
CREATE OR REPLACE PROCEDURE updateAutor(IN id_autor int(9), 
									IN nombreActualizado varchar(50))
	BEGIN
		UPDATE Autores
		SET nombre = nombreActualizado
		WHERE id = id_autor;
	END$$
DELIMITER ;

-- POST
DELIMITER $$
CREATE OR REPLACE PROCEDURE createAutor( IN nombre_autor varchar(50))
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

-- PUT
DELIMITER $$
CREATE OR REPLACE PROCEDURE updateEdicion(IN id_edicion int(9),
									IN tipo_edicion varchar(25))
	BEGIN
		UPDATE ediciones
		SET tipo = tipo_edicion
		WHERE id = id_edicion;
	END$$
DELIMITER ;

-- POST
DELIMITER $$
CREATE OR REPLACE PROCEDURE createEdicion(IN tipo_edicion varchar(25))
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

-- PUT
DELIMITER $$
CREATE OR REPLACE PROCEDURE updateFormato(IN id_formato int(9),
									IN tipo_formato varchar(25))
	BEGIN
		UPDATE formatos
		SET tipo = tipo_formato
		WHERE id = id_formato;
	END$$
DELIMITER ;

-- POST
DELIMITER $$
CREATE OR REPLACE PROCEDURE createFormato(IN tipo_formato varchar(25))
	BEGIN
		INSERT into formatos(tipo) VALUES(tipo_formato);
	END$$
DELIMITER ;

-- DELETE
DELIMITER $$
CREATE OR REPLACE PROCEDURE deleteFormato(IN id_formato int(9))
	BEGIN
		DELETE from formatos Where id= id_formato;
	END$$
DELIMITER ;




-- ########################### CREAR USUARIO ####################
-- CREATE USER 'portalo'@'%' -> PAra conectarse desde cualqueir host

CREATE USER 'portalo'@'localhost' IDENTIFIED BY '12345';
GRANT ALL PRIVILEGES ON LibreriaNET.* TO 'portalo'@'localhost';
GRANT ALL PRIVILEGES ON LibreriaNET.* TO 'portalo'@'%';
--GRANT ALL PRIVILEGES ON *.* TO 'portalo'@'192.168.1.%';
--GRANT ALL PRIVILEGES ON *.* TO 'portalo'@'localhost';
-- Refrescar privilegios
FLUSH PRIVILEGES; 

-- Dara error el conectarnos por el tema host
/*
GRANT ALL PRIVILEGES ON *.* TO 'portalo'@'192.168.1.%' 
IDENTIFIED BY '12345' WITH GRANT OPTION;
FLUSH PRIVILEGES;
*/
use librerianet;

-- ##############################  PROCEDURES DE BUSQUEDA  ###########################################

-- ********************** TEMAS **********************************

-- FindByID
DELIMITER $$
CREATE OR REPLACE PROCEDURE getTemaById(IN id_tema int(9))
	BEGIN
		Select Id, Tema FROM Temas WHERE id=id_tema;
	END$$
DELIMITER ;

-- ********************** EDICIONES **********************************

-- FindByID
DELIMITER $$
CREATE OR REPLACE PROCEDURE getEdicionById(IN id_edicion int(9))
	BEGIN
		Select Id, Tema FROM ediciones WHERE id=id_edicion;
	END$$
DELIMITER ;

-- ********************** AUTORES **********************************

-- FindByID
DELIMITER $$
CREATE OR REPLACE PROCEDURE getAutoresById(IN id_autor int(9))
	BEGIN
		Select Id, Tema FROM Autores WHERE id=id_autor;
	END$$
DELIMITER ;

-- ********************** FORMATOS **********************************

-- FindByID
DELIMITER $$
CREATE OR REPLACE PROCEDURE getformatoById(IN id_formato int(9))
	BEGIN
		Select Id, Tema FROM formatos WHERE id=id_formato;
	END$$
DELIMITER ;

-- ####################################################################################
-- ############################# LIBRO ################################################
-- ####################################################################################

DROP TABLE IF EXISTS libros;

CREATE TABLE Libros(
	id int(9) PRIMARY KEY AUTO_INCREMENT,
	titulo varchar(250) not null,
	isbn varchar(13) not null UNIQUE,
	precio decimal(7,2) not null,
	id_autor int(9) not null,
	id_tema int(9) not null,
	id_edicion int(9) not null,
	id_formato int(9) not null,
	URL VARCHAR(1000) ,
	FOREIGN KEY (id_autor) REFERENCES autores(id) ON DELETE RESTRICT,
	FOREIGN KEY (id_tema) REFERENCES temas(id) ON DELETE RESTRICT,
	FOREIGN KEY (id_edicion) REFERENCES ediciones(id) ON DELETE RESTRICT,
	FOREIGN KEY (id_formato) REFERENCES formatos(id) ON DELETE RESTRICT
);

DROP TABLE IF EXISTS almacen;

CREATE TABLE almacen(
	id int(9) PRIMARY KEY AUTO_INCREMENT,
	cantidad int(9),
	libro varchar(13) not null UNIQUE,
	FOREIGN KEY (libro) REFERENCES libros(isbn) ON DELETE CASCADE
);

-- ********* PROCEDURES **************************************

-- Get Todos los Libros
DELIMITER $$
CREATE OR REPLACE PROCEDURE getLibros()
	BEGIN
		SELECT 
			L.id        as Id,
			L.isbn      as ISBN,
			L.titulo    as Titulo,
			A.nombre    as Autor,
			T.tema      as Tema,
			E.tipo      as Edicion,
			F.tipo      as Formato,
			L.Precio    as Precio,
			A2.cantidad as Stock,
			L.URL      	as URL
		FROM LIBROS L
		INNER JOIN temas     T  ON L.id_tema    = T.id
		INNER JOIN autores   A  ON L.id_autor   = A.id
		INNER JOIN ediciones E  ON L.id_edicion = E.id
		INNER JOIN formatos  F  ON L.id_formato = F.id
		INNER JOIN almacen   A2 ON L.isbn       = A2.libro;
	END$$
DELIMITER ;

-- GET libroBYID
DELIMITER $$
CREATE OR REPLACE PROCEDURE getLibroByISBN(IN p_isbn varchar(13))
	BEGIN
		SELECT 
			L.id        as Id,
			L.isbn      as ISBN,
			L.titulo    as Titulo,
			A.nombre    as Autor,
			T.tema      as Tema,
			E.tipo      as Edicion,
			F.tipo      as Formato,
			L.Precio    as Precio,
			A2.cantidad as Stock,
			L.URL       as URL
		FROM LIBROS L
		INNER JOIN temas     T  ON L.id_tema    = T.id
		INNER JOIN autores   A  ON L.id_autor   = A.id
		INNER JOIN ediciones E  ON L.id_edicion = E.id
		INNER JOIN formatos  F  ON L.id_formato = F.id
		INNER JOIN almacen   A2 ON L.isbn       = A2.libro
		WHERE L.isbn= p_isbn;
	END$$
DELIMITER ;

-- POST Crear Libro
DELIMITER $$
CREATE OR REPLACE PROCEDURE createLibro(IN p_isbn    VARCHAR(13),
										IN p_titulo  VARCHAR(250),
										IN p_precio  decimal(5,2),
										IN p_autor   varchar(50),
										IN p_edicion varchar(25),
										IN p_tema    varchar(50),
										IN p_formato varchar(25),
										IN p_stock   int(9),
										IN p_url     VARCHAR(1000)
										)
	BEGIN
		Declare v_id_autor INT;
		Declare v_id_edicion INT;
		Declare v_id_tema INT;
		Declare v_id_formato INT;
		-- Buscar IDs , p_autor -> p de parametro
		SELECT id INTO v_id_autor   FROM autores   WHERE nombre = p_autor   limit 1;
		SELECT id INTO v_id_edicion FROM ediciones WHERE tipo   = p_edicion limit 1;
		SELECT id INTO v_id_tema    FROM temas     WHERE tema   = p_tema    limit 1;
		SELECT id INTO v_id_formato FROM formatos  WHERE tipo   = p_formato limit 1;
		-- Crear libro
		INSERT INTO Libros(titulo, isbn, precio, id_autor, id_tema, id_edicion, id_formato, URL)
		VALUES(p_titulo, p_isbn, p_precio, v_id_autor, v_id_tema, v_id_edicion, v_id_formato, p_URL);
		-- Crear registro almacen
		INSERT INTO almacen(libro,cantidad) VALUES (p_isbn, p_stock);
	END$$
DELIMITER ;

-- PUT 
DELIMITER $$
CREATE OR REPLACE PROCEDURE updateLibro(IN p_isbn    VARCHAR(13),
										IN p_titulo  VARCHAR(250),
										IN p_precio  decimal(5,2),
										IN p_autor   varchar(50),
										IN p_edicion varchar(25),
										IN p_tema    varchar(50),
										IN p_formato varchar(25)
										)
	BEGIN
		Declare v_id_autor INT;
		-- Buscar IDs , p_autor -> p de parametro
		Declare v_id_edicion INT;
		Declare v_id_tema INT;
		Declare v_id_formato INT;
		SELECT id INTO v_id_autor   FROM autores   WHERE nombre = p_autor   limit 1;
		SELECT id INTO v_id_edicion FROM ediciones WHERE tipo   = p_edicion limit 1;
		SELECT id INTO v_id_tema    FROM temas     WHERE tema   = p_tema    limit 1;
		SELECT id INTO v_id_formato FROM formatos  WHERE tipo= p_formato limit 1;
		-- Actualizar
		UPDATE Libros
   		SET
        titulo = p_titulo,
        precio = p_precio,
        id_autor = v_id_autor,
        id_tema = v_id_tema,
        id_edicion = v_id_edicion,
        id_formato = v_id_formato
    	WHERE isbn = p_isbn;
	END$$
DELIMITER ;

-- DELETE
DELIMITER $$
CREATE OR REPLACE PROCEDURE deleteLibro(IN p_isbn VARCHAR(13))
	BEGIN
		Delete from Libros WHERE isbn=p_isbn;
	END$$
DELIMITER ;

-- ************* PROCEDURE ALMACEN ***********
DELIMITER $$
CREATE OR REPLACE PROCEDURE compraVenta(IN cantidadLibro int(9),
										IN isbn VARCHAR(13))
	BEGIN 
		DECLARE cantidadActual INT;
		UPDATE almacen SET cantidad=cantidadLibro WHERE libro=isbn;
	END $$ 
DELIMITER ;

/*
CREATE TABLE USER(

	id int(9) PRIMARY KEY AUTO_INCREMENT,
	name varchar(25),
	email varchar(80),
	password varchar(35),
);

CREATE TABLE Compras(

	id bigint(20) PRIMARY KEY AUTO_INCREMENT,
	libro varchar(13),
	fechaCompra DATE,
	Precio varchar(13),
);

CREATE TABLE USER(

	id bigint(20) PRIMARY KEY AUTO_INCREMENT,
	isbn varchar(25),
	fechaVenta DATE,
	precio decimal(6,2),
); */

/*
DELIMITER $$
CREATE OR REPLACE TRIGGER before_update_almacen
	BEFORE UPDATE ON ALMACEN
	IF (old.cantidad > new.cantidad) THEN
		-- Venta
		Insert 
	ELSE
		-- Compra
		Insert
DELIMITER $$
*/


-- Poblar BBDD
-- Valores por defecto

-- ----------- VALORES POR DEFECTO ------------------------------------
-- TEMAS
call createTema("Fantasia");
call createTema("Terror");
call createTema("Romance");
call createTema("Aventura");
CALL createTema('Ciencia Ficcion');
CALL createTema('Misterio');
CALL createTema('Historico');


-- FORMATO
call createFormato('Tapa Blanda');
call createFormato('Tapa Dura');
call createFormato('Digital');
call createFormato('De bolsillo');


-- EDICION
call createEdicion('Especial');
call createEdicion('Aniversario');
call createEdicion('Pirata');
CALL createEdicion('Especial');
CALL createEdicion('Aniversario');
CALL createEdicion('Pirata');
CALL createEdicion('Coleccionista');

-- Generar autores
CALL createAutor('Gabriel Garcia Marquez');
CALL createAutor('Haruki Murakami');
CALL createAutor('J.K. Rowling');
CALL createAutor('George R.R. Martin');
CALL createAutor('Isabel Allende');
CALL createAutor('Paulo Coelho');
CALL createAutor('Agatha Christie');
CALL createAutor('Stephen King');
CALL createAutor('Jane Austen');
CALL createAutor('Victor Hugo');
call createAutor('Beltran Labios Bonitos');
INSERT INTO Autores(nombre) VALUES('Caballero Chavero')
				, ('Rebecca Yarros'),('J. K. Rowling'),
				 ('Cassandra Clare');



-- Generar libros
CALL createLibro('9780007117116', 'Cien Años de Soledad', 24.99, 'Gabriel Garcia Marquez', 'Especial', 'Fantasia', 'Tapa Dura', 100, 'https://i.ibb.co/s9GR95M/images.jpg');
CALL createLibro('9780307352149', '1Q84', 21.99, 'Haruki Murakami', 'Aniversario', 'Ciencia Ficcion', 'Tapa Blanda', 80, 'https://i.ibb.co/tZjjw69/1q84-libros-1-y-2-9788483836262.webp');
CALL createLibro('9788498389327', 'Harry Potter y la Piedra Filosofal', 18.99, 'J.K. Rowling', 'Especial', 'Misterio', 'Digital', 120, 'https://i.ibb.co/3pmnqr1/51ux-Z1-Ek-T4-L.jpg');
CALL createLibro('9780553103540', 'Juego de Tronos', 29.99, 'George R.R. Martin', 'Aniversario', 'Historico', 'Tapa Dura', 90,'https://i.ibb.co/z4TcJFm/Juego-de-tronos.jpg');
CALL createLibro('9788408190013', 'Eva Luna', 27.99, 'Isabel Allende', 'Especial', 'Fantasia', 'Tapa Blanda', 110, 'https://i.ibb.co/jH1nKkB/visd-0000-JPG01-BVP.jpg');
CALL createLibro('9780061122415', 'El Alquimista', 25.99, 'Paulo Coelho', 'Aniversario', 'Ciencia Ficcion', 'Tapa Dura', 70, 'https://i.ibb.co/GCcSHKL/portada-el-alquimista-paulo-coelho-201612191218.webp');
CALL createLibro('9780062693662', 'Asesinato en el Orient Express', 19.99, 'Agatha Christie', 'Especial', 'Misterio', 'Tapa Blanda', 95, 'https://i.ibb.co/KX9LqLF/images.jpg');
CALL createLibro('9780307743657', 'It', 26.99, 'Stephen King', 'Aniversario', 'Historico', 'De bolsillo', 85, 'https://i.ibb.co/G2d7GLZ/It-1986-front-cover-first-edition-1.jpg');
CALL createLibro('9780141439563', 'Orgullo y Prejuicio', 23.99, 'Jane Austen', 'Especial', 'Fantasia', 'Digital', 75, 'https://i.ibb.co/48xBZb4/9788467070835.jpg');
CALL createLibro('9780140449976', 'Los Miserables', 15.99, 'Victor Hugo', 'Aniversario', 'Ciencia Ficcion', 'Tapa Dura', 105,'https://i.ibb.co/xG8r92K/img-54-0-big.jpg');
CALL createLibro('9780307474278', 'Crónica del pájaro que da cuerda al mundo', 20.99, 'Haruki Murakami', 'Especial', 'Misterio', 'Tapa Blanda', 65, 'https://i.ibb.co/Pmrv9jq/portada-cronica-del-pajaro-que-da-cuerda-al-mundo-haruki-murakami-201609281234.webp');
CALL createLibro('9788490628588', 'Harry Potter y las Reliquias de la Muerte', 22.99, 'J.K. Rowling', 'Aniversario', 'Fantasía', 'De bolsillo', 88, 'https://i.ibb.co/ZxSJTq9/514rkihbko-L.jpg');
CALL createLibro('9758410628688', 'Harry Potter y el prisionero de Azkaban', 29.79, 'J.K. Rowling', 'Especial', 'Fantasía', 'Tapa Dura', 40, 'https://i.ibb.co/ScjcV4x/51-g28v-UNDL.jpg');
CALL createLibro('9788011593164', 'El nombre del viento', 24.99, 'Jane Austen', 'Especial', 'Historico', 'Tapa Dura', 92, 'https://i.ibb.co/HNYpGxk/978840133720.jpg');
CALL createLibro('9780491272355', 'El Silmarillion', 28.99, 'J.K. Rowling', 'Aniversario', 'Ciencia Ficcion', 'Tapa Blanda', 78, 'https://i.ibb.co/m4J43Vk/81-Z7-OWa-Bs-ML-AC-UF1000-1000-QL80.jpg');
CALL createLibro('9780503474192', 'Cazadores de sombras: Ciudad de Hueso', 21.99, 'Cassandra Clare', 'Especial', 'Fantasía', 'Tapa Dura', 102, 'https://i.ibb.co/h1gZryV/51-I7qd-Op6-GL-AC-UF1000-1000-QL80.jpg');
CALL createLibro('9760007774242', 'Cazadores de sombras: Ciudad de las almas perdidas', 21.99, 'Cassandra Clare', 'Especial', 'Fantasía', 'Tapa Dura', 4, 'https://i.ibb.co/gDRwr2C/visd-0000-JPG019-T0.jpg');
CALL createLibro('9710807117511', 'Del Amor a otros Demonios', 49.99, 'Gabriel Garcia Marquez', 'Especial', 'Fantasia', 'De bolsillo', 10, 'https://i.ibb.co/ZSyZ6cy/978849759242.jpg');
CALL createLibro('9760807237519', 'Libro Prueba Prototipo', 129.99, 'Beltran Labios Bonitos', 'Especial', 'Fantasia', 'De bolsillo', 10, 'https://i.ibb.co/mz6F1Kp/167219770-127523866011194-8434310988880472619-n.jpg');

-- Editar Libro
CALL updateLibro('9710007117223', 'updatePrueba', 121.38, 'Beltran Labios Bonitos', 'Especial', 'Fantasia', 'Digital');

/*
URL para libros inventados
https://i.ibb.co/mz6F1Kp/167219770-127523866011194-8434310988880472619-n.jpg
*/