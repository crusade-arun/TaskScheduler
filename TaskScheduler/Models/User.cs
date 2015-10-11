using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskScheduler.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "First name")]
        public string first_name { get; set; }
        [Display(Name = "Last name")]
        public string last_name { get; set; }
        [Display(Name = "Full name")]
        public string Name
        {
            get
            {
                return string.Format("{0} {1}", this.first_name, this.last_name);
            }
        }
        [Display(Name = "Username")]
        public string username { get; set; }
        [Display(Name = "Password")]
        public string password { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}