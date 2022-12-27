using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_Common.Models;
using Library_Server.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Library_Server.Controllers
{
    [Route("api/member")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Member>> Get() 
        {
            var members = MemberRepository.GetMembers();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public ActionResult<Member> Get(long id)
        {
            var member = MemberRepository.GetMember(id);

            if (member != null)
            {
                return Ok(member);
            }
            else 
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post(Member member)
        {
            MemberRepository.AddMember(member);
            
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Member member, long id)
        {
            var dbMember = MemberRepository.GetMember(id);

            if (dbMember != null)
            {
                MemberRepository.UpdateMember(member);
                return Ok();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var member = MemberRepository.GetMember(id);

            if (member != null)
            {
                MemberRepository.DeleteMember(member);
                return Ok();
            }

            return NotFound();
        }
    }
}
