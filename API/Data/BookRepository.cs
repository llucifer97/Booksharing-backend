using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            this._context = context;
        }

       

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }


        public async Task<List<Book>> GetAllBooks()
        {
           return await _context.Books.ToListAsync();
        }

        public  Task<Book> GetBookById(string bookid)
        {
            
            var query = _context.Books.AsQueryable();

            query = query.Where(u => u.bookserialno == bookid);
            if(query == null) return null;
            
            return  query.SingleAsync();
        }

        public async Task<List<Book>> GetBookByTitle(string Title)
        {
            var query = _context.Books.AsQueryable();

            query = query.Where(u => u.Title == Title);
            if(query == null) return null;
            
            return await query.ToListAsync();
        }

       
    }
}