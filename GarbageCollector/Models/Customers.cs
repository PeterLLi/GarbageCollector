using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GarbageCollector.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string WeeklyPickUpDate { get; set; }
        public string OneTimePickUpDate { get; set; }
        [DisplayName("Exclusion Date Start")]
        [DataType(DataType.Date)]
        public DateTime? DateExclusionStart { get; set; }
        [DisplayName("Exclusion Date End")]
        [DataType(DataType.Date)]
        public DateTime? DateExclusionEnd { get; set; }
        
        public double? CurrentBill { get; set; }
        public bool WeeklyisPickedUp { get; set; }
        public bool OneTimeisPickedUp { get; set; }

        //public static MvcHtmlString YesNo(this HtmlHelper htmlHelper, bool yesNo)
        //{
        //    var text = yesNo ? "Yes" : "No";
        //    return new MvcHtmlString(text);
        //}
    }
    
}