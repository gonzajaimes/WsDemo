using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WServicesDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WServicesDemo.Controllers
{
    public class EmployeesMvcController : Controller
    {
        private readonly EmployeesContext _db = new EmployeesContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //GET: EmployeesMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(employee);

        }

        //GET: EmployeesMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: EmployeesMvc/Create
        // To protect from overposting attacks, please enable the  specific
        //properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id","Name","Department")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);

        }

        //GET: EmployeesMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(employee);

        }

        //POST: EmployeesMvc/Edit/5
        // To protect from overposting attacks, please enable the  specific
        //properties you want to bind to, for more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id", "Name", "Department")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);

        }

        //GET: EmployeesMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Employee employee = _db.Employees.Find(id);
            if (employee == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(employee);

        }

        // POST: EmployeesMvc/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed (int id)
        {
            Employee employee = _db.Employees.Find(id);
            _db.Employees.Remove(employee);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
