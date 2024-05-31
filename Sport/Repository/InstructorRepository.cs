using Microsoft.EntityFrameworkCore;
using Sport.Entites;
using Sport.IRespoitory;
using System.Collections.Generic;
using System.Linq;

namespace Sport.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _context;

        public InstructorRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Instructor> GetAllInstructors()
        {
            return _context.Instructors.ToList();
        }

        public Instructor GetInstructorById(int id)
        {
            return _context.Instructors.Find(id);
        }

        public void AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
        }

        public void UpdateInstructor(Instructor instructor)
        {
            _context.Entry(instructor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteInstructor(int id)
        {
            Instructor instructor = _context.Instructors.Find(id);
            if (instructor != null)
            {
                _context.Instructors.Remove(instructor);
                _context.SaveChanges();
            }
        }
    }
}
