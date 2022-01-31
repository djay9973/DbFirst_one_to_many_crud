using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbFirst_one_to_many_crud.Data;
using DbFirst_one_to_many_crud.Models;

namespace DbFirst_one_to_many_crud.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly AppDbContext _context;
        public readonly Logger _logError;
        public EmployeesController(AppDbContext context)
        {
            _context = context;
            _logError = new Logger(context);
        }
        string result = "";
        // GET: Employees
        public IActionResult Index()
        {
            //return View(await _context.Employees_jay.ToListAsync());
            try
            {
                var stdlist = from e in _context.Employees_jay
                              join d in _context.Departments_jay
                              on e.DepID equals d.DepartmentId
                              into Dep
                              from d in Dep.DefaultIfEmpty()

                              select new Employee
                              {
                                  Id = e.Id,
                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  Email = e.Email,
                                  Mobile = e.Mobile,
                                  Description = e.Description,
                                  DepID = e.DepID,
                                  Department = d == null ? "" : d.DepartmentName
                              };
                if (stdlist != null)
                {
                    return View(stdlist);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                ex.Message.ToString();
                result = ($"Dhananjay program exception as  { ex.Message.ToString()}");
            }
            return View();
        }
        public IActionResult IndexAjax()
        {
            Employee emp = new Employee();
            //return View(await _context.Employees_jay.ToListAsync());
            try
            {
                var stdlist = from e in _context.Employees_jay
                              join d in _context.Departments_jay
                              on e.DepID equals d.DepartmentId
                              into Dep
                              from d in Dep.DefaultIfEmpty()

                              select new Employee
                              {
                                  Id = e.Id,
                                  FirstName = e.FirstName,
                                  LastName = e.LastName,
                                  Email = e.Email,
                                  Mobile = e.Mobile,
                                  Description = e.Description,
                                  DepID = e.DepID,
                                  Department = d == null ? "" : d.DepartmentName
                              };
                if (stdlist != null)
                {
                    return View(stdlist);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Logger.Log(ex);
                ex.Message.ToString();
                //result = ($"Dhananjay program exception as  { ex.Message.ToString()}");
            }
            return View(emp);
        }
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _context.Employees_jay
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }

                return View(employee);
            }
            catch (Exception ex)
            {

                /*Logger.Log(ex);
                ex.Message.ToString();
                result = ($"Dhananjay program exception as  { ex.Message.ToString()}");*/
            }
            return View();
        }
        public async Task<IActionResult> ViewEmployee(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _context.Employees_jay
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }

                //return View(employee);
                return PartialView("_details", employee);
            }
            catch (Exception ex)
            {

                /*Logger.Log(ex);
                ex.Message.ToString();
                result = ($"Dhananjay program exception as  { ex.Message.ToString()}");*/
            }
            return View();
        }
        
        public async Task<IActionResult> EditEmployee(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _context.Employees_jay
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }

                //return View(employee);
                return PartialView("_Edit", employee);
            }
            catch (Exception ex)
            {

                /*Logger.Log(ex);
                ex.Message.ToString();
                result = ($"Dhananjay program exception as  { ex.Message.ToString()}");*/
            }
            return View();
        }
        
        public async Task<IActionResult> UpdateEmployee(Employee obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Attach(obj);
                    _context.Entry(obj).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                    return PartialView("_EmployeeList", obj);
                }
                return View();
            }
            catch (Exception e)
            {
                Logger.Log(e);
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var employee = await _context.Employees_jay
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (employee == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.Entry(employee).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                /*Logger.Log(ex);
                ex.Message.ToString();
                result = ($"Dhananjay program exception as  { ex.Message.ToString()}");*/
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddEmployeeAjax()
        {
            Employee emp = new Employee();
            return PartialView("_AddEmployee", emp);
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployees(Employee obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.Id == 0)
                    {
                        _context.Employees_jay.Add(obj);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                    return PartialView("_Message", obj);
                }
                //return View();
            }
            catch (Exception e)
            {
               /* Logger.Log(e);
                return RedirectToAction("Index");*/
            }
            return PartialView("_AddEmployee");
        }
       /* public async Task<IActionResult> AddEmployee(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
            {
                var transactionModel = await _context.Employees_jay.FindAsync(id);
                if (transactionModel == null)
                {
                    return NotFound();
                }
                return View(transactionModel);
            }
        }*/
        [HttpGet]
        public IActionResult Create(Employee obj)
        {
            loadDDL();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(Employee obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.Id == 0)
                    {
                        _context.Employees_jay.Add(obj);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    }
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception e)
            {
                Logger.Log(e);
                return RedirectToAction("Index");
            }
        }
        [HttpGet]
        public IActionResult AddOrEdit()
        {
            loadDDL();
            return View();
        }
        public async Task<IActionResult> AddEmployee(int id = 0)
        {
            if (id == 0)
                return View(new Employee());
            else
            {
                var transactionModel = await _context.Employees_jay.FindAsync(id);
                if (transactionModel == null)
                {
                    return NotFound();
                }
                return View(transactionModel);
            }
        }
        
        /* [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> AddOrEdit(Employee obj)
         {
             if (ModelState.IsValid)
             {
                 //Insert
                 try
                 {
                     if (ModelState.IsValid)
                     {
                         if (obj.Id == 0)
                         {
                             _context.Employees_jay.Add(obj);
                             await _context.SaveChangesAsync();
                         }
                         else
                         {
                             _context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                         }
                         return RedirectToAction("Index");
                     }
                     return View();
                 }
                 catch (Exception e)
                 {
                     Logger.Log(e);
                     return RedirectToAction("Index");
                 }
                // return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_EmployeeList", _context.Employees_jay.ToList()) });
             }
             //return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", obj) });
         }*/

        /* public async Task<IActionResult> Edit(int? id)
         {
             if (id == null)
             {
                 return NotFound();
             }

             var employee = await _context.Employees_jay.FindAsync(id);
             if (employee == null)
             {
                 return NotFound();
             }
             return View(employee);
         }


         [HttpPost]
         [ValidateAntiForgeryToken]
         public async Task<IActionResult> Edit(int id, Employee employee)
         {
             if (id != employee.Id)
             {
                 return NotFound();
             }

             if (ModelState.IsValid)
             {
                 try
                 {
                     _context.Update(employee);
                     await _context.SaveChangesAsync();
                 }
                 catch (DbUpdateConcurrencyException)
                 {
                     if (!EmployeeExists(employee.Id))
                     {
                         return NotFound();
                     }
                     else
                     {
                         throw;
                     }
                 }
                 return RedirectToAction(nameof(Index));
             }
             return View(employee);
         }*/

         public async Task<IActionResult> Delete(int? id)
          {
              try
              {
                  if (id == null)
                  {
                      return NotFound();
                  }

                  var employee = await _context.Employees_jay
                      .FirstOrDefaultAsync(m => m.Id == id);
                  if (employee == null)
                  {
                      return NotFound();
                  }

                  return View(employee);
              }
              catch (Exception ex)
              {
                  Logger.Log(ex);
                  ex.Message.ToString();
                  result = ($"Dhananjay program exception as  { ex.Message.ToString()}");
              }
              return View();
          }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var employee = await _context.Employees_jay.FindAsync(id);
                _context.Employees_jay.Remove(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                ex.Message.ToString();
                result = ($"Dhananjay program exception as  { ex.Message.ToString()}");
            }
            return View();
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees_jay.Any(e => e.Id == id);
        }
        private void loadDDL()
        {
            try
            {
                List<Department> depList = new List<Department>();
                depList = _context.Departments_jay.ToList();
                depList.Insert(0, new Department { DepartmentId = 0, DepartmentName = "Please Select" });
                ViewBag.DepList = depList;
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                ex.Message.ToString();
                result = ($"Dhananjay program exception as  { ex.Message.ToString()}");
            }
        }
    }
}
