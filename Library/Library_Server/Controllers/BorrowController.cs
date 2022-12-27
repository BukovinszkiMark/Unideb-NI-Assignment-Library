using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Common.Models;
using Library_Server.Repositories;
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

            if (borrow != null)
            {
                return Ok(borrow);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post(Borrow borrow)
        {
            BorrowRepository.AddBorrow(borrow);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Borrow borrow, long id)
        {
            var dbBorrow = BorrowRepository.GetBorrow(id);

            if (dbBorrow != null)
            {
                BorrowRepository.UpdateBorrow(borrow);
                return Ok();
            }

            return NotFound();
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
    }
}
