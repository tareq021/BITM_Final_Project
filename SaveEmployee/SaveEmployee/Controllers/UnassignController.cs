using SaveEmployee.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaveEmployee.Controllers
{
    public class UnassignController : Controller
    {
        UnassignGateWay gateway = new UnassignGateWay();
        //
        // GET: /Unassign/

        [HttpGet]
        public ActionResult UnassignCourse()
        { return View(); }

        [HttpPost]
        public ActionResult UnassignCourse(string nul)
        {
            int rowEffected = gateway.Unassigned();
            if (rowEffected>=1)
            {
                ViewBag.message = "Successfully Unassigned !";
            }
            if (rowEffected == 0)
            {
                ViewBag.message = "Unassigned unsuccessfull!";
            }
            return View();
        }



        [HttpGet]
        public ActionResult Unallocate()
        { return View(); }

        [HttpPost]
        public ActionResult Unallocate(string nul)
        {
            int rowEffected = gateway.Unallocate();
            if (rowEffected >= 1)
            {
                ViewBag.message = "Successfully Unallocated !";
            }
            if (rowEffected == 0)
            {
                ViewBag.message = "Unallocation unsuccessfull!";
            }
            return View();
        }
	}
}