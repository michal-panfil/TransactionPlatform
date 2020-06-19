using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.WebApp.Data
{
    public interface IAuthRepository {

        Task<User> Register(User user, string password);
        Task<UsersAccess> Login(string username, string password);
        Task<bool> UserExist(string username);

    }

}
