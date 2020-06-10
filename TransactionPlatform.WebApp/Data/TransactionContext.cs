using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransactionPlatform.DomainLibrary.Models;

namespace TransactionPlatform.WebApp.Data
{
    public class TransactionContext :  DbContext
    {

        public TransactionContext(DbContextOptions<TransactionContext> options) : base(options)
        {

        }


        public DbSet<Instrument> Instruments { get; set; }

}
}
