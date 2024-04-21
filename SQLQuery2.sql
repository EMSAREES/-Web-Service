CREATE PROCEDURE spLibros
@OP TINYINT,
@id INT,
@ISBN INT = 0,
@Titulo VARCHAR(150) = NULL,
@Autor VARCHAR(150) = NULL,
@Genero VARCHAR(150) = NULL

AS
BEGIN
	IF(@OP = 1)
	BEGIN 
		SELECT * FROM Libros WHERE id = @id
	END
	IF(@OP = 2)
	BEGIN
		IF(NOT EXISTS(SELECT * FROM Libros WHERE id = @id ))
		BEGIN
			INSERT INTO Libros(ISBN, Titulo, Autor,Genero) VALUES (@ISBN, @Titulo, @Autor, @Genero)
		END
		ELSE 
		BEGIN
			UPDATE Libros SET ISBN = @ISBN, Titulo = @Titulo, Autor = @Autor, Genero = @Genero WHERE id = @id 
		END
	END
	IF(@OP = 3)
	BEGIN
		DELETE FROM Libros WHERE id = @id
	END
END
