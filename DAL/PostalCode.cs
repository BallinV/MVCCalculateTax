using System.Diagnostics.CodeAnalysis;

namespace MVCCalculateTax.DAL
{
    public class PostalCode
    {
        public PostalCode()
        {
            postalCodeID = 0;
            postalCode = "";
            taxType = "";
        }

        public int postalCodeID { get; set; }
        [AllowNull]
        public string postalCode { get; set; }
        [AllowNull]
        public string taxType { get; set; }

    }
}
