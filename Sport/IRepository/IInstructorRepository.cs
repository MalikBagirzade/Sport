using Sport.Entites;
using System.Collections.Generic;

namespace Sport.IRespoitory
{
    public interface IInstructorRepository
    {
        IEnumerable<Instructor> GetAllInstructors();
        Instructor GetInstructorById(int id);
        void AddInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
        void DeleteInstructor(int id);
    }
}
