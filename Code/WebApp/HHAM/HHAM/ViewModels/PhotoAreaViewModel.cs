using HHAM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHAM.ViewModels
{
    public class PhotoAreaViewModel
    {
        public ICollection<Photo> Scans { get; set; }
    }
}