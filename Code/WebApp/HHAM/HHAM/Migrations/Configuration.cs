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
            UserProfileInfo DoctorProfile= null;
            UserProfileInfo NurseProfile = null;

            if (context.Photos.ToList().Count == 0)
            {
                context.Photos.Add(new Photo
                {
                    Name = "Scan_1",
                    DateAdded = DateAdmited,
                    DisplayURL = "https://ccr.cancer.gov/sites/default/files/hcc_clinical_trial_-_467x363_1.jpg",
                    DisplayURLProcessedImage = "https://ccr.cancer.gov/sites/default/files/hcc_clinical_trial_-_467x363_1.jpg",
                    Notes = LoremNET.Lorem.Paragraph(5, 6, 4, 10)
                });
                context.Photos.Add(new Photo
                {
                    Name = "Scan_2",
                    DateAdded = DateAdmited,
                    DisplayURL = "https://www.amberusa.com/blog/wp-content/uploads/2018/04/rp_170308_normal_ct_abdomen_800x6001.jpg",
                    DisplayURLProcessedImage = "https://www.amberusa.com/blog/wp-content/uploads/2018/04/rp_170308_normal_ct_abdomen_800x6001.jpg",
                    Notes = LoremNET.Lorem.Paragraph(5, 6, 4, 10)
                });
                context.Photos.Add(new Photo
                {
                    Name = "Scan_3",
                    DateAdded = DateAdmited,
                    DisplayURL = "https://img.medscapestatic.com/pi/meds/ckb/98/16798tn.jpg",
                    DisplayURLProcessedImage = "https://img.medscapestatic.com/pi/meds/ckb/98/16798tn.jpg",
                    Notes = LoremNET.Lorem.Paragraph(5, 6, 4, 10)
                });
                context.Photos.Add(new Photo
                {
                    Name = "Scan_4",
                    DateAdded = DateAdmited,
                    DisplayURL = "https://www.radiology.vcu.edu/images/photos/Lung%20Cancer%20CT%20Scan_Web.jpg",
                    DisplayURLProcessedImage = "https://www.radiology.vcu.edu/images/photos/Lung%20Cancer%20CT%20Scan_Web.jpg",
                    Notes = LoremNET.Lorem.Paragraph(5, 6, 4, 10)
                });
            }

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
                    UserName = "ava345@gmail.com",
                    Email = "ava345@gmail.com"
                };

                string AdminUserPWD = "mehMeh123)";

                var AdminUserCreationStatus = UserManager.Create(AdminUser, AdminUserPWD);

                if (AdminUserCreationStatus.Succeeded)
                {
                    var result = UserManager.AddToRole(AdminUser.Id, "Admin");
                }

                context.UserProfileInfo.Add(new UserProfileInfo
                {
                    Description = "I am an ADMIN !!! YAY ME",
                    Name = "Nancy Cook",
                    Role = "Doctor",
                    User = AdminUser,
                    UrlProfilePicture = "https://randomuser.me/api/portraits/women/83.jpg",
                });


                // Doctor

                var DoctorUser = new ApplicationUser
                {
                    UserName = "Jenny.Wang@gmail.com",
                    Email = "Jenny.Wang@gmail.com"
                };

                string DoctorUserPWD = "YOLo123)";

                var DoctorUserCreationStatus = UserManager.Create(DoctorUser, DoctorUserPWD);

                if (DoctorUserCreationStatus.Succeeded)
                {
                    var result = UserManager.AddToRole(DoctorUser.Id, "Doctor");
                }

                DoctorProfile = context.UserProfileInfo.Add(new UserProfileInfo
                {
                    Description = "I am an Doctor !!! YAY ME",
                    Role = "Doctor",
                    User = DoctorUser,
                    Name = "Jenny Wang",
                    UrlProfilePicture = "https://randomuser.me/api/portraits/women/90.jpg",
                });

                // Nurse

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
                    Name = "Max Tucker",
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
                //List<UserProfileInfo> temp = new List<UserProfileInfo>();
                //temp.Add(NurseProfile);
                //temp.Add(DoctorProfile);
                for (int i = 0; i < 50; i++)
                {

                    if(i % 2 == 0)
                    {


                        context.Patient.Add(new Models.Patient
                        {
                            FirstName = personGenerator.GenerateRandomFirstName(),
                            LastName = personGenerator.GenerateRandomLastName(),
                            Age = gen.Next(26, 80),
                            PatientNumber = Guid.NewGuid().ToString(),
                            Weight = gen.Next(120,205),
                            Height = gen.Next(100,200),
                            Gender = context.Genders.Where(x => x.Text == "Other").FirstOrDefault(),
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
                            Age = gen.Next(26, 80),
                            PatientNumber = Guid.NewGuid().ToString(),
                            Weight = gen.Next(120, 205),
                            Height = gen.Next(100, 200),
                            Gender = context.Genders.Where(x => x.Text == "Other").FirstOrDefault(),
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
            context.SaveChanges();
        }

        DateTime RandomDay()
        {
            DateTime start = new DateTime(1993, 3, 7);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }
    }
}
