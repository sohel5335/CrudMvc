using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Save(Employee employee)
        {
            EmployeeDA employeeDA = new EmployeeDA();
            employeeDA.save(employee);
            JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            string sData = scriptSerializer.Serialize(null);
            return Json(sData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get(int id) 
        {
            EmployeeDA employeeDA = new EmployeeDA();
            var emp = employeeDA.Get(id);
            JavaScriptSerializer scriptSerializer = new JavaScriptSerializer();
            string sData = scriptSerializer.Serialize(emp);
            return Json(sData, JsonRequestBehavior.AllowGet);
        }

}
}