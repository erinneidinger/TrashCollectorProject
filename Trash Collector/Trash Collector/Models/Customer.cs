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
        [Display(Name = "Customer Id")]
        public int CustomerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Pickup Time")]
        public string PickUpDay { get; set; }
        [Display(Name = "Street Address")]
        public string StreetAddress { get; set; }
        
        public string City { get; set; }
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }
        [Display(Name = "Extra Pickup Date")]
        public string ExtraPickUpDate { get; set; }
        [Display(Name= "Balance Due ($)")]
        public double Balance { get; set; }
        [Display(Name = "Suspended Start")]
        public string SuspendedStart { get; set; }
        [Display(Name = "Suspected End")]
        public string SuspectedEnd { get; set; }
        [Display(Name = "Pickup Confirmation")]
        public bool PickupConfirmation { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public IEnumerable<ApplicationUser> ApplicationUsers {get; set;}
    }
}