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
    public class SessionsController : ControllerBase
    {
        public readonly DIEMDANH_APIContext _context;

        public SessionsController(DIEMDANH_APIContext context)

        {
            _context = context;
        }
        // GET: api/<SessionsController>
        [HttpGet]
        public IEnumerable<Session> Get()
        {
           
           return _context.Sessions.Include(x => x.IdgroupNavigation);
           
        }

        // GET api/<SessionsController>/5
        [HttpGet("{id}")]
        public Session Get(int id)
        {

            return _context.Sessions.Include(x => x.IdgroupNavigation).SingleOrDefault(x => x.Idsession == id);
        }

        //Get api by groupsubject 
        [HttpGet("/Session/group/{group}")]
        public IEnumerable<Session> GetByIdGroup(int group)
        {
            var logs = from Session in _context.Sessions select Session;
            logs = logs.Where(p => p.Idgroup == group);
            return logs;
        }
        //get by teacher

        // POST api/<SessionsController>
        [HttpPost]
        public void Post([FromBody] Session session)
        {
            _context.Sessions.Add(session);
            _context.SaveChanges();
        }

        // PUT api/<SessionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Session session)
        {
            session.Idsession = id;
            _context.Sessions.Update(session);
            _context.SaveChanges();

        }

        // DELETE api/<SessionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var session = _context.Sessions.SingleOrDefault(x => x.Idsession == id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
            }
        }
    }
}
