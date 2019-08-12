using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SubInvestorSetup.Models
{
    public class InvestorLink
    {
        [Key]
        public int InvestorSetupId { get; set; }

        [Required(ErrorMessage ="Descrption is required")]
        [Column(TypeName ="varchar(256)")]
        public string Description { get; set; }


        [Required]
        [Range(0,999999999, ErrorMessage ="Value for {0} must be {1} and {2}")]
        [DisplayName("Investor No")]
        public int InvestorNo { get; set; }

        [Required]
        [Range(0, 99999)]
        [DisplayName("Sub Investor From")]
        public int InvestorSubFrom { get; set; }

        [Required]
        [Range(0, 99999)]
        [DisplayName("Sub Investor To")]
        public int InvestorSubTo { get; set; }

        [Required]
        [Range(0, 999999999)]
        [DisplayName("Model After Investor")]
        public int ModelAfterInvestorNo { get; set; }

        [Required]
        [Range(0, 99999)]
        [DisplayName("Model After Sub")]
        public int ModelAfterInvestorSub { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [DisplayName("Created")]
        public DateTime? CreatedDate { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Created By")]
        public string CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Approved")]
        public DateTime? ApprovedDate { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Approved by")]
        public string ApprovedBy { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Deployed")]
        public DateTime? DeployedDate { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Deployed by")]
        public string DeployedBy { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Deleted")]
        public DateTime? DeletedDate { get; set; }

        [Column(TypeName = "varchar(100)")]
        [DisplayName("Deleted by")]
        public string DeletedBy { get; set; }

        [Column(TypeName = "varchar(256)")]
        [DisplayName("Deleted Reason")]
        public string DeletedReason { get; set; }
        public EnumStatus? Status { get; set; }
      
    }   
}
