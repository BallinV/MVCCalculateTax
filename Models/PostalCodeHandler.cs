using MVCCalculateTax.DAL;
using System.Data;
using System.Data.SqlClient;

namespace MVCCalculateTax.Models
{
    public class PostalCodeHandler
    {
        public List<PostalCode> GetPostalCode(DBConnection connection)
        {

            try
            {
                List<PostalCode> postalCodes = new List<PostalCode>();
                DataAccessLayerClass DB = new(connection);
                ResponseData res = DB.GetSP("spGetPostalCodes", new List<SqlParameter>());

                foreach (DataTable tb in res.RawDataSet.Tables)
                {
                    foreach (DataRow row in tb.Rows)
                    {
                        PostalCode postalItem = new PostalCode();
                        postalItem.postalCodeID = row.Field<int>("PostalCodeID");
                        postalItem.postalCode = row.Field<string>("PostalCode");
                        postalItem.taxType = row.Field<string>("TaxType");

                        postalCodes.Add(postalItem);
                    }
                }


                return postalCodes;
            }
            catch (Exception)
            {

                return new List<PostalCode>();
            }

        }
    }
}
