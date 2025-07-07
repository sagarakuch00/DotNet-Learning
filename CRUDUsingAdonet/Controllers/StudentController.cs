using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;
using CRUDUsingAdonet.Models;

namespace CRUDUsingAdonet.Controllers
{
    public class StudentController : Controller
    {

        string cs;
        public StudentController()
        {
            cs = ConfigurationManager.ConnectionStrings["CRUDUsingAdonet"].ConnectionString;
        }


        // GET: Student

        [HttpGet]
        public ActionResult Index(string search)
        {
            ViewBag.search = search;

            List<Student> students = new List<Student>();

            using (SqlConnection con = new SqlConnection(cs))

            {
                con.Open();
                //string query = "select * from student where id = 1";
                //SqlCommand cmd = new SqlCommand(query, con);


                string query = "GetAllStudents";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Search", search);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    

                    while (reader.Read())
                    {
                        Student student = new Student();

                        student.id = (int)reader["id"];
                        student.Name = reader["name"].ToString();
                        student.Email = reader["email"].ToString();
                        student.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                        students.Add(student);
                    }
                   
                }
                return View(students);

            }
               
        }

        [HttpGet]

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create(Student student)
        {
      

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "InsertStudents";
                SqlCommand cmd = new SqlCommand(query, con);

                cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@id", student.id);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);

                int rowsaffected = cmd.ExecuteNonQuery();

                if (rowsaffected > 0)
                {
                    return RedirectToAction("Index");
                }
                return View(student);
            }

        }

      
        public Student GetById(int? id)
        {
            Student student = new Student();

            using (SqlConnection con = new SqlConnection(cs))
            {
                
                con. Open();

                string query = $"select id, Name, Email, Gender, DateOfBirth from student where id = {id}";

                SqlCommand cmd = new SqlCommand(query, con);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        student.id = (int)reader["id"];
                        student.Name = reader["Name"].ToString();
                        student.Email = reader["email"].ToString();
                        student.Gender = reader["Gender"].ToString();
                        student.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]);

                        break;
                    }
                }               
            }
            return student;



        }

        [HttpGet]

        public ActionResult Details(int? id)
        {
            Student student = GetById(id);
            return View(student);  
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            Student student = GetById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult Edit(Student student)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();

                string query = "UpdateStudent";
                SqlCommand cmd = new SqlCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(student);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            Student student = GetById(id);
            return View(student);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int? id)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string query = "DeleteStudent";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    return RedirectToAction("Index");
                }

            }
                return View();
        }
    }
}