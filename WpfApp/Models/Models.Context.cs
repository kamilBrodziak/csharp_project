﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BookCatalogEntities : DbContext
    {
        public BookCatalogEntities()
            : base("name=BookCatalogEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
    
        public virtual int addAuthor(string firstName, string lastName, string email)
        {
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addAuthor", firstNameParameter, lastNameParameter, emailParameter);
        }
    
        public virtual int addAuthorBook(Nullable<int> authorID, Nullable<int> bookID)
        {
            var authorIDParameter = authorID.HasValue ?
                new ObjectParameter("AuthorID", authorID) :
                new ObjectParameter("AuthorID", typeof(int));
    
            var bookIDParameter = bookID.HasValue ?
                new ObjectParameter("BookID", bookID) :
                new ObjectParameter("BookID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addAuthorBook", authorIDParameter, bookIDParameter);
        }
    
        public virtual int addBook(string title, Nullable<System.DateTime> releaseDate, Nullable<short> pages, Nullable<decimal> price)
        {
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var releaseDateParameter = releaseDate.HasValue ?
                new ObjectParameter("ReleaseDate", releaseDate) :
                new ObjectParameter("ReleaseDate", typeof(System.DateTime));
    
            var pagesParameter = pages.HasValue ?
                new ObjectParameter("Pages", pages) :
                new ObjectParameter("Pages", typeof(short));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addBook", titleParameter, releaseDateParameter, pagesParameter, priceParameter);
        }
    
        public virtual int addBookGenre(Nullable<int> bookID, Nullable<int> genreID)
        {
            var bookIDParameter = bookID.HasValue ?
                new ObjectParameter("BookID", bookID) :
                new ObjectParameter("BookID", typeof(int));
    
            var genreIDParameter = genreID.HasValue ?
                new ObjectParameter("GenreID", genreID) :
                new ObjectParameter("GenreID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addBookGenre", bookIDParameter, genreIDParameter);
        }
    
        public virtual int addGenre(string name)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("addGenre", nameParameter);
        }
    
        public virtual int deleteAuthor(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteAuthor", iDParameter);
        }
    
        public virtual int deleteAuthorBook(Nullable<int> authorID, Nullable<int> bookID)
        {
            var authorIDParameter = authorID.HasValue ?
                new ObjectParameter("AuthorID", authorID) :
                new ObjectParameter("AuthorID", typeof(int));
    
            var bookIDParameter = bookID.HasValue ?
                new ObjectParameter("BookID", bookID) :
                new ObjectParameter("BookID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteAuthorBook", authorIDParameter, bookIDParameter);
        }
    
        public virtual int deleteBook(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteBook", iDParameter);
        }
    
        public virtual int deleteBookGenre(Nullable<int> bookID, Nullable<int> genreID)
        {
            var bookIDParameter = bookID.HasValue ?
                new ObjectParameter("BookID", bookID) :
                new ObjectParameter("BookID", typeof(int));
    
            var genreIDParameter = genreID.HasValue ?
                new ObjectParameter("GenreID", genreID) :
                new ObjectParameter("GenreID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteBookGenre", bookIDParameter, genreIDParameter);
        }
    
        public virtual int deleteGenre(Nullable<int> iD)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteGenre", iDParameter);
        }
    
        public virtual int updateAuthor(Nullable<int> iD, string firstName, string lastName, string email)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var firstNameParameter = firstName != null ?
                new ObjectParameter("FirstName", firstName) :
                new ObjectParameter("FirstName", typeof(string));
    
            var lastNameParameter = lastName != null ?
                new ObjectParameter("LastName", lastName) :
                new ObjectParameter("LastName", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateAuthor", iDParameter, firstNameParameter, lastNameParameter, emailParameter);
        }
    
        public virtual int updateAuthorBook(Nullable<int> oldAuthorID, Nullable<int> oldBookID, Nullable<int> authorID, Nullable<int> bookID)
        {
            var oldAuthorIDParameter = oldAuthorID.HasValue ?
                new ObjectParameter("oldAuthorID", oldAuthorID) :
                new ObjectParameter("oldAuthorID", typeof(int));
    
            var oldBookIDParameter = oldBookID.HasValue ?
                new ObjectParameter("oldBookID", oldBookID) :
                new ObjectParameter("oldBookID", typeof(int));
    
            var authorIDParameter = authorID.HasValue ?
                new ObjectParameter("AuthorID", authorID) :
                new ObjectParameter("AuthorID", typeof(int));
    
            var bookIDParameter = bookID.HasValue ?
                new ObjectParameter("BookID", bookID) :
                new ObjectParameter("BookID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateAuthorBook", oldAuthorIDParameter, oldBookIDParameter, authorIDParameter, bookIDParameter);
        }
    
        public virtual int updateBook(Nullable<int> iD, string title, Nullable<System.DateTime> releaseDate, Nullable<short> pages, Nullable<decimal> price)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var releaseDateParameter = releaseDate.HasValue ?
                new ObjectParameter("ReleaseDate", releaseDate) :
                new ObjectParameter("ReleaseDate", typeof(System.DateTime));
    
            var pagesParameter = pages.HasValue ?
                new ObjectParameter("Pages", pages) :
                new ObjectParameter("Pages", typeof(short));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateBook", iDParameter, titleParameter, releaseDateParameter, pagesParameter, priceParameter);
        }
    
        public virtual int updateBookGenre(Nullable<int> oldBookID, Nullable<int> oldGenreID, Nullable<int> bookID, Nullable<int> genreID)
        {
            var oldBookIDParameter = oldBookID.HasValue ?
                new ObjectParameter("oldBookID", oldBookID) :
                new ObjectParameter("oldBookID", typeof(int));
    
            var oldGenreIDParameter = oldGenreID.HasValue ?
                new ObjectParameter("oldGenreID", oldGenreID) :
                new ObjectParameter("oldGenreID", typeof(int));
    
            var bookIDParameter = bookID.HasValue ?
                new ObjectParameter("BookID", bookID) :
                new ObjectParameter("BookID", typeof(int));
    
            var genreIDParameter = genreID.HasValue ?
                new ObjectParameter("GenreID", genreID) :
                new ObjectParameter("GenreID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateBookGenre", oldBookIDParameter, oldGenreIDParameter, bookIDParameter, genreIDParameter);
        }
    
        public virtual int updateGenre(Nullable<int> iD, string name)
        {
            var iDParameter = iD.HasValue ?
                new ObjectParameter("ID", iD) :
                new ObjectParameter("ID", typeof(int));
    
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateGenre", iDParameter, nameParameter);
        }
    }
}
