using Sport.Entites;
using System.Collections.Generic;

namespace Sport.IRespoitory
{
    public interface IMembershipRepository
    {
        IEnumerable<Membership> GetAllMemberships();
        Membership GetMembershipById(int id);
        void AddMembership(Membership membership);
        void UpdateMembership(Membership membership);
        void DeleteMembership(int id);
    }
}
