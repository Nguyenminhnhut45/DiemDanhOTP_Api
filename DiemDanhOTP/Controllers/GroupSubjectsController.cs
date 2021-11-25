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
    public class GroupSubjectsController : ControllerBase
    {

        public readonly DIEMDANH_APIContext _context;

        public GroupSubjectsController(DIEMDANH_APIContext context)
        {
            _context = context;
        }
        // GET: api/<GroupSubjectsController>
        [HttpGet]

        public IEnumerable<GroupSubject> Get()
        {
            return _context.GroupSubjects.Include(x => x.IdcourseNavigation).Include(y => y.IdteacherNavigation);
        }

        // GET api/<GroupSubjectsController>/5
        [HttpGet("{id}")]
        public GroupSubject Get(int id)
        {
            return _context.GroupSubjects.Include(x => x.IdcourseNavigation).Include(x => x.IdteacherNavigation).SingleOrDefault(x => x.Idgroup == id);
        }

        [HttpGet("/api/Group/{idteacher}")]
        public IEnumerable<GroupSubject> GetByIdTeacher(int idteacher)
        {
            var logs = from GroupSubject in _context.GroupSubjects.Include(x => x.IdcourseNavigation) select GroupSubject;
            logs = logs.Where(p => p.Idteacher == idteacher);
            return logs;
        }
        // POST api/<GroupSubjectsController>
        [HttpPost]
        public void Post([FromBody] GroupSubject groupSubject)
        {
            _context.GroupSubjects.Add(groupSubject);
            _context.SaveChanges();
        }

        // PUT api/<GroupSubjectsController>/5
        [HttpPut("{id}")]
        public void Put(int idGroup, [FromBody] GroupSubject groupSuject)
        {
            groupSuject.Idgroup = idGroup;
            _context.GroupSubjects.Update(groupSuject);
            _context.SaveChanges();
        }

        // DELETE api/<GroupSubjectsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var groupSubject = _context.GroupSubjects.SingleOrDefault(x => x.Idgroup == id);
            if (groupSubject != null)
            {
                _context.Remove(groupSubject);
                _context.SaveChanges();
            }
        }
    }
}
