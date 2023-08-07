using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SampleApplication.Models;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Text.Json.Serialization;

namespace SampleApplication.Controllers
{
    public class HomeController : Controller
    {
        Uri Baseaddress = new Uri("https://getinvoices.azurewebsites.net/");
        private readonly HttpClient _Client;
        public HomeController()
        {
            _Client = new HttpClient();
            _Client.BaseAddress = Baseaddress;
        }
       
        public async Task<IActionResult> Customers()
        {
            List<Customer> customerList = new List<Customer>();
            _Client.DefaultRequestHeaders.Clear();
            _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Res = await _Client.GetAsync("api/Customers");
            if (Res.IsSuccessStatusCode)
            {
                var CustomerResponse = Res.Content.ReadAsStringAsync().Result;
                customerList = JsonConvert.DeserializeObject<List<Customer>>(CustomerResponse);
                return View(customerList);
            }
            else
            {
                TempData["ErrorMessage"] = Res.ReasonPhrase;
                return View("Customers");
            }
        }
        public IActionResult Create()
        {
            Customer customer = new Customer();
            return View(customer);
        }
        [HttpPost]
        public IActionResult Create(Customer obj)
        {
            Customer objCustomer = null;
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                _Client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = _Client.PostAsync("api/Customer", content).Result;
                if (Res.IsSuccessStatusCode)
                {
                    var CustomerResponse = Res.Content.ReadAsStringAsync().Result;
                    objCustomer = JsonConvert.DeserializeObject<Customer>(CustomerResponse);
                    return View("Customers", objCustomer);
                }
                else
                {
                    TempData["ErrorMessage"] = Res.ReasonPhrase;
                    return View("Create");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Create");
            }

        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            Customer objCustomer = null;
            _Client.DefaultRequestHeaders.Clear();
            _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage Res = _Client.GetAsync(_Client.BaseAddress + "api/Customer/" + id).Result;
            if (Res.IsSuccessStatusCode)
            {
                var CustomerResponse = Res.Content.ReadAsStringAsync().Result;
                objCustomer = JsonConvert.DeserializeObject<Customer>(CustomerResponse);
            }
            return View(objCustomer);
        }
        [HttpPost]
        public IActionResult Edit(Customer obj)
        {
            try
            {
                string data = JsonConvert.SerializeObject(obj);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                _Client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = _Client.PutAsync(_Client.BaseAddress + "api/Customer/", content).Result;
                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Customers");
                }
                else
                {
                    TempData["ErrorMessage"] = Res.ReasonPhrase;
                    return View("Edit");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Edit");
            }

        }
        

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            Customer objCustomer = null;
            try
            {
                _Client.DefaultRequestHeaders.Clear();
                _Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await _Client.GetAsync(_Client.BaseAddress+"api/Customer/" + id);
                if (Res.IsSuccessStatusCode)
                {
                    var CustomerResponse = Res.Content.ReadAsStringAsync().Result;
                    objCustomer = JsonConvert.DeserializeObject<Customer>(CustomerResponse);
                    return View("Delete", objCustomer);
                }
                else
                {
                    TempData["ErrorMessage"] = Res.ReasonPhrase;
                    return View("Delete");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Delete");
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int Id)
        {
            try
            {
                _Client.DefaultRequestHeaders.Clear();
                HttpResponseMessage Res = _Client.DeleteAsync("api/Customer/" + Id).Result;
                if (Res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Customers");
                }
                else {
                    TempData["ErrorMessage"] = Res.ReasonPhrase;
                    return View("Delete");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View("Delete");
            }
        }

    }
}