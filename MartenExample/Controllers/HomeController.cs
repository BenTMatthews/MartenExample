using MartenExample.Data;
using MartenExample.Interfaces;
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
        private IExampleDataProvider _dataProvider;

        public HomeController(IExampleDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        [Route("")]
        public IActionResult Index()
        {
            var items = _dataProvider.GetAllCustomers();

            return View(items);
        }        

        [Route("/Customer/{id}")]
        public IActionResult CustomerView(Guid id)
        {
            CustomerView cv = _dataProvider.GetCustomerView(id);

            return View(cv);
        }

        [Route("/Order/{id}")]
        public IActionResult OrderView(Guid id)
        {
            OrderView cv = _dataProvider.GetOrderView(id);

            return View(cv);
        }

        [Route("Generate")]
        public IActionResult Generate()
        {
            ModelGenerator mg = new ModelGenerator();

            List<Product> products = mg.GenerateProducts();
            List<Customer> customers = mg.GenerateCustomers();
            List<Order> orders = mg.GenerateOrders(customers.Select(cust => cust.Id).ToList(), products);

            _dataProvider.CleanHouse();

            _dataProvider.BulkInsert(products);
            _dataProvider.BulkInsert(customers);
            _dataProvider.BulkInsert(orders);

            return Content("Done");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("/Error")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
