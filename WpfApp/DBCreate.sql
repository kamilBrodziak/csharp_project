USE master
GO
ALTER DATABASE BookCatalog SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
GO
DROP DATABASE IF EXISTS BookCatalog
GO

CREATE DATABASE BookCatalog
GO

USE BookCatalog

GO

CREATE TABLE Author (
	ID int IDENTITY(1,1) PRIMARY KEY,
	FirstName varchar(50) NOT NULL,
	LastName varchar(50) NOT NULL,
	Email varchar(200) NULL,
)
GO

CREATE TABLE Genre (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Name varchar(50) NOT NULL
)
GO



CREATE TABLE Book (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Title varchar(200) NOT NULL,
	ReleaseDate date NULL,
	Pages smallint NULL,
	Price decimal(9,2) NULL
)
GO

CREATE TABLE BookGenre (
	BookID int NOT NULL FOREIGN KEY REFERENCES Book(ID),
	GenreID int NOT NULL FOREIGN KEY REFERENCES Genre(ID),
	CONSTRAINT primaryConstraint PRIMARY KEY (BookID, GenreID)
)
GO

CREATE TABLE AuthorBook (
	AuthorID int NOT NULL FOREIGN KEY REFERENCES Author(ID),
	BookID int NOT NULL FOREIGN KEY REFERENCES Book(ID)
	CONSTRAINT primaryConstraint2 PRIMARY KEY (AuthorID, BookID)
)
GO

INSERT INTO Genre (Name) VALUES 
	('Action'),
	('Adventure'),
	('Fantasy'),
	('Horror'),
	('Science Fiction'),
	('Biography'),
	('Detective'),
	('Journalism'),
	('Computers'),
	('Internet'),
	('Fiction')
GO

INSERT INTO Author(FirstName, LastName, Email) VALUES 
	('Stephen', 'King', 'email@email.email'),
	('Robert C.', 'Martin', NULL),
	('Erich', 'Gamma', NULL),
	('Richard', 'Helm', NULL),
	('Ralph', 'Johnson', NULL),
	('John', 'Vlissides', NULL),
	('Grady', 'Booch', NULL)
GO

INSERT INTO Book(Title, ReleaseDate, Pages, Price) VALUES 
	('Clean Code: A Handbook of Agile Software Craftsmanship', CONVERT(date, '01/08/2008', 103),
		448, 39.99),
	('END OF THE WORLD', CONVERT(date, '31/12/2020', 103), 1, 0.97),
	('Design Patterns: Elements of Reusable Object-Oriented Software', CONVERT(date, '21/10/1994', 103),
	891, 59.99),
	('The Shining', CONVERT(date, '01/05/1990', 103), 464, 8.99),
	('It', CONVERT(date, '01/05/1990', 103), 1168, 12.99 )
GO

INSERT INTO BookGenre(BookID, GenreID) VALUES 
	(1, 9),
	(1, 10), 
	(2, 8),
	(3, 9),
	(3, 10),
	(4, 11),
	(5, 4);
GO

INSERT INTO AuthorBook(AuthorID, BookID) VALUES 
	(1, 4),
	(1, 5),
	(2, 1),
	(3, 3),
	(4, 3),
	(5, 3),
	(6, 3),
	(7, 3)
GO



CREATE PROCEDURE addBook
	@Title varchar(200),
	@ReleaseDate date,
	@Pages smallint,
	@Price decimal(9,4)
AS
	INSERT INTO Book(Title, ReleaseDate, Pages, Price) VALUES
		(@Title, @ReleaseDate, @Pages, @Price)
GO

CREATE PROCEDURE updateBook
	@ID int,
	@Title varchar(200),
	@ReleaseDate date,
	@Pages smallint,
	@Price decimal(9,4)
AS
	UPDATE Book
	SET Title = @Title, ReleaseDate = @ReleaseDate, Pages = @Pages, Price = @Price
	WHERE ID = @ID
GO

CREATE PROCEDURE deleteBook
	@ID int
AS
	DELETE Book
	WHERE ID = @ID
GO



CREATE PROCEDURE addAuthor
	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(200)
AS
	INSERT INTO Author(FirstName, LastName, Email) VALUES
		(@FirstName, @LastName, @Email)
GO

CREATE PROCEDURE updateAuthor
	@ID int,
	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(200)
AS
	UPDATE Author
	SET FirstName = @FirstName, LastName = @LastName, Email = @Email
	WHERE ID = @ID
GO

CREATE PROCEDURE deleteAuthor
	@ID int
AS
	DELETE Author
	WHERE ID = @ID
GO



CREATE PROCEDURE addGenre
	@Name varchar(50)
AS
	INSERT INTO Genre(Name) VALUES
		(@Name)
GO

CREATE PROCEDURE updateGenre
	@ID int,
	@Name varchar(50)
AS
	UPDATE Genre
	SET Name = @Name
	WHERE ID = @ID
GO

CREATE PROCEDURE deleteGenre
	@ID int
AS
	DELETE Genre
	WHERE ID = @ID
GO



CREATE PROCEDURE addAuthorBook
	@AuthorID int,
	@BookID int
AS
	INSERT INTO AuthorBook(AuthorID, BookID) VALUES
		(@AuthorID, @BookID)
GO

CREATE PROCEDURE updateAuthorBook
	@oldAuthorID int,
	@oldBookID int,
	@AuthorID int,
	@BookID int
AS
	UPDATE AuthorBook
	SET AuthorID = @AuthorID, BookID = @BookID
	WHERE AuthorID = @oldAuthorID and BookID = @oldBookID
GO

CREATE PROCEDURE deleteAuthorBook
	@AuthorID int,
	@BookID int
AS
	DELETE AuthorBook
	WHERE AuthorID = @AuthorID and BookID = @BookID
GO




CREATE PROCEDURE addBookGenre
	@BookID int,
	@GenreID int
AS
	INSERT INTO BookGenre(BookID, GenreID) VALUES
		(@BookID, @GenreID)
GO

CREATE PROCEDURE updateBookGenre
	@oldBookID int,
	@oldGenreID int,
	@BookID int,
	@GenreID int
AS
	UPDATE BookGenre
	SET BookID = @BookID, GenreID = @GenreID
	WHERE BookID = @oldBookID and GenreID = @oldGenreID
GO

CREATE PROCEDURE deleteBookGenre
	@BookID int,
	@GenreID int
AS
	DELETE BookGenre
	WHERE BookID = @BookID and GenreID = @GenreID
GO