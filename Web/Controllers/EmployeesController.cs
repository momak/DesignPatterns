using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Builder.ConcreteBuilder;
using Web.Builder.Director;
using Web.Builder.IBuilder;
using Web.Factory.AbstractFactory;
using Web.Factory.FactoryMethod;
using Web.Managers;
using Web.Models;

namespace Web.Controllers
{
    public class EmployeesController : BaseController
    {
        private EmployeePortalEntities db = new EmployeePortalEntities();

        [HttpGet]
        public ActionResult BuildSystem(int? employeeId)
        {
            Employee employee = db.Employees.Find(employeeId);
            if (employee.ComputerDetail.Contains("Laptop"))
                return View("BuildLaptop", employee);
            else
                return View("BuildDesktop", employee);
        }

        [HttpPost]
        public ActionResult BuildLaptop(FormCollection formCollection)
        {
            Employee employee = db.Employees.Find(Convert.ToInt32(formCollection["employeeID"]));
               //Concrete Builder
            ISystemBuilder systemBuilder = new LaptopBuilder();

            //Director
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.BuildSystem(systemBuilder, formCollection);

            ComputerSystem system = systemBuilder.GetSystem();

            employee.SystemConfigurationDetails = $"RAM: {system.RAM}, HDDSize: {system.HDDSize}, TouchScreen: {system.TouchScreen}";

            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult BuildDesktop(FormCollection formCollection)
        {
            //Step 1
            Employee employee = db.Employees.Find(Convert.ToInt32(formCollection["employeeID"]));
            //Step 2
            //Concrete Builder
            ISystemBuilder systemBuilder = new DesktopBuilder();

            //Step 3
            //Director
            ConfigurationBuilder builder = new ConfigurationBuilder();
            builder.BuildSystem(systemBuilder, formCollection);

            //Step 4
            ComputerSystem system = systemBuilder.GetSystem();

            employee.SystemConfigurationDetails = $"RAM: {system.RAM}, HDDSize: {system.HDDSize}, Keyboard: {system.Keyboard}, Mouse: {system.Mouse}";

            db.Entry(employee).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        // GET: Employees
        public async Task<ActionResult> Index()
        {
            var employees = db.Employees.Include(e => e.Employee_Type);
            return View(await employees.ToListAsync());
        }

        // GET: Employees/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,JobDescription,Number,Department,HourlyPay,Bonus,EmployeeTypeID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                BaseEmployeeFactory empFactory = new EmployeeManagerFactory().CreateFactory(employee);
                empFactory.ApplySalary();

                IComputerFactory factory = new EmployeeSystemFactory().Create(employee);
                EmployeeSystemManager manager = new EmployeeSystemManager(factory);
                employee.ComputerDetail = manager.GetSystemDetails();


                db.Employees.Add(employee);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,JobDescription,Number,Department,HourlyPay,Bonus,EmployeeTypeID")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeTypeID = new SelectList(db.Employee_Type, "Id", "EmployeeType", employee.EmployeeTypeID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = await db.Employees.FindAsync(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Employee employee = await db.Employees.FindAsync(id);
            db.Employees.Remove(employee);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
