using Microsoft.EntityFrameworkCore;
using Sport.Entites;
using Sport.IRespoitory;
using System.Collections.Generic;
using System.Linq;

namespace Sport.Repository
{
    public class MembershipRepository : IMembershipRepository
    {
        private readonly AppDbContext _context;

        public MembershipRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Membership> GetAllMemberships()
        {
            return _context.Memberships.ToList();
        }

        public Membership GetMembershipById(int id)
        {
            return _context.Memberships.Find(id);
        }

        public void AddMembership(Membership membership)
        {
            _context.Memberships.Add(membership);
            _context.SaveChanges();
        }

        public void UpdateMembership(Membership membership)
        {
            _context.Entry(membership).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMembership(int id)
        {
            Membership membership = _context.Memberships.Find(id);
            if (membership != null)
            {
                _context.Memberships.Remove(membership);
                _context.SaveChanges();
            }
        }
    }
}
