using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medway_Pratice.Models;

namespace Medway_Pratice.Models
{
    public class vwHome
    {
        public List<Slider> Sliders { get; set; }
        public List<Service> Services { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Feature> Features { get; set; }
    }
}