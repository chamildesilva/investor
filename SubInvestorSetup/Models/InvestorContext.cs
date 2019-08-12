using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubInvestorSetup.Models
{
    public class InvestorContext : IdentityDbContext
    {

        public InvestorContext(DbContextOptions<InvestorContext> options): base(options)
        {
        }
        public DbSet<InvestorLink> InvestorLinks { get; set; }
        public DbSet<ReportingInvestorLink> ReportingInvestorLink { get; set; }       
        public DbSet<ReportingInvestorLinkStage> ReportingInvestorLinkStage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<ReportingInvestorLinkStage>()
                .HasKey(r => new {r.RI_Code, r.INVESTOR_NBR, r.INVESTOR_SUB });
            modelbuilder.Entity<ReportingInvestorLink>()
               .HasKey(r => new { r.RI_Code, r.INVESTOR_NBR, r.INVESTOR_SUB });

            base.OnModelCreating(modelbuilder);
        }
    }
}
