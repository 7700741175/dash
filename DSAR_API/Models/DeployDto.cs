using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dash_API.Models
{
    public class DeployDto
    {
        public string number { get; set; }
        public string version { get; set; }
        public string dir { get; set; }
        public string nexus_url { get; set; }
        public string date { get; set; }
        public string init_date { get; set; }
        public string last_change_date { get; set; }
        public string status { get; set; }
    }
}