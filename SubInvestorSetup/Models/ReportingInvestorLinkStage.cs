using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SubInvestorSetup.Models
{
    public class ReportingInvestorLinkStage
    {

        [Key]
        public int InvestorSetupId { get; set; }
        public int RI_Code { get; set; }
        public string INVESTOR_NBR { get; set; }
        public string INVESTOR_SUB { get; set; }
        public int Status { get; set; }
    }
}
