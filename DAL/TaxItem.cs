﻿using System.Diagnostics.CodeAnalysis;

namespace MVCCalculateTax.DAL
{
    public class TaxItem
    {
        public TaxItem()
        {
            PostalCode = "";
            TaxType = "";
        }

        [AllowNull]
        public string PostalCode { get; set; }
        [AllowNull]
        public string TaxType { get; set; }
        public decimal AnnualIncome { get; set; }

    }
}
