using Mod9ProductDbApp.Data;
using Mod9ProductDbApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mod9ProductDbApp.Services
{
    public class CRUD : ICRUD
    {   

        private readonly BookContext _bookContext;

        public CRUD(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public List<Book> GetBooks()
        {
            return _bookContext.Books.OrderBy(b => b.Name).ToList();
        }

        public void UpsertBook(Book book)
        {
            var existing = _bookContext.Books.AsNoTracking().FirstOrDefault(b => b.ISBN == book.ISBN);
            if (existing == null)
            {
                _bookContext.Books.Add(book);
            }
            else
            {
                _bookContext.Books.Update(book);
            }

            _bookContext.SaveChanges();
        }

        public void DeleteBook(string isbn)
        {
            var book = _bookContext.Books.Find(isbn);
            if (book == null)
                return;

            _bookContext.Books.Remove(book);
            _bookContext.SaveChanges();
        }
    }
}
