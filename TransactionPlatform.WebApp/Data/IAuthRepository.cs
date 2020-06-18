using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.WebApp.Data
{
    public interface IAuthRepository {

        Task<User> Register(User user, string password);
        Task<User> Login(string username, string passeord);
        Task<bool> UserExist(string username);

    }

}
