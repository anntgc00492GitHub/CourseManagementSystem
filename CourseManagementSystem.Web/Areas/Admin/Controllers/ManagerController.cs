using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseManagementSystem.Web.CustomFilters;

namespace CourseManagementSystem.Web.Areas.Admin.Controllers
{
    [AuthLog(Roles = "Manager")]
    [OutputCache(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class ManagerController : Controller
    {
        // GET: Admin/Manager
        public ActionResult Index()
        {
            return View();
        }
    }
}