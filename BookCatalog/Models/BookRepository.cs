﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookCatalog.Models
{
    public class BookRepository:IGenreRepository,IBookRepository 
    {
        private List<Book> books = new List<Book>();
        private List<Genre> genres = new List<Genre>();
        private int _nextIdB = 1;
        private int _nextIdG = 1;

        public BookRepository()
        {
            AddGenre(new Genre() { Name = "Novel" });
            AddGenre(new Genre() { Name = "Science fiction" });
            AddGenre(new Genre() { Name = "Philosophical fiction" });
            AddBook(new Book() { BookName = "War and Peace", Author = "Leo Tolstoy", Year = 1869, PublishingOffice = "The Russian Messenger",Genre=genres[0]});
            AddBook(new Book() { BookName = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925, PublishingOffice = "Charles Scribner's Sons", Genre = genres[0] });
            AddBook(new Book() { BookName = "The Hunger Games", Author = "Suzanne Collins", Year = 2008, PublishingOffice = "Scholastic" , Genre = genres[1] });
            AddBook(new Book() { BookName = "The Picture of Dorian Gray", Author = "Oscar Wilde", Year = 1890, PublishingOffice = "Lippincott's Monthly Magazine", Genre = genres[2] });
      
        }

        public Book AddBook(Book item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.ID = _nextIdB++;
            books.Add(item);
            return item;
        }

        public Genre AddGenre(Genre item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.ID = _nextIdG++;
            genres.Add(item);
            return item;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return books;
        }

        public IEnumerable<Genre> GetAllGenres()
        {
            return genres;
        }

        public Book GetBook(int id)
        {
            return books.Find(p => p.ID == id);
        }

        public Genre GetGenre(int id)
        {
            return genres.Find(p => p.ID == id);
        }

        public void RemoveBook(int id)
        {
            books.RemoveAll(p => p.ID == id);
        }

        public void RemoveGenre(int id)
        {
            genres.RemoveAll(p => p.ID == id);
        }

        public bool UpdateBook(Book item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = books.FindIndex(p => p.ID == item.ID);
            if (index == -1)
            {
                return false;
            }
            books.RemoveAt(index);
            books.Add(item);
            return true;
        }

        public bool UpdateGenre(Genre item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = genres.FindIndex(p => p.ID == item.ID);
            if (index == -1)
            {
                return false;
            }
            genres.RemoveAt(index);
            genres.Add(item);
            return true;
        }
    }
}