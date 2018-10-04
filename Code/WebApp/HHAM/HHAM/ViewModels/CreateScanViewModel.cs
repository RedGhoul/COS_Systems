using MultipartDataMediaFormatter.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHAM.ViewModels
{
    public class CreateScanViewModel
    {
        public int Id { get; set; }
        public string PatientNumber { set; get; }
        public HttpPostedFileBase file { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public string Notes { get; set; }
    }
}