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
    public class TeachersController : ControllerBase
    {

        public readonly DIEMDANH_APIContext _context;

        public TeachersController(DIEMDANH_APIContext context)
        {
            _context = context;
        }



        // GET: api/<TeachersController>
        [HttpGet]
        public IEnumerable<Teacher> Get()
        {
            return _context.Teachers;
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        public Teacher Get(int id)
        {
            return _context.Teachers.SingleOrDefault(x => x.Idteacher == id);
        }

        [HttpGet("/api/Teacher/{idUser}")]
        public Teacher GetBy(int idUser)
        {
            return _context.Teachers.SingleOrDefault(x => x.Id == idUser);
        }

        // POST api/<TeachersController>
        [HttpPost]
        public void Post([FromBody] Teacher teacher)
        {
            var teachers = _context.Users.SingleOrDefault(x => x.Id == teacher.Id);
            if (teachers == null)
            {
                Ok(NotFound());
            }
            else
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
            }
        }

        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Teacher teacher)
        {
            teacher.Idteacher = id;
            _context.Teachers.Update(teacher);
            _context.SaveChanges();

        }

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var teacher = _context.Teachers.SingleOrDefault(x => x.Idteacher == id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }

        }
    }
}
