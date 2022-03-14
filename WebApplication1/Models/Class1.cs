using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Employee
    {
        public int Id { get; set; } 
        public string EmpName { get; set; }
        public bool isAllowOverTime { get; set; }
       public string Gender { get; set; }
        public string Education { get; set; }
        public DateTime BirthDate { get; set; }


    }
}