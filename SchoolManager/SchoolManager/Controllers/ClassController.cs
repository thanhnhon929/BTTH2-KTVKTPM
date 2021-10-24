using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolManager.Controllers
{
    public class ClassController : ApiController
    {
        SchoolDbDataContext data = new SchoolDbDataContext();
        public HttpResponseMessage Get()
        {
            var classList = from cl in data.Classes select cl;
            return Request.CreateResponse(HttpStatusCode.OK, classList);
        }

        public string Post(Class cl) {
            try
            { 
                data.Classes.InsertOnSubmit(cl);
                data.SubmitChanges();

                return "Add successfully";
            }
            catch (Exception)
            {
                return "Add Fail";
            }
        }

        public string Put(Class cl)
        {
            try
            {
                var newClass = data.Classes.SingleOrDefault(n => n.ClassID == cl.ClassID);
                newClass.ClassName = cl.ClassName;
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
                var newClass = data.Classes.SingleOrDefault(n => n.ClassID == id);
                data.Classes.DeleteOnSubmit(newClass);
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
