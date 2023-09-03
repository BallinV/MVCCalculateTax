using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MVCCalculateTax.DAL
{
    public class UserTaxItem
    {
        public UserTaxItem()
        {
            UserTaxID = 0;
            PostalCode = "";
            TaxType = "";
            AnnualIncome = 0;
            TaxAmount = 0;
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
            isDeleted = 1;
        }

        public int UserTaxID { get; set; }
        [Display(Name = "Postal Code")]
        [AllowNull]
        public string PostalCode { get; set; }
        [Display(Name = "Tax Type")]
        [AllowNull]
        public string TaxType { get; set; }
        [Display(Name = "Annual Income")]
        public decimal AnnualIncome { get; set; }
        [Display(Name = "Tax Amount")]
        public decimal TaxAmount { get; set; }
        [Display(Name = "Created")]
        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
        [AllowNull]
        public int isDeleted { get; set; }


    }
}
