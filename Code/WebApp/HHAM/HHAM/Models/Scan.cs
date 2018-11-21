using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHAM.Models
{
    public class Scan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string RAW_URLProcessed { get; set; }
        public string RAW_URL { get; set; }
        public string Notes { get; set; }
        public Patient PatientAssociatedWith { get; set; }
    }
}