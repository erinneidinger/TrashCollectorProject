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
        [Display(Name = "Employee Id")]
        public int EmployeeId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationID { get; set; }
        public ApplicationUser ApplicationUser {get; set;}
        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }

        [NotMapped]
        public string DaysOfTheWeek { get; set; }
    }
}