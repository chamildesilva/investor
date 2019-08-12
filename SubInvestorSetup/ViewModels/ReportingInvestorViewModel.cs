using SubInvestorSetup.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubInvestorSetup.ViewModels
{
    public class ReportingInvestorViewModel
    {

        public InvestorLink InvestorLink {get; set;}
        public List<ReportingInvestorLink> ReportingInvestorLink { get; set; }       
    }
}
