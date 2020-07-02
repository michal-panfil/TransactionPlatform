using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;
using TransactionPlatform.DomainLibrary.Models.WalletModels;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TransactionPlatform.API.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options):base(options)
        {

        }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<BaseAsset> Assets { get; set; }
        public DbSet<CirculatingMedium> Medium { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
    }
}
