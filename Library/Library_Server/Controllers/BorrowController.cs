using System.Collections.Generic;
using Library_Common.Models;
using Library_Server.Repositories;
using LibraryCommon.Models;
using LibraryServer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library_Server.Controllers
{
    [Route("api/borrow")]
    [ApiController]
    public class BorrowController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Borrow>> Get()
        {
            var borrows = BorrowRepository.GetBorrows();
            return Ok(borrows);
        }

        [HttpGet("{id}")]
        public ActionResult<Borrow> Get(long id)
        {
            var borrow = BorrowRepository.GetBorrow(id);

            if (borrow == null)
            {
                return NotFound();
            }

            return Ok(borrow);
        }

        [HttpPost]
        public ActionResult Post(Borrow borrow)
        {
            if (!ValidateBorrow(borrow))
            {
                return ValidationProblem("Return date can only be a later date than the borrow date");
            }

            BorrowRepository.AddBorrow(borrow);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Borrow borrow, long id)
        {
            var dbBorrow = BorrowRepository.GetBorrow(id);

            if (dbBorrow == null)
            {
                return NotFound();
            }

            if (!ValidateBorrow(borrow))
            {
                return ValidationProblem("Return date can only be a later date than the borrow date");
            }

            BorrowRepository.UpdateBorrow(borrow);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var borrow = BorrowRepository.GetBorrow(id);

            if (borrow != null)
            {
                BorrowRepository.DeleteBorrow(borrow);
                return Ok();
            }

            return NotFound();
        }

        public bool ValidateBorrow(Borrow borrow)
        {
            return borrow.ReturnDate > borrow.BorrowDate;
        }
    }
}
