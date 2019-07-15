using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubInvestorSetup.Models
{
    public class InvestorContext : DbContext
    {

        public InvestorContext(DbContextOptions<InvestorContext> options): base(options)
        {
        }
        public DbSet<InvestorLink> InvestorLinks { get; set; }
    }
}
