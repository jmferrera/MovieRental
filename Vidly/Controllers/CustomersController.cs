using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vidly.Models;
using Vidly.Models.CustomerViewModel;
using Vidly.Data;
namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var customers = _context.Customers.ToList();

            return View(customers);
        }

        //public List<Customer> GetCustomers()
        //{
        //    var customers = new List<Customer>() {
        //        new Customer{Name = "John Smith", Id = 1},
        //        new Customer{Name = "Mary Williams", Id =2},
        //    };
        //    return customers;
        //}
        [Route("Customers/Details/{id}")]
        public IActionResult Details(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if(customer == null)
            {
                return NotFound();
            }


            return View(customer);
        }
    }
}