using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
       [Route("/api/book/")]
       [ApiController]
       public class BookController : ControllerBase
       {
        private readonly DataContext _context;
        private readonly IBookRepository _bookRepository;
        public BookController(DataContext context, IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
            _context = context;
        }



            
        [HttpPost]
        public  ActionResult AddBook([FromBody]BookDto bookDto)
        {
            if (bookDto.Title == null )
            {
                return BadRequest("Data is not received in proper format");
            }

            var book = new Book
                        {
                           Author = bookDto.Author,
                           Title = bookDto.Title
                        };

            _context.Books.Add(book);
            
            var addedBook = _bookRepository.SaveAllAsync();

            if (addedBook == null)
            {
                return BadRequest("Error while adding a book");
            }
           return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> getAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        
        [HttpGet("title/{title}/")]
        public  List<Book> findBookByTitle(string title)
        {
            Task<List<Book>> result;
            if(title == null) {
              result =  _bookRepository.GetAllBooks();
            }
             result =  _bookRepository.GetBookByTitle(title);
            List<Book> listofbook =  result.Result;
            if(listofbook == null){
              return new List<Book>();
            }
            return listofbook;

        }

        [HttpGet("{bookid}/")]
        public async  Task<Book> findBookById(string bookid)
        {
            Task<Book> result;
            Task<Book> listofbook =  _bookRepository.GetBookById(bookid);;
           return await listofbook;
        }



    }
}