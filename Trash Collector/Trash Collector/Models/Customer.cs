using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Trash_Collector.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DayOfWeek PickUpDay { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public DateTime ExtraPickUpDate { get; set; }
        public double Balance { get; set; }
        public DateTime SuspendedStart { get; set; }
        public DateTime SuspectedEnd { get; set; }
        public string PickupConfirmation { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUsers {get; set;}
    }
}