using DiemDanhOTP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


        [HttpGet("/api/SessionDetail/Date/{date}/{idStudent}")]
        public async Task<IActionResult> GetByDate(string date, string idStudent)
        {
            int status = 0;
            var list = new List<SessionDetail>();
            var logs = from SessionDetail in _context.SessionDetails.Include(x => x.IdlessionNavigation) select SessionDetail;
            logs = logs.Where(p => p.Idstuddent == idStudent);
            logs.ToList().ForEach(log =>
            {
                String datee = String.Format("{0:yyyy-MM-dd}", log.Time);
               if(date == datee)
                {
                    list.Add(log);
                    status++;
                }

            });
          
            return Ok(new { data = status, list = list });
        }

        //GET api
        [HttpGet("{idstudent}/{idsession}")]
        public SessionDetail GetByIdStudentIdSession(string idstudent, int idsession)
        {
            return _context.SessionDetails.SingleOrDefault(x => x.Idlession == idsession && x.Idstuddent == idstudent);
        }


        [HttpGet("api/SessionDetail/{idsession}/{status}")]
        public async Task<IActionResult> GetStudent(int idsession, string status)
        {

            int count = 0;
            var logs = from SessionDetail in _context.SessionDetails.Include(x => x.IdstuddentNavigation) select SessionDetail;
            logs = logs.Where(p => p.Idlession == idsession && p.Status.Equals(status));
            logs.ToList().ForEach(log => count++);

            return Ok(new { quantity = count, data = logs });
        }

        [HttpGet("api/{idsession}/{idStudent}")]
        public async Task<IActionResult> GetQuantityAbsent(int idsession, string idStudent)
        {
            int status = 0;
            var session = _context.SessionDetails.SingleOrDefault(x => x.Idlession == idsession && x.Idstuddent == idStudent);
            if (session != null)
            {
                if (session.Status.Equals("1")) { status = 1; }
                else status = 0;
            }
            else
            {
                status = 0;
                session = null;

            }

            return Ok(new { result = status, data = session });
        }


        [HttpGet("{idsession}")]
        public IEnumerable<SessionDetail> GetByIdIdSession(int idsession)
        {
            var logs = from SessionDetail in _context.SessionDetails
                       select SessionDetail;
            logs = logs.Where(p => p.Idlession == idsession);
            return logs;
        }


        // POST api/<SessionDetailsController>
        [HttpPost]
        public void Post([FromBody] SessionDetail sessiondetail)
        {
            _context.SessionDetails.Add(sessiondetail);
            _context.SaveChanges();
        }
        //
        [HttpPut("/api/SessionDetail/{idSession}/{idStudent}")]
        public void Put(int idSession, string idStudent, [FromBody] SessionDetail sessionDetail)
        {

            var n = _context.SessionDetails.FirstOrDefault(x => x.Idstuddent == idStudent && x.Idlession == idSession);
            if (n != null)
            {
                /*  sessionDetail.Idstuddent = idStudent;
                  sessionDetail.Idlession = idSession;
                  _context.Update(sessionDetail);
                  _context.SaveChanges();*/

                /*   string dateTimeClient = n.Time.ToString();
                   string dateTimeServer = sessionDetail.Time.ToString();
                   if (sessionDetail.Otp == n.Otp && CompareTime(dateTimeClient, dateTimeServer) == true)
                   {*/
                n.Idlession = idSession;
                n.Otp = sessionDetail.Otp;
                n.Idstuddent = idStudent;
                n.Status = sessionDetail.Status;
                n.Note = sessionDetail.Note;
                n.Time = DateTime.UtcNow.AddHours(7);
                _context.Update(n);
                _context.SaveChanges();
                /*}
                else if (sessionDetail.Otp == n.Otp)
                {
                    n.Idlession = idSession;
                    n.Otp = sessionDetail.Otp;
                    n.Idstuddent = idStudent;
                    n.Status = "0";
                    n.Note = "Sinh viên điểm danh ngoài thời gian quy định";
                    n.Time = DateTime.Now;
                    _context.Update(n);
                    _context.SaveChanges();
                }
                else
                {
                    n.Idlession = idSession;
                    n.Otp = sessionDetail.Otp;
                    n.Idstuddent = idStudent;
                    n.Status = "0";
                    n.Note = "Sinh viên điểm danh thất bại do nhập sai mã OTP";
                    n.Time = DateTime.Now;
                    _context.Update(n);
                    _context.SaveChanges();
                }*/

            }


        }
        bool CompareTime(string dateTimeClient, string dateTimeServer)
        {
            DateTime s1 = DateTime.Parse(dateTimeClient);
            DateTime s2 = DateTime.Parse(dateTimeServer);

            TimeSpan timeSpan = s1.Subtract(s2);
            if (timeSpan.Seconds < 60)
            {
                return true;
            }
            return false;
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
