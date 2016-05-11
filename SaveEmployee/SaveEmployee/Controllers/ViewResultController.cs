using iTextSharp.text;
using iTextSharp.text.pdf;
using SaveEmployee.BLL;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UniversityApplication.Context;
using UniversityApplication.Models;


namespace SaveEmployee.Controllers
{
    public class ViewResultController : Controller
    {
        private ApplicationContext db = new ApplicationContext();

        // GET: /ViewResult/
        public ActionResult Index()
        {

            return View(db.ViewResults.ToList());
        }

        // GET: /ViewResult/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaveEmployee.Models.ViewResult viewresult = db.ViewResults.Find(id);
            if (viewresult == null)
            {
                return HttpNotFound();
            }
            return View(viewresult);
        }

        // GET: /ViewResult/Create
        public ActionResult Create()
        {
            List<Student> StudentList = new List<Student>();

            using (ApplicationContext db = new ApplicationContext())
            {
                StudentList = db.Students.OrderBy(m => m.StudentRegNo).ToList();
            }
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var regNo in StudentList)
            {
                items.Add(new SelectListItem() { Value = regNo.StudentRegNo, Text = regNo.StudentRegNo });
            }

            ViewBag.RegNo = items;

            return View();
        }










        // GET: /ViewResult/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaveEmployee.Models.ViewResult viewresult = db.ViewResults.Find(id);
            if (viewresult == null)
            {
                return HttpNotFound();
            }
            return View(viewresult);
        }

        // POST: /ViewResult/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RegNo,Name,Email,Department")] SaveEmployee.Models.ViewResult viewresult)
        {
            if (ModelState.IsValid)
            {
                db.Entry(viewresult).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(viewresult);
        }

        // GET: /ViewResult/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SaveEmployee.Models.ViewResult viewresult = db.ViewResults.Find(id);
            if (viewresult == null)
            {
                return HttpNotFound();
            }
            return View(viewresult);
        }

        // POST: /ViewResult/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SaveEmployee.Models.ViewResult viewresult = db.ViewResults.Find(id);
            db.ViewResults.Remove(viewresult);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }




        public string Name;
        public string Email;
        public string Dept;
        public string RegNo;
        
        //Name
        [HttpGet]
        public JsonResult GetName(string regNo)
        {
            var names = "";
            if (regNo != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    names = (db.Students.Where(m => m.StudentRegNo == regNo).Select(m => m.StudentName)).Single();
                    Name = names;
                    RegNo = regNo;
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = names,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }


        //Email
        [HttpGet]
        public JsonResult GetEmail(string regNo)
        {
            var emails = "";
            if (regNo != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    emails = (db.Students.Where(m => m.StudentRegNo == regNo).Select(m => m.StudentEmail)).Single();
                    Email = emails;
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = emails,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }


        //Department
        [HttpGet]
        public JsonResult GetDepartment(string regNo)
        {
            var departments = "";
            if (regNo != null)
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    departments = (db.Students.Where(m => m.StudentRegNo == regNo).Select(m => m.StudentDepartmentCode)).Single();
                    Dept = departments;
                }
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = departments,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }


        //CourseInfo
        [HttpGet]
        public JsonResult GetCourseInfo(string regNo)
        {
            var resultList = new List<SaveEmployee.Models.ViewResult>();
            if (regNo != null)
            {
                ResultViewManager manager = new ResultViewManager();
                resultList = manager.GetCourseInfos(regNo);
            }
            if (Request.IsAjaxRequest())
            {
                return new JsonResult
                {
                    Data = resultList,
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
            else
            {
                return new JsonResult
                {
                    Data = "Not valid request",
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
            }
        }




        public void pdf()
        {

            Document pdfDocument = new Document(PageSize.A4, 10f, 10f, 10f, 10f);
            PdfWriter.GetInstance(pdfDocument, Response.OutputStream);

           

            pdfDocument.Open();
            pdfDocument.AddHeader("Header", "Account List");
            //pdfDocument.Add(nameList);
           // pdfDocument.Add(pdfTable);
            pdfDocument.Close();

            Response.ContentType = "application/pdf";
            Response.AppendHeader("content-disposition", "attachment;filename=Official Account List.pdf");
            Response.Write(pdfDocument);
            Response.Flush();
            Response.End();


        }

    }
}
