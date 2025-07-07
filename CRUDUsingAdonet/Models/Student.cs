using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDUsingAdonet.Models
{
    public class Student
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}