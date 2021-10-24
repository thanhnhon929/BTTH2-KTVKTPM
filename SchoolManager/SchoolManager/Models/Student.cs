using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolManager.Models
{
    public class Students
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string StudentAddress { get; set; }
        public int StudentClassID { get; set; }
    }
}