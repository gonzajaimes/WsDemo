using DemoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Services
{
    public class EmployeesServices
    {
        public List<Employee> GetEmployee()
        {
            var list = new List<Employee>
            {
                new Employee
                {
                    Name = "Mohamed",
                    Department = "Marketing"
                },

                new Employee
                {
                    Name = "Pedro",
                    Department = "Sales"
                },

                new Employee
                {
                    Name = "Pablo",
                    Department = "Marketing"
                },

                new Employee
                {
                    Name = "Luis",
                    Department = "Operations"
                },


            };

            return list;
        }

    }
}
