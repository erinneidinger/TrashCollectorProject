using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationID { get; set; }
        public ApplicationUser ApplicationUser {get; set;}
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}