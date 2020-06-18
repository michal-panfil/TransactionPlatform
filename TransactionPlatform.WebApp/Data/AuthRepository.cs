using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.WebApp.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly TransactionContext context;

        public AuthRepository(TransactionContext context)
        {
            this.context = context;
        }
        public Task<User> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) 
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }


        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var userAccess = new UsersAccess()
            {
                Username = user.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            await context.Users.AddAsync(user);
            await context.UsersAccesses.AddAsync(userAccess);
            context.SaveChanges();

            return user;

        }

        public Task<bool> UserExist(string username)
        {
            throw new NotImplementedException();
        }
    }
}
