using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SubInvestorSetup.Models;
using SubInvestorSetup.ViewModels;

namespace SubInvestorSetup.Interface
{
    public class InvestorLinkServices : IInvestorLink
    {

        private readonly InvestorContext _context;

        public InvestorLinkServices(InvestorContext context)
        {
            _context = context;
        }

    
        public InvestorLink GetInvestorLink(int? id)
        {
            var investorLink =  _context.InvestorLinks
                 .FirstOrDefault(m => m.InvestorSetupId == id);

            return investorLink;
        }

        /// <summary>
        /// Get Sub Investors
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ReportingInvestorViewModel GetInvestorLinkSubInvestors(int? id)
        {
    
            var model = new ReportingInvestorViewModel();

            var investorLink =  _context.InvestorLinks
                .FirstOrDefault(m => m.InvestorSetupId == id);

       
            model.InvestorLink = investorLink;
            var status = investorLink.Status;

            //Get InvestorLink detail
            if (status != EnumStatus.Deleted)
            {

                List<ReportingInvestorLink> lst = _context.ReportingInvestorLink
                                   .FromSql("ups_GetSubInvestors @p0, @p1", id, status)
                                   .ToList();
                model.ReportingInvestorLink = lst;
            }
            else
            {
                model.ReportingInvestorLink = null;
            }

            return model;
        }

        /// <summary>
        /// Delete InvestorLink Sub Investors. DB Table trigger deletes records from ReportingInvestorLinkStage       
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public InvestorLink DeleteInvestorLinkSubInvestors(int? id)
        {
            var investorLink =  _context.InvestorLinks.Find(id);
            

            if (investorLink.Status != EnumStatus.Deployed)
            {           
                _context.InvestorLinks.Remove(investorLink);
  
            }
            else
            {
                var rawAffected =  _context.Database.ExecuteSqlCommand("ups_BackoutSubInvestors @p0", id);
                //TODO: Get Reason Code
                investorLink.DeletedReason = "Deleted From Production";
              
            }
            
            _context.SaveChanges();

            return investorLink;
        }
    }
}
