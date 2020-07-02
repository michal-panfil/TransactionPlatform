using System;
using System.Collections.Generic;
using System.Text;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.DomainLibrary.Dtos
{
    public class AuthoUserDto
    {
        public User User { get; set; }
        public UsersAccess UsersAccess { get; set; }
        public string Password { get; set; }

    }
}
