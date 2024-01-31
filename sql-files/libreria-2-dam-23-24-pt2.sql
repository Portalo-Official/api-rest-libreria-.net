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
			A2.cantidad as Stock
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
CREATE OR REPLACE PROCEDURE getLibrosByISBN(IN p_isbn varchar(13))
	BEGIN
		SELECT 
			L.id        as Id,
			L.isbn      as ISBN,
			L.titulo    as Titulo,
			A.nombre    as Autor,
			T.tema      as Tipo,
			E.tipo      as Edicion,
			F.tipo      as Formato,
			L.Precio    as Precio,
			A2.cantidad as Stock
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
										IN p_stock   int(9)
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
		INSERT INTO Libros(titulo, isbn, precio, id_autor, id_tema, id_edicion, id_formato)
		VALUES(p_titulo, p_isbn, p_precio, v_id_autor, v_id_tema, v_id_edicion, v_id_formato);
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
		Declare v_id_edicion INT;
		Declare v_id_tema INT;
		Declare v_id_formato INT;
		-- Buscar IDs , p_autor -> p de parametro
		SELECT id INTO v_id_autor   FROM autores   WHERE nombre = p_autor   limit 1;
		SELECT id INTO v_id_edicion FROM ediciones WHERE tipo   = p_edicion limit 1;
		SELECT id INTO v_id_tema    FROM temas     WHERE tema   = p_tema    limit 1;
		SELECT id INTO v_id_formato FROM formatos  WHERE formato= p_formato limit 1;
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
)

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


-- Poblar BBDD
-- Valores por defecto

-- ----------- VALORES POR DEFECTO ------------------------------------
-- TEMAS
call createTema("Fantasia");
call createTema("Terror");
call createTema("Romance");
call createTema("Aventura");
CALL createTema('Fantasia');
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
CALL createLibro('9780007117116', 'Cien Años de Soledad', 24.99, 'Gabriel Garcia Marquez', 'Especial', 'Fantasia', 'Tapa Dura', 100);
CALL createLibro('9780307352149', '1Q84', 21.99, 'Haruki Murakami', 'Aniversario', 'Ciencia Ficcion', 'Tapa Blanda', 80);
CALL createLibro('9788498389327', 'Harry Potter y la Piedra Filosofal', 18.99, 'J.K. Rowling', 'Especial', 'Misterio', 'Digital', 120);
CALL createLibro('9780553103540', 'Juego de Tronos', 29.99, 'George R.R. Martin', 'Aniversario', 'Historico', 'Tapa Dura', 90);
CALL createLibro('9788408190013', 'Eva Luna', 27.99, 'Isabel Allende', 'Especial', 'Fantasia', 'Tapa Blanda', 110);
CALL createLibro('9780061122415', 'El Alquimista', 25.99, 'Paulo Coelho', 'Aniversario', 'Ciencia Ficcion', 'Tapa Dura', 70);
CALL createLibro('9780062693662', 'Asesinato en el Orient Express', 19.99, 'Agatha Christie', 'Especial', 'Misterio', 'Tapa Blanda', 95);
CALL createLibro('9780307743657', 'It', 26.99, 'Stephen King', 'Aniversario', 'Historico', 'De bolsillo', 85);
CALL createLibro('9780141439563', 'Orgullo y Prejuicio', 23.99, 'Jane Austen', 'Especial', 'Fantasia', 'Digital', 75);
CALL createLibro('9780140449976', 'Los Miserables', 15.99, 'Victor Hugo', 'Aniversario', 'Ciencia Ficcion', 'Tapa Dura', 105);
CALL createLibro('9780307474278', 'Crónica del pájaro que da cuerda al mundo', 20.99, 'Haruki Murakami', 'Especial', 'Misterio', 'Tapa Blanda', 65);
CALL createLibro('9788490628588', 'Harry Potter y las Reliquias de la Muerte', 22.99, 'J.K. Rowling', 'Aniversario', 'Fantasía', 'De bolsillo', 88);
CALL createLibro('9788497593464', 'El nombre del viento', 24.99, 'Jane Austen', 'Especial', 'Historico', 'Tapa Dura', 92);
CALL createLibro('9780061122415', 'El Silmarillion', 28.99, 'J.K. Rowling', 'Aniversario', 'Ciencia Ficcion', 'Tapa Blanda', 78);
CALL createLibro('9780307474292', 'Cazadores de sombras: Ciudad de Hueso', 21.99, 'Cassandra Clare', 'Especial', 'Fantasía', 'Tapa Dura', 102);
CALL createLibro('9710007117111', 'inventado', 99.99, 'Gabriel Garcia Marquez', 'Especial', 'Fantasia', 'Tapa Dura', 10);
