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
    public class StudiesController : ControllerBase
    {
        public readonly DIEMDANH_APIContext _context;

        public StudiesController(DIEMDANH_APIContext context)
        {
            _context = context;
        }
        // GET: api/<StudysController>
        [HttpGet]
        public IEnumerable<Study> Get()
        {
            return _context.Studies.Include(x => x.IdgroupNavigation).Include(x => x.IdstudentNavigation);
        }

        // GET api/<StudysController>/5
        [HttpGet("{mssv}")]
        public Study GetByMssv(string mssv)
        {
            return _context.Studies.Include(x => x.IdstudentNavigation).SingleOrDefault(x => x.Idstudent == mssv);
        }
        //Get theo nhoms mon hoc
        [HttpGet("/api/Studies/Group/{idgroup}")]
        public IEnumerable<Study> GetByGroup(int idgroup)
        {
            var logs = from Study in _context.Studies.Include(x => x.IdgroupNavigation) select Study;
            logs = logs.Where(p => p.Idgroup == idgroup);
            return logs;
        }
        //Get theo sinh vien
        [HttpGet("/api/Studies/Student/{idStudent}")]
        public IEnumerable<Study> GetByStudent(string idStudent)
        {
            var logs = from Study in _context.Studies.Include(x => x.IdgroupNavigation) select Study;
            logs = logs.Where(p => p.Idstudent == idStudent);
            return logs;
        }

        // POST api/<StudysController>
        [HttpPost]
        public void Post([FromBody] Study study)
        {
            _context.Studies.Add(study);
            _context.SaveChanges();
        }

        // PUT api/<StudysController>/5
        [HttpPut("{id}")]
        public void Put(string mssv, [FromBody] Study study)
        {
            study.Idstudent = mssv;
            _context.Studies.Update(study);
            _context.SaveChanges();
        }

        // DELETE api/<StudysController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}
