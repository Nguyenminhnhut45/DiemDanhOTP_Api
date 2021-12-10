using DiemDanhOTP.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

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
        [HttpGet("/api/Sessions/Group/{id}")]
        public IEnumerable<Session> GetByIdGroup(int id)
        {
            var logs = from Session in _context.Sessions.Include(x => x.IdgroupNavigation) select Session;
            logs = logs.Where(p => p.Idgroup == id);
            return logs;
        }
        [HttpGet("/api/Session/Date/{date}")]
        public IEnumerable<Session> GetByDate(string date)
        {
            var logs = from Session in _context.Sessions.Include(x => x.IdgroupNavigation) select Session;
            logs = logs.Where(p => p.Date.ToString() == date);
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


        [HttpGet("/api/Session/{idSession}")]
        public async Task<IActionResult> SessionSend(int idSession)
        {
            string[] saAllowedCharacters = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            var session = _context.Sessions.FirstOrDefault(x => x.Idsession == idSession);
            if (session == null)
            {
                return NotFound();
            }
            List<string> students = new List<string>();
            var users = new List<Student>();
            var logs = from Study in _context.Studies select Study;
            logs = logs.Where(p => p.Idgroup == session.Idgroup);//Loc studies theo idgroup


            logs.ToList().ForEach(log => students.Add(log.Idstudent));//Add nhung id thuoc log vao students
            var st = from Student in _context.Students select Student;
            int count = 0;
            foreach (var s in students)
            {
                var n = _context.Students.FirstOrDefault(x => x.Idstudent == s);
                if (n != null)
                {
                    users.Add(n);
                }
            }
            // DateTime date = DateTime.UtcNow.AddHours(7);
            // SendSMS("Nguyễn Minh Nhựt", "386620117", "12324", date);

            foreach (var student in users)
            {
                string otp = GenerateRandomOTP(6, saAllowedCharacters);
                DateTime date = DateTime.UtcNow.AddHours(7);
                SendMail(student.FullName, student.Email, otp, date);

                int id = idSession;
                string idStudent = student.Idstudent;
                string otps = otp;
                DateTime dateTime = date;

                SessionDetail sessionDetail = new SessionDetail()
                {
                    Idlession = id,
                    Idstuddent = idStudent,
                    Otp = otp,
                    Time = dateTime,
                    Status = "0"

                };
                _context.Add(sessionDetail);
                _context.SaveChanges();
            }
            return StatusCode(201);
        }



        void SendMail(string name, string email, string otp, DateTime dateTime)
        {

            MimeMessage message = new MimeMessage();
            using (var client = new SmtpClient())
            {
                message.From.Add(new MailboxAddress("Xác nhận điểm danh", "khoaanhdang11@gmail.com"));

                message.To.Add(new MailboxAddress(name, email));
                message.Subject = "ĐIỂM DANH HUTECH";

                var bodyBuilder = new BodyBuilder();
                bodyBuilder.HtmlBody = "<p>Sử dụng mã xác minh " + "" + otp + " để xác thực điểm danh. <br>Mã sử dụng trong vòng <a color=red>60s!</a>!"
                    + dateTime.ToString("<br>dddd, MMMM d, yyyy hh:mm:ss") + "</p>";
                message.Body = bodyBuilder.ToMessageBody();
                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                client.Authenticate("khoaanhdang11@gmail.com", "gmejtlyjhrmdlbhv");
                client.Send(message);
                client.Disconnect(true);
            }
        }
        /*void SendSMS(string name, string sdt, string otp, DateTime dateTime)
        {
            SpeedSMSAPI api = new SpeedSMSAPI("lshK5WiQvtQNMrLmiYf_eAGRXdQycPMl");
            String[] phones = new String[] { sdt };
            String str = "Mã xác nhận điểm danh của bạn là " + otp + "/nMã có hiệu lực trong 60s" + "/n" + dateTime.ToString("dddd, MMMM d, yyyy hh: mm:ss");
            String response = api.sendSMS(phones, str, 2, "");
            //String response = api.sendMMS(phones, str, "https://", "device ID");
        }*/

        string GenerateRandomOTP(int iOTPLength, string[] saAllowedCharacters)

        {

            string sOTP = String.Empty;

            string sTempChars = String.Empty;

            Random rand = new Random();

            for (int i = 0; i < iOTPLength; i++)

            {

                int p = rand.Next(0, saAllowedCharacters.Length);

                sTempChars = saAllowedCharacters[rand.Next(0, saAllowedCharacters.Length)];

                sOTP += sTempChars;

            }

            return sOTP;

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
                _context.SaveChanges();
            }
        }
    }
}
