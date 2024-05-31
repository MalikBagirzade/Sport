using Sport.Entites;

namespace Sport.Entites
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                if (!context.GateShapeProducts.Any())
                {
                    context.GateShapeProducts.AddRange(new List<GateShapeProduct>()
                    {
                        new GateShapeProduct
                        {
                            PhotoUrl = "https://contents.mediadecathlon.com/p1811219/k$6f1825f61117c52fa1794647df3857fe/sq/73729ffb-f4e8-4428-85c9-29443bc48ed5.jpg?format=auto&f=800x0",
                            Name = "Sneakers",
                            Description = "Comfortable and durable sneakers",
                            Price = 89.99m,
                            Stock = 100
                        },
                        new GateShapeProduct
                        {
                            PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ0KZO3qQ7mv549mbgkrkbrEBTwSTEafbWZig&s",
                            Name = "Sports Shorts",
                            Description = "Sports shorts made of stretchy fabric",
                            Price = 29.99m,
                            Stock = 50
                        },
                        new GateShapeProduct
                        {
                            PhotoUrl = "https://productimages.hepsiburada.net/s/263/375-375/110000248106713.jpg",
                            Name = "Hand Dumble",
                            Description = "This is description",
                            Price = 39.99m,
                            Stock = 30
                        }
                    });
                    context.SaveChanges();
                }


                if (!context.Memberships.Any())
                {
                    context.Memberships.AddRange(new List<Membership>()
                    {
                        new Membership
                        {
                            PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSh5NiUMmOqhg_vi4xfcvr3vrNfHg6bcTm66w&s",
                            Name = "Gold Membership",
                            Description = "Access to all facilities",
                            GymAccessHours = "24/7",
                            InstrumentCount = "10",
                            ClassesPerWeek = "5",
                            MembershipDuration = "1 year",
                            FreeDrinkingPackage = "Yes",
                            PersonalInstructorCount = "2",
                            Price = 99.99m
                        },
                        new Membership
                        {
                            PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRDGiF7_mYTy-I4Ucjl2xm1VoLd4jhHJKc6Sw&s",
                            Name = "Silver Membership",
                            Description = "Access to gym only",
                            GymAccessHours = "8am - 10pm",
                            InstrumentCount = "5",
                            ClassesPerWeek = "3",
                            MembershipDuration = "6 months",
                            FreeDrinkingPackage = "No",
                            PersonalInstructorCount = "1",
                            Price = 59.99m
                        }
                    });

                    context.SaveChanges();
                }

                if (!context.Instructors.Any())
                {
                    context.Instructors.AddRange(new List<Instructor>()
                    {
                        new Instructor
                        {
                            PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQufu8fgBuRY7YRxzTA3l7Pvx0xU1l2wKSJFQ&s",
                            FullName = "John Doe",
                            Bio = "Experienced fitness trainer",
                            Specialty = "Weight training",
                            FacebookUrl = "https://facebook.com/johndoe",
                            PhoneNumber = "+1234567890",
                            InstagramUrl = "https://instagram.com/johndoe",
                            LinkedinUrl = "https://linkedin.com/in/johndoe"
                        },
                        new Instructor
                        {
                            PhotoUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSDgUIpf_DSPIxihxwUM7eTP8Mk2sBvkQG27w&s",
                            FullName = "Jane Smith",
                            Bio = "Certified yoga instructor",
                            Specialty = "Yoga",
                            FacebookUrl = "https://facebook.com/janesmith",
                            PhoneNumber = "+1987654321",
                            InstagramUrl = "https://instagram.com/janesmith",
                            LinkedinUrl = "https://linkedin.com/in/janesmith"
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.InstructorMemberships.Any())
                {
                    context.InstructorMemberships.AddRange(new List<InstructorMembership>()
                    {
                        new InstructorMembership
                        {
                            InstructorId = 1,
                            MembershipId = 1
                        },
                        new InstructorMembership
                        {
                            InstructorId = 2,
                            MembershipId = 1
                        },
                        new InstructorMembership
                        {
                            InstructorId = 2,
                            MembershipId = 2
                        }
                    });
                    context.SaveChanges();
                }
            }
        }
    }
}
