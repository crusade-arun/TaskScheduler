using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TaskScheduler.Models
{
    public class Project
    {
        public int id { get; set; }

        [Display(Name="Project name")]
        public string name { get; set; }

        [Display(Name = "Project description")]
        public string projectDesc { get; set; }

        [Display(Name = "Assigned to")]
        public string assignedTo { get; set; }

        [Display(Name = "Start date")]
        public string startDate { get; set; }
        
        [Display(Name = "End date")]
        public string endDate { get; set; }

        [Display(Name = "Project status")]
        public int status { get; set; }
    }
}