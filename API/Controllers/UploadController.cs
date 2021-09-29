using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace API.Controllers
{
    [ApiController]
    [Route("/api/sell")]
    public class UploadController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly DataContext _context;
        private readonly IUserRepository _userRepository;
        public UploadController(IBookRepository bookRepository, DataContext context, IUserRepository userRepository)
        {
            this._userRepository = userRepository;
            this._context = context;
            this._bookRepository = bookRepository;
        }


        [HttpPost]
        public ActionResult UploadBook([FromBody] SellerDto sellerDto)
        {
            var seller = _userRepository.GetUserByName(sellerDto.SellerId);
            
             if(seller.Result.UserName == null){
                 BadRequest("sellid not found");
             }

            String UUID = Guid.NewGuid().ToString();
            var book = new Book
            {
                Title = sellerDto?.Title.ToLower(),
                Price = (int)(sellerDto?.price),
                Author = sellerDto?.Author.ToLower(),
                Genre = sellerDto?.Genre.ToLower(),
                Year = sellerDto?.Year.ToLower(),
                Language = sellerDto?.Language.ToLower(),
                URL = sellerDto?.URL,
                SellId = sellerDto?.SellerId.ToLower(),
                Rating = 0,
                bookserialno = UUID
            };

            _context.Books.Add(book);

            var addedBook = _bookRepository.SaveAllAsync();

            if (addedBook.Result == false)
            {
                var result = StatusCode(StatusCodes.Status500InternalServerError);
                return result; 
            }


            // return CreatedAtRoute("AddBook", new { controller = "add", id = book.Id }, book);
            return Ok(book);
        }

    }
}