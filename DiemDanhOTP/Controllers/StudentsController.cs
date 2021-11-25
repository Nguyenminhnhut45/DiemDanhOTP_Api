using DiemDanhOTP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiemDanhOTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        public readonly DIEMDANH_APIContext _context;

        public StudentsController(DIEMDANH_APIContext context)
        {
            _context = context;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _context.Students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(string id)
        {
            return _context.Students.SingleOrDefault(x => x.Idstudent == id);
        }

        // POST api/<StudentsController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            var students = _context.Users.SingleOrDefault(x => x.Id == student.Id);
            if (students == null)
            {
                Ok(NotFound());
            }
            else
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }

        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Student student)
        {
            student.Idstudent = id;

            _context.Students.Update(student);
            _context.SaveChanges();
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var student = _context.Students.SingleOrDefault(x => x.Idstudent == id);
            if (student != null)
            {
                _context.Remove(student);
                _context.SaveChanges();
            }

        }
    }
}
