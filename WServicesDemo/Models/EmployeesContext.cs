using System;
using Microsoft.EntityFrameworkCore;

namespace WServicesDemo.Models
{
    public class EmployeesContext : DbContext
    {

        public EmployeesContext() :base()
        {

        }
        public EmployeesContext(DbContextOptions<EmployeesContext> options)
            :base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
