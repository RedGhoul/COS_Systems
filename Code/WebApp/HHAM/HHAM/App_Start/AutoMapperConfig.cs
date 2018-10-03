using AutoMapper;
using HHAM.DataTransferObjects;
using HHAM.Models;
using HHAM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HHAM.App_Start
{
    public class AutoMapperConfig : Profile 
    {
        public AutoMapperConfig()
        {
            CreateMap<Patient, PatientProfileViewModel>();
            CreateMap<Patient, CreatePatientViewModel>();
            CreateMap<Patient, PatientDto>();

            CreateMap<Scan, ScanDto>();
            CreateMap<Scan, CreateScanViewModel>();


            CreateMap<CreatePatientViewModel, Patient>();
            CreateMap<PatientDto, Patient>();
            CreateMap<ScanDto, Scan>();
            CreateMap<CreateScanViewModel, Scan>();
        }
    }
}