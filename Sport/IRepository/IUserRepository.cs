using Entites.Models;
using Sport.Models;

namespace Sport.IRespoitory
{
    public interface IUserRepository
    {
        bool Login(Login req);

        Task Signin(User req);

    }
}
