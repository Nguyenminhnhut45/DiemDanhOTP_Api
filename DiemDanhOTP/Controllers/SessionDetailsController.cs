using DiemDanhOTP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SessionDetailsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SessionDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SessionDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
