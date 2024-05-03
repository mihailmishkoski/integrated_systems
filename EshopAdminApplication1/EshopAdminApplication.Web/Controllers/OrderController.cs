using EshopAdminApplication.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace EshopAdminApplication.Web.Controllers
{
    public class OrderController : Controller
    { 

        public IActionResult Index()
        {
            HttpClient client = new HttpClient();
            string URL = "https://localhost:44341/api/Admin/GetAllActiveOrders";

            HttpResponseMessage response = client.GetAsync(URL).Result;

            var data = response.Content.ReadAsAsync<List<Order>>().Result;
            return View(data);
        }

        public IActionResult Details(Guid orderId)
        {

            HttpClient client = new HttpClient();
            string URL = "https://localhost:44341/api/Admin/GetDetailsForOrder";

            var model = new
            {
                Id = orderId
            };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PostAsync(URL, content).Result;

            var result = response.Content.ReadAsAsync<Order>().Result;


            return View(result);

        }
    }
}
