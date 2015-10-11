using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskScheduler.Models
{
    public class User
    {
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string role { get; set; }
    }
}