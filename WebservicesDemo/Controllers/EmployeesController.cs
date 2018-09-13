using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebservicesDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebservicesDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly EmployeesContext _context;

        public EmployeesController(EmployeesContext context)
        {
            _context = context;

            if (_context.Employees.Count() == 0)
            {
                // Create a new Employee if collection is empty,
                // which means you can't delete all Employees.
                _context.Employees.Add(new Employee { Name = "Gonzalo", Department = "Admin" });
                _context.SaveChanges();
            }
        }
    }
}
