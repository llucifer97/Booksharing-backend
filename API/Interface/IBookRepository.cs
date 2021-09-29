using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;

namespace API.Interface
{
    public interface IBookRepository
    {
         Task<List<Book>> GetAllBooks();
         Task<Book> GetBookById(string Id);
         Task<List<Book>> GetBookByTitle(string Title);
         Task<bool> SaveAllAsync();
    }
}