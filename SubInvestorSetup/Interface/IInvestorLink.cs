using SubInvestorSetup.Models;
using SubInvestorSetup.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SubInvestorSetup.Interface
{

    public interface IInvestorLink
    {
       InvestorLink GetInvestorLink(int? id);

       ReportingInvestorViewModel GetInvestorLinkSubInvestors(int? id);

       InvestorLink DeleteInvestorLinkSubInvestors(int? id);
    }
}
