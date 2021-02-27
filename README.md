# Book Catalog - A Simple WPF application with SQL Database

Movie Catalog is a simple demonstration of database based application that
lets you store a list of books, authors. Application let you easily create, update, delete or just read 
database records.


## **Prerequisites**

You need the following tools in order to run/edit the solution.

- Microsoft Visual Studio (Latest recommended)

- Microsoft SQL Server (Latest recommended)

## **Getting Started**

The application requires a database to store the data. Follow the below
steps to setup database. 

1.      
Run the script 'DBCreate.sql' to create and
populate database (MS SQL SERVER is required)

2.      
Set the connection string

&ensp;&ensp;  i.        
  Open project_csharp.sln (Visual Studio is required)

&ensp;&ensp;  ii.      
  Go to Properties in Solution Explorer

&ensp;&ensp;  iii.     
  Go to Settings.settings

&ensp;&ensp;  iv.    
  Insert Name as 'connString', Type as (Connection String), Scope as Application and Value as Connection String of Database.

## **Project Structure**

**View:**

- *AuthorAddPage.xaml:* Contains UI for Add Author
- *AuthorAddPage.xaml.cs:* Contains interaction logic for AuthorAddPage.xaml
- *AuthorDetailsPage.xaml:* Contains UI for Update, Delete Author
- *AuthorDetailsPage.xaml.cs:* Contains interaction logic for AuthorDetailsPage.xaml
- *AuthorPage.xaml:* Contians UI for View list of Authors
- *BookAddPage.xaml:* Contains UI for Add Book
- *BookAddPage.xaml.cs:* Contains interaction logic for BookAddPage.xaml
- *BookDetailsPage.xaml:* Contains UI for Update, Delete Author
- *BookDetailsPage.xaml.cs:* Contains interaction logic for BookDetailsPage.xaml
- *BookPage.xaml:* Contains UI for View list of Books
- *BookPage.xaml.cs:* Contains interaction logic for BookPage.xaml
- *GenreAddPage.xaml:* Contains UI for Add Genre
- *GenreAddPage.xaml.cs:* Contains interaction logic for GenreAddPage.xaml
- *GenreDetailsPage.xaml:* Contains UI for Update, Delete Genre
- *GenreDetailsPage.xaml.cs:* Contains interaction logic for GenreDetailsPage.xaml
- *GenrePage.xaml:* Contains UI for View list of Genres
- *GenrePage.xaml.cs:* Contains interaction logic for GenrePage.xaml

**Model:**

- *Book.cs:* Contains code for book class (Model)
- *Author.cs:* Contains code for author class (Model)
- *Genre.cs:* Contains code for genre class (Model)
- *Models.Context.cs:* Contains database connectivity code and logic

## **Author**

[Kamil Brodziak](https://www.linkedin.com/in/kamil98brodziak/)