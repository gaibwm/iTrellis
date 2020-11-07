using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.DAL;
using WebApplication1.Models;
using log4net;

namespace WebApplication1.api//Controllers
{
    // Route   
    [RoutePrefix("/api/Student")]
    public class StudentController : ApiController
    {
        private StudentContext db = new StudentContext();
        ILog log = log4net.LogManager.GetLogger(typeof(StudentController));

        [ResponseType(typeof(Student))]
        [HttpGet]
        // GET: api/Student
        public List<Student> GetStudents()
        {
            log.Debug("student count: " + db.Students.Count().ToString());
            return db.Students.ToList();
        }

        // GET: api/Student/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult GetStudent(string id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Student/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(student.StudentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Student
        [ResponseType(typeof(Student))]
        [HttpPost]
        public IHttpActionResult PostStudent(Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            student.StudentID = (db.Students.Count() + 1).ToString();

            db.Students.Add(student);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.StudentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = student.StudentID }, student);
        }

        // DELETE: api/Student/5
        [ResponseType(typeof(Student))]
        [HttpDelete]
        public IHttpActionResult DeleteStudent(string sID)
        {

            log.Debug("Before student delete count: " + db.Students.Count().ToString());
            Student student = db.Students.Find(sID);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();
            log.Debug("After student delete count: " + db.Students.Count().ToString());


            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(string id)
        {
            return db.Students.Count(e => e.StudentID == id) > 0;
        }
    }
}