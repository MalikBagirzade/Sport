
using Sport.Entites;
using Sport.Models;

namespace Sport.IRespoitory
{
    public interface IUserRepository
    {
        User? Login(Login req);

        Task Signin(User req);

        User? GetUser(User req);

    }
}
