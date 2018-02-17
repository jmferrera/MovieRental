using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Models.CustomerViewModel;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        
        public IActionResult Index()
        {
            var customers = GetCustomers();

            var viewModel = new CustomerIndexViewModel()
            {
                Customers = customers,
            };

            return View(viewModel);
        }

        public List<Customer> GetCustomers()
        {
            var customers = new List<Customer>() {
                new Customer{Name = "John Smith", Id = 1},
                new Customer{Name = "Mary Williams", Id =2},
            };
            return customers;
        }
        [Route("Customers/Details/{id}")]
        public IActionResult Details(int id)
        {

            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
            }


            return View(customer);
        }
    }
}