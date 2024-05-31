using Microsoft.AspNetCore.Mvc;
using Sport.Entites;
using Sport.IRespoitory;


namespace Sport.Controllers
{
    public class MembershipController : Controller
    {
        private readonly IMembershipRepository _membershipService;

        public MembershipController(IMembershipRepository membershipService)
        {
            _membershipService = membershipService;
        }

        // GET: Membership
        public IActionResult Index()
        {
            return View(_membershipService.GetAllMemberships());
        }

        // GET: Membership/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Membership membership = _membershipService.GetMembershipById(id.Value);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // GET: Membership/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Membership/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,PhotoUrl,Name,Description,GymAccessHours,InstrumentCount,ClassesPerWeek,MembershipDuration,FreeDrinkingPackage,PersonalInstructorCount,Price")] Membership membership)
        {
            if (ModelState.IsValid)
            {
                _membershipService.AddMembership(membership);
                return RedirectToAction(nameof(Index));
            }

            return View(membership);
        }

        // GET: Membership/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Membership membership = _membershipService.GetMembershipById(id.Value);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // POST: Membership/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,PhotoUrl,Name,Description,GymAccessHours,InstrumentCount,ClassesPerWeek,MembershipDuration,FreeDrinkingPackage,PersonalInstructorCount,Price")] Membership membership)
        {
            if (id != membership.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _membershipService.UpdateMembership(membership);
                return RedirectToAction(nameof(Index));
            }

            return View(membership);
        }

        // GET: Membership/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Membership membership = _membershipService.GetMembershipById(id.Value);
            if (membership == null)
            {
                return NotFound();
            }

            return View(membership);
        }

        // POST: Membership/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _membershipService.DeleteMembership(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
