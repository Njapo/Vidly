using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly VidlyContext _context;

        public MoviesController(VidlyContext context)
        {
            _context = context;
        } 
        public IActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek" };
            var customers = new List<Customer>()
            { 
             new Customer{Name="Customer 1"},
             new Customer{Name="Customer 2"}
            };
            var ViewModel = new RandomMoveViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(ViewModel);
        }
        
    }
}
