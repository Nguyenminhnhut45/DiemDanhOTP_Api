using DiemDanhOTP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiemDanhOTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionDetailsController : ControllerBase
    {
        public readonly DIEMDANH_APIContext _context;

        public SessionDetailsController(DIEMDANH_APIContext context)
        {
            _context = context;
        }
        // GET: api/<SessionDetailsController>
        [HttpGet]
        public IEnumerable<SessionDetail> Get()
        {
            return _context.SessionDetails.Include(x => x.IdstuddentNavigation).Include(x => x.IdlessionNavigation);
        }

        // GET api/<SessionDetailsController>/5

        //GET api
        [HttpGet("{idstudent}/{idsession}")]
        public SessionDetail GetByIdStudentIdSession(string idstudent, int idsession)
        {
            return _context.SessionDetails.SingleOrDefault(x => x.Idlession == idsession && x.Idstuddent == idstudent);
        }

        // POST api/<SessionDetailsController>
        [HttpPost]
        public void Post([FromBody] SessionDetail sessiondetail)
        {
            _context.SessionDetails.Add(sessiondetail);
            _context.SaveChanges();
        }

        // PUT api/<SessionDetailsController>/5
        [HttpPut("{idstudent}")]
        public void Put(string idstudent, [FromBody] SessionDetail sessionDetail)
        {
            sessionDetail.Idstuddent = idstudent;
            _context.SessionDetails.Update(sessionDetail);
            _context.SaveChanges();
        }

        // DELETE api/<SessionDetailsController>/5
        [HttpDelete("{idstudent}")]
        public void Delete(string idstudent)
        {
            var item = _context.SessionDetails.FirstOrDefault(x => x.Idstuddent == idstudent);
            if (item != null)
            {
                _context.SessionDetails.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}
