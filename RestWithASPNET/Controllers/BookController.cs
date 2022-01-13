using Microsoft.AspNetCore.Mvc;
using RestWithASPNET.Business;
using RestWithASPNET.Data.VO;
using RestWithASPNET.Models;
using System;
using System.Collections.Generic;

namespace RestWithASPNET.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/books")]
    public class BookController  : ControllerBase
    {
        private IBookBusiness _bookBusiness;

        public BookController(IBookBusiness bookBusiness)
        {
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public ActionResult<List<BookVO>> Get()
        {
            var books = _bookBusiness.FindAll();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<BookVO> GetById(long id)
        {
            var book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public ActionResult<BookVO> Post([FromBody] BookResumeVO book)
        {
            book.LaunchDate = DateTime.Now;
            BookVO newBook = _bookBusiness.Create(book);
            if (newBook == null) return BadRequest();
            return CreatedAtAction("GetById", new { id = newBook.Id }, newBook);
        }

        [HttpPut("{id}")]
        public ActionResult<BookVO> Put(long id, [FromBody] BookResumeVO book)
        {
            BookVO newBook = _bookBusiness.Update(id, book);
            if (newBook == null) return BadRequest();
            return Ok(newBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            BookVO book = _bookBusiness.FindById(id);
            if (book == null) return NotFound();
            _bookBusiness.Delete(id);
            return NoContent();
        }
    }
}
