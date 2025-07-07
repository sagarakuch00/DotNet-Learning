using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using secondDbFirstMvc.Models;

namespace secondDbFirstMvc.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> students = new List<Student>();
            ADONETDBEntities dbContext = new ADONETDBEntities();

            students = dbContext.Students.ToList();
            
            return View(students);
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                ADONETDBEntities dbcontext = new ADONETDBEntities();
                dbcontext.Students.Add(student);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(student);
            }
        }

        [HttpGet]
        
        public ActionResult Details(int? id)
        {
            ADONETDBEntities dbContext = new ADONETDBEntities();
            Student student = dbContext.Students.SingleOrDefault(c => c.id == id);

            return View(student);
        }


        [HttpGet]

        public ActionResult Edit(int? id)
        {
            ADONETDBEntities dbContext = new ADONETDBEntities();
            Student student = dbContext.Students.SingleOrDefault(c => c.id == id);
            return View(student);
        }

        [HttpPost]

        public ActionResult Edit(Student student)
        {
            try
            {
                ADONETDBEntities dbContext = new ADONETDBEntities();
                dbContext.Entry(student).State = EntityState.Modified;
                dbContext.SaveChanges();
                return RedirectToAction("Index");   
            }
            catch
            {
                return View(student);
            }
        }

        [HttpGet]

        public ActionResult Delete(int id)
        {
            ADONETDBEntities dbContext = new ADONETDBEntities();
            Student student = dbContext.Students.FirstOrDefault(c => c.id == id);
            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]

        public ActionResult ConfirmDelete(Student student)
        {
            try
            {
                ADONETDBEntities dbContext = new ADONETDBEntities();
                dbContext.Students.Remove(student);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(student);
            }
        }
    }
}