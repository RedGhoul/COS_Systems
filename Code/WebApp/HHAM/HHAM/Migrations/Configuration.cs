namespace HHAM.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HHAM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "HHAM.Models.ApplicationDbContext";
        }

        protected override void Seed(HHAM.Models.ApplicationDbContext context)
        {
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
        }
    }
}
