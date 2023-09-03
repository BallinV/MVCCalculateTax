using System.Diagnostics.CodeAnalysis;

namespace MVCCalculateTax.DAL
{
    public class DBConnection
    {
        public DBConnection()
        {
            ServerName = "LAPTOP-1AM23VT2";
            SQLName = "SQLEXPRESS";
            DatabseName = "PaySpaceTaxCalculation";

            UserID = "";
            Password = "";
            URItoAPI = "https://localhost:7095/";

        }

        [AllowNull]
        public string ServerName { get; set; }
        [AllowNull]
        public string SQLName { get; set; }
        [AllowNull]
        public string DatabseName { get; set; }
        [AllowNull]
        public string UserID { get; set; }
        [AllowNull]
        public string Password { get; set; }
        [AllowNull]
        public string URItoAPI { get; set; }

    }
}
