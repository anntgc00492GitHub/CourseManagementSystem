using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManagementSystem.Web.CustomFilters;

namespace CourseManagementSystem.Web.Areas.Admin.Controllers
{
    [AuthLog(Roles = "Lecturer")]
    [OutputCache(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class LecturerController : Controller
    {
        // GET: Admin/Lecturer
        public ActionResult Index()
        {
            return View();
        }
    }
}