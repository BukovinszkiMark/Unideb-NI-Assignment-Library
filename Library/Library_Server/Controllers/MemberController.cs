using System.Collections.Generic;
using System.Linq;
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
            if (!ValidateMember(member))
            {
                return ValidationProblem("Name cannot be empty or whitespace and can only contain letters, remove any special characters.");
            }

            MemberRepository.AddMember(member);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Member member, long id)
        {
            var dbMember = MemberRepository.GetMember(id);

            if (dbMember == null)
            {
                return NotFound();
            }

            if (!ValidateMember(member))
            {
                return ValidationProblem("Name cannot be empty or whitespace and can only contain letters, remove any special characters.");
            }

            MemberRepository.UpdateMember(member);
            return Ok();
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

        public bool ValidateMember(Member member)
        {
            if (member.Name.Replace(" ", string.Empty).Length == 0)
            {
                return false;
            }

            if (member.Name.Replace(" ", string.Empty).Any(c => !char.IsLetter(c)))
            {
                return false;
            }

            return true;
        }
    }
}
