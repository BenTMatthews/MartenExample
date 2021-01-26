using MartenExample.Data;
using MartenExample.Models;
using MartenExample.Views.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MartenExample.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private MartenProvider _martenProvider;
        public HomeController(MartenProvider martenProvider)
        {
            _martenProvider = martenProvider;
        }

        [Route("")]
        public IActionResult Index()
        {
            //Customer cust = new Customer();
            //cust.Name = "Connie Nelson";

            //_martenProvider.SaveItem<Guid>(cust);

            var items = _martenProvider.GetAllItems<Customer>();

            ModelGenerator mg = new ModelGenerator();

            var prods = mg.GenerateProducts();

            return View(items);
        }

        [Route("/Generate")]
        public IActionResult Generate()
        {
            ModelGenerator mg = new ModelGenerator();

            List<Product> products = mg.GenerateProducts();
            List<Customer> customers = mg.GenerateCustomers();
            List<Order> orders = mg.GenerateOrders(customers.Select(cust => cust.Id).ToList(), products);

            _martenProvider.CleanHouse();

            _martenProvider.BulkInsert(products);
            _martenProvider.BulkInsert(customers);
            _martenProvider.BulkInsert(orders);

            return Content("Done");
        }

        [Route("/Customer/{id}")]
        public IActionResult CustomerView(Guid id)
        {
            CustomerView cv = _martenProvider.GetCustomerAndOrders(id);

            return View(cv);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
