using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Dtos;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.WebApp.Data
{
    public interface IAuthRepository {


        AuthoUserDto Register(AuthoUserDto authoUser);
        Task<UsersAccess> Login(string username, string password);
        Task<bool> UserExist(string username);
    }

}
