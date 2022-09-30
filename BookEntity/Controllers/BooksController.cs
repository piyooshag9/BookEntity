using BookEntity.Models;
using BookEntity.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookEntity.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController:ControllerBase
    {
        private IBook _bookRepo;
        private IConfiguration _configuration;
        public BooksController(IConfiguration configuration,IBook book)
        {
            _configuration = configuration;
            _bookRepo = book;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(_bookRepo.GetBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(Guid id)
        {
            var book = _bookRepo.GetBook(id);
            if (book != null)
                return Ok(book);

            return NotFound($"Book with Id: {id} was not found");
        }

        [HttpPost]
        public IActionResult CreateBook(BookCreate book)
        {
            var book1 = _bookRepo.CreateBook(book);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + book1.Id,book1);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(Guid id,BookCreate book)
        {
            var book1 = _bookRepo.GetBook(id);
            if(book1 != null)
            {
                _bookRepo.UpdateBook(id, book);
                return Ok();
            }

            return NotFound();

        }
    }
}
