using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Medway_Pratice.Models;

namespace Medway_Pratice.Models
{
    public class vwRequest
    {
        public List<Request> requests { get; set; }
        public Request Date { get; set; }
    }
}