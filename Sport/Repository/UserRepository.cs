using Sport.IRespoitory;
using Sport.Models;

namespace Sport.Repository
{
    public class UserRepository:IUserRepository
    {
        static List<Login> logins = new List<Login>()
        {
            new Login() {UserName="melik",Password="aaaa"}
        };

        public bool Login(Login req)
        {
            return logins.Where(mm=>mm.Password.Equals(req.Password)&&mm.UserName.Equals(req.UserName)).Any();
        }
    }
}
