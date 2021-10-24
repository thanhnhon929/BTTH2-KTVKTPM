using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolManager.Controllers
{
    public class StudentController : ApiController
    {
        SchoolDbDataContext data = new SchoolDbDataContext();
        public HttpResponseMessage Get()
        {
            var studentList = from st in data.Students select st;
            return Request.CreateResponse(HttpStatusCode.OK, studentList);
        }

        [Route("api/student/GetAllClassName")]
        [HttpGet]
        public HttpResponseMessage GetAllClassName()
        {
            var className = from cl in data.Classes select cl.ClassName;
            return Request.CreateResponse(HttpStatusCode.OK, className);
        }

        public string Post(Student st)
        {
            try
            {
                data.Students.InsertOnSubmit(st);
                data.SubmitChanges();

                return "Add successfully";
            }
            catch (Exception)
            {
                return "Add Fail";
            }
        }

        public string Put(Student st)
        {
            try
            {
                var newClass = data.Students.SingleOrDefault(n => n.StudentID == st.StudentID);
                newClass.StudentName = st.StudentName;
                newClass.StudentAddress = st.StudentAddress;
                newClass.StudentClassID = st.StudentClassID;

                data.SubmitChanges();

                return "Update successfully";
            }
            catch (Exception)
            {
                return "Update Fail";
            }
        }

        public string Delete(int id)
        {
            try
            {
                var newStudent = data.Students.SingleOrDefault(n => n.StudentID == id);
                data.Students.DeleteOnSubmit(newStudent);
                data.SubmitChanges();

                return "Delete successfully";
            }
            catch (Exception)
            {
                return "Delete Fail";
            }
        }
    }
}
