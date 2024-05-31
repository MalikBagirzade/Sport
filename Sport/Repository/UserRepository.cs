
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

        public User? Login(Login req)
        {
            return _context.Users.FirstOrDefault(mm=>mm.Password.Equals(req.Password)&&mm.UserName.Equals(req.UserName));
        }

        public async Task Signin(User req)
        {            
            await  _context.Users.AddAsync(req);
           _context.SaveChanges ();
        }

        public User? GetUser(User req)
        {
            return _context.Users.FirstOrDefault(mm => mm.Email.Equals(req.Email) || mm.UserName.Equals(req.UserName));
        }
    }
}
