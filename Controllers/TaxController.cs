using Microsoft.AspNetCore.Mvc;
using MVCCalculateTax.DAL;
using MVCCalculateTax.Models;

namespace MVCCalculateTax.Controllers
{
    public class TaxController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index(string alertMsg)
        {
            DBConnection connection = new DBConnection();

            PostalCodeHandler getPostalList = new PostalCodeHandler();
            ViewBag.ListPostalCodes = getPostalList.GetPostalCode(connection);

            PostData postData = new PostData();
            postData.Connection = connection;
            postData.PostID = 0;
            postData.Item = new TaxItem();

            GetUserTaxItemsModel getTaxList = new GetUserTaxItemsModel();
            ResponseData response = await getTaxList.GetTaxItems(postData);


            if (response.Success)
            {
                ViewBag.AlertMsg = alertMsg;
                ModelState.Clear();

                return View(response.ResultData.UserTaxItems);
            }
            else
            {
                ViewBag.AlertMsg = response.Message;
                ModelState.Clear();

                return View(new List<UserTaxItem>());
            }
        }


        [HttpPost]
        public async Task<IActionResult> Index(decimal annualIncome, int postalCodeID)
        {
            DBConnection connection = new DBConnection();

            PostalCodeHandler getPostalList = new PostalCodeHandler();
            List<PostalCode> postalCodes = getPostalList.GetPostalCode(connection);


            PostalCode _postPostal = postalCodes.FirstOrDefault(x => x.postalCodeID == postalCodeID);

            PostData postData = new PostData();
            postData.Connection = connection;
            postData.PostID = 0;
            postData.Item = new TaxItem();
            postData.Item.AnnualIncome = annualIncome;
            postData.Item.PostalCode = _postPostal.postalCode;
            postData.Item.TaxType = _postPostal.taxType;

            CalculateTaxModel calculateTax = new CalculateTaxModel();

            ResponseData response = await calculateTax.CalculateTaxValue(postData);


            if (response.Success)
            {
                ViewBag.ListPostalCodes = postalCodes;
                ViewBag.AlertMsg = "Tax Calculated Succesfully at: " + response.ResultData.ResponseValue;

                ModelState.Clear();

                return View(response.ResultData.UserTaxItems);
            }
            else
            {
                ViewBag.AlertMsg = response.Message;
                ModelState.Clear();

                return View(new List<UserTaxItem>());
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            DBConnection connection = new DBConnection();
            PostData postData = new PostData();
            postData.Connection = connection;
            postData.PostID = id;
            postData.Item = new TaxItem();


            DeleteTaxItemModel deleteTaxItem = new DeleteTaxItemModel();

            ResponseData response = await deleteTaxItem.DeleteTax(postData);

            ModelState.Clear();

            if (response.Success)
            {
                return RedirectToAction("Index", new { alertMsg = "Tax Item Deleted Succesfully " });

            }
            else
            {
                return RedirectToAction("Index", new { alertMsg = "Tax Item Deleted Failed. Error: " + response.Message });

            }

        }
    }
}
