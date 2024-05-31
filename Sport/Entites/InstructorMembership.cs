namespace Sport.Entites
{
    public class InstructorMembership
    {
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public int MembershipId { get; set; }
        public Membership Membership { get; set; }
    }
}
