using HHAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHAM.ViewModels
{
    public class ScansAreaViewModel
    {
        public ICollection<Scan> Scans { get; set; }
        public Patient Patient { get; set; }
    }
}