using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Dtos;
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
       

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512()) 
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }


        }

        public  AuthoUserDto Register(AuthoUserDto authUser)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(authUser.Password, out passwordHash, out passwordSalt);

            authUser.UsersAccess.PasswordHash = passwordHash;
            authUser.UsersAccess.PasswordSalt = passwordSalt;

             context.Users.Add(authUser.User);
             context.UsersAccesses.Add(authUser.UsersAccess);
            context.SaveChanges();

            return authUser;

        }
        public async Task<UsersAccess> Login(string username, string password)
        {
            var user = await context.UsersAccesses.FirstOrDefaultAsync(x => x.Username == username); 
            if (user == null)
            {
                return null;
            }
            if (!VeryfypasswordHash(password, user.PasswordHash, user.PasswordSalt)) {
                return null;
            }
            return user;
        }

        private bool VeryfypasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using( var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[1]) return false;
                }
            }
            return true;
        }

        public async Task<bool> UserExist(string username)
        {
            if (await context.UsersAccesses.AnyAsync(x => x.Username == username))
            {
                return true;
            }
            return false;
        }

       
    }
}
