using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Http.Cors;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public void Get()
        {
            Student s = new Student()
            {
                FirstName = "lom",
                LastName = "Phouthavongxay",
                Email = "gaibwm@hotmail.com",
                Address = "15468 SE Bradford rd Clackmas OR 97015",
                StudentID = "0"
            };

        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value" + id.ToString();
        }

        // POST api/values
        public HttpResponseMessage Post(Student s)
        {
            return Request.CreateResponse(HttpStatusCode.OK, 0);
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody] string value)
        {
            return Request.CreateResponse(HttpStatusCode.OK, 0);
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, 0);
        }
    }

 
}
