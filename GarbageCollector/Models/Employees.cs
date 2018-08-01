using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GarbageCollector.Models
{
    public class Employees
    {
        [ForeignKey("")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        [Key]
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ZipCode { get; set; }
        public bool WeeklyisPickedUp { get; set; }
        public bool OneTimeisPickedUp { get; set; }
    }
}