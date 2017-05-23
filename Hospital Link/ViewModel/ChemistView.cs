using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hospital_Link.Models;

namespace Hospital_Link.ViewModel
{
    public class ChemistView
    {
        public Patient patient { get; set; }
        public Record record { get; set; }
        public Doctor doctor { get; set; }
    }
}