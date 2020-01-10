using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Trash_Collector.Models
{
    public class FilterViewModel
    {

        public string WeekDay { get; set; }
        public SelectList DaysOfTheWeek { get; set; }
        public List<Customer> Customers { get; set; }
    }
}