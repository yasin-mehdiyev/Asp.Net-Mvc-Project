using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medway_Pratice.Models
{
    public class vwBlog
    {
        public List<Dates> Dates { get; set; }
        public int SelectedMonth { get; set; }
        public int SelecetedYear { get; set; }
        public List<Blog> Blogs { get; set; }
    }

    public class Dates
    {
        public int Month { get; set; }
        public int Year { get; set; }
    }
}