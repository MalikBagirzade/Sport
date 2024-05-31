
using Microsoft.EntityFrameworkCore;

namespace Sport.Entites
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Composite Key Definition for InstructorMembership
            modelBuilder.Entity<InstructorMembership>().HasKey(tc => new
            {
                tc.InstructorId,
                tc.MembershipId
            });

            // Relationships between InstructorMembership, Membership, and Instructor
            modelBuilder.Entity<InstructorMembership>()
                .HasOne(tc => tc.Membership)
                .WithMany(c => c.InstructorMemberships)
                .HasForeignKey(tc => tc.MembershipId);

            modelBuilder.Entity<InstructorMembership>()
                .HasOne(tc => tc.Instructor)
                .WithMany(t => t.InstructorMemberships)
                .HasForeignKey(tc => tc.InstructorId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }

        public DbSet<GateShapeProduct> GateShapeProducts { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<InstructorMembership> InstructorMemberships { get; set; }
    }
}
