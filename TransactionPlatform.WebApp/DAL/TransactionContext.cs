using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.WebApp.Models;

namespace TransactionPlatform.WebApp.Data
{
    public class TransactionContext : IdentityDbContext<ApplicationUser>
    {

        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options){ }
        
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<UsersAccess> UsersAccesses { get; set; }
        public DbSet<User> Users { get; set;}

}
}
