using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace firstMvcProjectAssignment.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        [HttpGet]

        public ActionResult Index()
        {
            StudentDbContext dbContext = new StudentDbContext();
            var students = dbContext.Students.ToList();
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
                StudentDbContext dbContext = new StudentDbContext();
                dbContext.Students.Add(student);
                dbContext.SaveChanges();  
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
            StudentDbContext dbContext = new StudentDbContext();
            Student student = dbContext.Students.FirstOrDefault(c => c.id == id);
            return View(student);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            StudentDbContext dbContext = new StudentDbContext();
            Student student = dbContext.Students.FirstOrDefault(c => c.id == id);
            return View(student);         
        }

        [HttpPost]

        public ActionResult Edit(Student student)
        {
            try
            {
                StudentDbContext dbContext = new StudentDbContext();
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
        public ActionResult Delete(int? id)
        {
            StudentDbContext dbContext = new StudentDbContext();
            Student student = dbContext.Students.FirstOrDefault(c => c.id == id);
            return View(student);           
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(Student student)
        {
            try
            {
                StudentDbContext dbContext = new StudentDbContext();
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