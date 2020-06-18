using System;
using System.Collections.Generic;
using System.Text;

namespace TransactionPlatform.DomainLibrary.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
