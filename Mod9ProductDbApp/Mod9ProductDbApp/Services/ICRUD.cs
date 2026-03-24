using Mod9ProductDbApp.Models;
using System.Collections.Generic;

namespace Mod9ProductDbApp.Services
{
    public interface ICRUD
    {
        List<Book> GetBooks();
        void UpsertBook(Book book);
        void DeleteBook(string isbn);
    }
}
