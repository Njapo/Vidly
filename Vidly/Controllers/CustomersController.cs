using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Vidly.Data;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller 
    {
        private VidlyContext _context;
        public List<Customer> Customers{ get; set; }
        public CustomersController(VidlyContext vidlyContext)
        {
            Customers = new List<Customer>()
            {
              new Customer(){Name="John Smith", Id=0},
              new Customer(){Name="Will Smith", Id=1}
            };
            _context = vidlyContext;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public IActionResult New()
        {
            return View(); 
        }
        [Route("Customers/Index")]
        public IActionResult Index()
        {
            //var customers = new List<Customer>()
            //{ 
            //  new Customer(){Name="John Smith", Id=0},
            //  new Customer(){Name="Will Smith", Id=1}
            //};
            var customers = _context.Customers.Include(c=>c.MembershipType).ToList(); 
            // var customers1 = _context.Customers.Include<Customer>(c=>c.MembershipType) 

            return View(customers);
        }
        [Route("/Customers/Index/Details")]
        public IActionResult Details(int id) 
        {
            //var _Customers = Customers;
            //int number = 0;
            //var customer = new Customer();
            //foreach (var item in _Customers)
            //{
            //    if(item.Id==id)
            //    {
            //        number = 1;
            //        customer = item;
            //        return View(item);
            //    }
            //}
            //if(number==0)
            //return View();
            //else
            //{
            //    return View(customer);
            //}
            var customers = _context.Customers.SingleOrDefault(x => x.Id == id);  
            if(customers == null)
                return NotFound();
            else
                return View(customers);
        }
    }
}
