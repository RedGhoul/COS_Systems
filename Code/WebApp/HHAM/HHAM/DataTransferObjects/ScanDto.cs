using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHAM.DataTransferObjects
{
    public class ScanDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string ScanURL { get; set; }
        public string ScanURLProcessed { get; set; }
        public string DICOM_URL { get; set; }
        public string Notes { get; set; }
    }
}