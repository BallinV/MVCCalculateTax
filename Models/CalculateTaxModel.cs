using MVCCalculateTax.DAL;
using Newtonsoft.Json;
using RestSharp;

namespace MVCCalculateTax.Models
{
    public class CalculateTaxModel
    {
        public async Task<ResponseData> CalculateTaxValue(PostData postData)
        {
            ResponseData response = new ResponseData();

            //post to API Calculate Tax return resposne
            using (var client = new RestClient(postData.Connection.URItoAPI)) //http://localhost:24680/     http://blackbox.codecentral.co.za/
            {
                var request = new RestRequest("api/CalculateTax", Method.Post);

                request.AddBody(postData, contentType: "application/json");
                var res = await client.ExecuteAsync(request);
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    JsonConvert.PopulateObject(res.Content, response);
                }
                else
                {
                    response.Success = false;
                }

            }


            return response;
        }
    }
}
