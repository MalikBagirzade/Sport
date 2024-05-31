using Microsoft.AspNetCore.Mvc;
using Sport.Entites;
using Sport.IRespoitory;


namespace Sport.Controllers
{
    public class InstructorController : Controller
    {
        private readonly IInstructorRepository _instructorService;

        public InstructorController(IInstructorRepository instructorService)
        {
            _instructorService = instructorService;
        }

        // GET: Instructor
        public IActionResult Index()
        {
            return View(_instructorService.GetAllInstructors());
        }

        // GET: Instructor/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Instructor instructor = _instructorService.GetInstructorById(id.Value);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // GET: Instructor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instructor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,PhotoUrl,FullName,Bio,Specialty,FacebookUrl,PhoneNumber,InstagramUrl,LinkedinUrl")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _instructorService.AddInstructor(instructor);
                return RedirectToAction(nameof(Index));
            }

            return View(instructor);
        }

        // GET: Instructor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Instructor instructor = _instructorService.GetInstructorById(id.Value);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,PhotoUrl,FullName,Bio,Specialty,FacebookUrl,PhoneNumber,InstagramUrl,LinkedinUrl")] Instructor instructor)
        {
            if (id != instructor.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _instructorService.UpdateInstructor(instructor);
                return RedirectToAction(nameof(Index));
            }

            return View(instructor);
        }

        // GET: Instructor/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Instructor instructor = _instructorService.GetInstructorById(id.Value);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _instructorService.DeleteInstructor(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
