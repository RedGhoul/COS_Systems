namespace HHAM.Migrations
{
    using HHAM.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using RandomNameGeneratorLibrary;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HHAM.Models.ApplicationDbContext>
    {
        private Random gen = new Random();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HHAM.Models.ApplicationDbContext";
        }

        protected override void Seed(HHAM.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var personGenerator = new PersonNameGenerator();
            var placeGenerator = new PlaceNameGenerator();
            
            DateTime DateAdmited = RandomDay();
            UserProfileInfo NurseProfile = null;

            if (context.Roles.ToList().Count == 0)
            {
                roleManager.Create(new IdentityRole
                {
                    Name = "Admin"
                });

                roleManager.Create(new IdentityRole
                {
                    Name = "Doctor"
                });

                roleManager.Create(new IdentityRole
                {
                    Name = "Nurse"
                });

                var AdminUser = new ApplicationUser
                {
                    UserName = "avaneesab5@gmail.com",
                    Email = "avaneesab5@gmail.com"
                };

                string AdminUserPWD = "DietForCoke123)";

                var AdminUserCreationStatus = UserManager.Create(AdminUser, AdminUserPWD);

                if (AdminUserCreationStatus.Succeeded)
                {
                    var result = UserManager.AddToRole(AdminUser.Id, "Admin");
                }

                context.UserProfileInfo.Add(new UserProfileInfo
                {
                    Description = "I am an ADMIN",
                    FirstName = "Nancy",
                    LastName = "Cook",
                    Role = "Admin",
                    User = AdminUser,
                    UrlProfilePicture = "https://randomuser.me/api/portraits/women/64.jpg",
                });


                // Doctor Users
                CreateDoctorUser(context, UserManager, "mirna.jegatheeswaran@uoit.net", "YOLo123)","Mirna", "Jegatheeswaran","64");
                CreateDoctorUser(context, UserManager, "harminder.paink@uoit.net", "YOLo1234)", "Harminder", "Paink", "64");
                CreateDoctorUser(context, UserManager, "huda.sarwar@uoit.net", "YOLo1235)", "Huda", "Sarwar", "64");
                CreateDoctorUser(context, UserManager, "jing.ren@uoit.ca", "YOLo1236)", "Jing", "Ren", "64");
                
                // Nurse User

                var NurseUser = new ApplicationUser
                {
                    UserName = "Max.Tucker@gmail.com",
                    Email = "Max.Tucker@gmail.com"
                };

                string NurseUserPWD = "YOLo1234)";

                var NurseUserCreationStatus = UserManager.Create(NurseUser, NurseUserPWD);

                if (NurseUserCreationStatus.Succeeded)
                {
                    var result = UserManager.AddToRole(NurseUser.Id, "Nurse");
                }

                NurseProfile = context.UserProfileInfo.Add(new UserProfileInfo
                {
                    Description = "I am a Nurse !!! YAY ME",
                    User = NurseUser,
                    Role = "Nusre",
                    FirstName = "Max",
                    LastName = "Tucker",
                    UrlProfilePicture = "https://randomuser.me/api/portraits/men/21.jpg",
                });


            }


            // added all the blood types
            if (context.BloodTypes.ToList().Count == 0)
            {
                context.BloodTypes.Add(new Models.BloodType
                {
                    Value = "AB - Negative",
                    Text = "AB - Negative"
                });
                context.BloodTypes.Add(new Models.BloodType
                {
                    Value = "B - Negative",
                    Text = "B - Negative"
                });
                context.BloodTypes.Add(new Models.BloodType
                {
                    Value = "AB - Postive",
                    Text = "AB - Postive"
                });
                context.BloodTypes.Add(new Models.BloodType
                {
                    Value = "A - Negative",
                    Text = "A - Negative"
                });
                context.BloodTypes.Add(new Models.BloodType
                {
                    Value = "O - Negative",
                    Text = "O - Negative"
                });
                context.BloodTypes.Add(new Models.BloodType
                {
                    Value = "B - Postive",
                    Text = "B - Postive"
                });
                context.BloodTypes.Add(new Models.BloodType
                {
                    Value = "A - Postive",
                    Text = "A - Postive"
                });
                context.BloodTypes.Add(new Models.BloodType
                {
                    Value = "O - Postive",
                    Text = "O - Postive"
                });
            }

            // added gender Types
            if (context.Genders.ToList().Count == 0)
            {
                context.Genders.Add(new Models.Gender
                {
                    Value = "Male",
                    Text = "Male"
                });
                context.Genders.Add(new Models.Gender
                {
                    Value = "Female",
                    Text = "Female"
                });
                context.Genders.Add(new Models.Gender
                {
                    Value = "Other",
                    Text = "Other"
                });
            }

            if (context.Patient.ToList().Count == 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if(i % 2 == 0)
                    {
                        context.Patient.Add(new Models.Patient
                        {
                            FirstName = personGenerator.GenerateRandomFirstName(),
                            LastName = personGenerator.GenerateRandomLastName(),
                            BirthDate = RandomDay(),
                            patientNumber = Guid.NewGuid().ToString(),
                            Weight = gen.Next(120,205),
                            Height = gen.Next(100,200),
                            Gender = context.Genders.Where(x => x.Text == "Male").FirstOrDefault(),
                            DateAdmited = DateAdmited,
                            DateReleased = DateAdmited.AddDays(20),
                            Notes = LoremNET.Lorem.Paragraph(5, 6, 4, 10),
                            Married = false,
                            PrimaryAddress = placeGenerator.GenerateRandomPlaceName() + "Street",
                            SecondaryAddress = placeGenerator.GenerateRandomPlaceName() + "Street",
                            BloodType = context.BloodTypes.FirstOrDefault(),
                            CareGivers = context.UserProfileInfo.ToList()

                        });
                    } else
                    {
                        context.Patient.Add(new Models.Patient
                        {
                            FirstName = personGenerator.GenerateRandomFirstName(),
                            LastName = personGenerator.GenerateRandomLastName(),
                            BirthDate = RandomDay(),
                            patientNumber = Guid.NewGuid().ToString(),
                            Weight = gen.Next(120, 205),
                            Height = gen.Next(100, 200),
                            Gender = context.Genders.Where(x => x.Text == "Female").FirstOrDefault(),
                            DateAdmited = DateAdmited,
                            DateReleased = DateAdmited.AddDays(20),
                            Notes = LoremNET.Lorem.Paragraph(5, 6, 4, 10),
                            Married = true,
                            PrimaryAddress = placeGenerator.GenerateRandomPlaceName() + "Street",
                            SecondaryAddress = placeGenerator.GenerateRandomPlaceName() + "Street",
                            BloodType = context.BloodTypes.FirstOrDefault(),
                            CareGivers = context.UserProfileInfo.ToList()
                        });
                    }
                    
                }
                
            }

            if (context.Scans.ToList().Count == 0)
            {
                foreach (var patient in context.Patient.ToList())
                {
                    for (int i = 0; i < 6; i++)
                    {
                        context.Scans.Add(CreateRandScan(patient.patientNumber, i, DateAdmited, patient));
                        
                    }
                }
            }

            context.SaveChanges();
        }

        private void CreateDoctorUser(ApplicationDbContext context, UserManager<ApplicationUser> UserManager, string UserName, string Password,string firstName, string lastName, string picNum)
        {
            UserProfileInfo DoctorProfile;
            var DoctorUser = new ApplicationUser
            {
                UserName = UserName,
                Email = UserName
            };

            string DoctorUserPWD = Password; // "YOLo123)";

            var DoctorUserCreationStatus = UserManager.Create(DoctorUser, DoctorUserPWD);

            if (DoctorUserCreationStatus.Succeeded)
            {
                var result = UserManager.AddToRole(DoctorUser.Id, "Doctor");
            }

            DoctorProfile = context.UserProfileInfo.Add(new UserProfileInfo
            {
                Description = "I am an Doctor",
                Role = "Doctor",
                User = DoctorUser,
                FirstName = firstName,
                LastName = lastName,
                UrlProfilePicture = "https://randomuser.me/api/portraits/women/" + picNum +".jpg",
            });
        }

        DateTime RandomDay()
        {
            DateTime start = new DateTime(1993, 3, 7);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        Scan CreateRandScan(string PatientNumber, int scanNumber, DateTime DateAdded, Patient P_A_W)
        {
            return new Scan
            {
                Name = "Scan_" + scanNumber + PatientNumber,
                DateAdded = DateAdded,
                RAW_URL = "https://ccr.cancer.gov/sites/default/files/hcc_clinical_trial_-_467x363_1.jpg",
                RAW_URLProcessed = "https://ccr.cancer.gov/sites/default/files/hcc_clinical_trial_-_467x363_1.jpg",
                Notes = LoremNET.Lorem.Paragraph(5, 6, 4, 10),
                PatientAssociatedWith = P_A_W
            };
        }
    }
}
