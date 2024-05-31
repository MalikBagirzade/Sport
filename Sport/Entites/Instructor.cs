using System.Collections.Generic;

namespace Sport.Entites
{
    public class Instructor
    {
        public int Id { get; set; }
        public string PhotoUrl { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public string Specialty { get; set; }
        public string FacebookUrl { get; set; }
        public string PhoneNumber { get; set; }
        public string InstagramUrl { get; set; }
        public string LinkedinUrl { get; set; }

        public ICollection<InstructorMembership> InstructorMemberships { get; set; } 
    }
}
