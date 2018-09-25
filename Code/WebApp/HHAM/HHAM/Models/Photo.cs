using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHAM.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string DisplayURL { get; set; }
        public string DisplayURLProcessedImage { get; set; }
        public string Notes { get; set; }
    }
}