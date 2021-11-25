using DiemDanhOTP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DiemDanhOTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        public readonly DIEMDANH_APIContext _context;

        public UsersController(DIEMDANH_APIContext context)
        {
            _context = context;
        }


        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return _context.Users.SingleOrDefault(x => x.Id == id);
        }
        [HttpGet("{username}/{password}")]
        public User Get(string username, string password)
        {
            return _context.Users.SingleOrDefault(x => x.Usename == username && x.Password == password);
        }
        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            user.Id = id;
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _context.Users.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _context.Users.Remove(item);
                _context.SaveChanges();
            }

        }
    }
}
