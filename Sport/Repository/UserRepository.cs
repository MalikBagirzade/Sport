using Entites.Models;
using Sport.Entites;
using Sport.IRespoitory;
using Sport.Models;

namespace Sport.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Login(Login req)
        {
            return _context.Users.Where(mm=>mm.Password.Equals(req.Password)&&mm.UserName.Equals(req.UserName)).Any();
        }

        public async Task Signin(User req)
        {
            await  _context.Users.AddAsync(req);
            await _context.SaveChangesAsync ();
        }
    }
}
