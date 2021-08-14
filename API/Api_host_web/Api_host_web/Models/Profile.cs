using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_host_web.Models
{
    public class Profile
    {
        public int id { get; set; }
        public string post { get; set; }
        public DateTime datetimepost { get; set; }
        public bool like_post { get; set; }
        public int like_post_count { get; set; }
        public string edit_post { get; set; }
        public int edit_post_count { get; set; }
        public int User_id { get; set; }
    }
}