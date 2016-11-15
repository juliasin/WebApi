using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BookCatalog.Models;

namespace BookCatalog.Controllers
{
    public class BooksController : ApiController
    {
        static readonly IBookRepository repository = new BookRepository();
        public IEnumerable<Book> GetAllBooks()
        {
            return repository.GetAllBooks();
        }
        public Book GetBook(int id)
        {
            Book item = repository.GetBook(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        public Book PostBook(Book item)
        {
            item = repository.AddBook(item);
            return item;
        }
        public void PutBook(int id, Book book)
        {
            book.ID = id;
            if (!repository.UpdateBook(book))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteBook(int id)
        {
            Book item = repository.GetBook(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            repository.RemoveBook(id);
        }
    }
}
