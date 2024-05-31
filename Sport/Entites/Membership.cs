using System.Collections.Generic;

namespace Sport.Entites
{
    public class Membership
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string GymAccessHours { get; set; }
        public string InstrumentCount { get; set; }
        public string ClassesPerWeek { get; set; }
        public string MembershipDuration { get; set; }
        public string FreeDrinkingPackage { get; set; }
        public string PersonalInstructorCount { get; set; }
        public decimal Price { get; set; }

        public ICollection<InstructorMembership> InstructorMemberships { get; set; }
    }
}
