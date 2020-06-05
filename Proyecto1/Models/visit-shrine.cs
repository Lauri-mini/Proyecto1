using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.Models
{
    public class visit_shrine
    {
        public int Id { get; set; }
        public sanctuary santuario { get; set; }
        public visit visita { get; set; }
    }
}