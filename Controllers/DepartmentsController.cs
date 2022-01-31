using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbFirst_one_to_many_crud.Data;
using DbFirst_one_to_many_crud.Models;
using DbFirst_one_to_many_crud.Infrastructure;
using DbFirst_one_to_many_crud.Repository;

namespace DbFirst_one_to_many_crud.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IDepartment _IDepartment;
        public DepartmentsController(AppDbContext context, IDepartment IDepartment)
        {
            _context = context;
            _IDepartment = IDepartment;
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
            try
            { 
            var depList = await _context.Departments_jay.ToListAsync();
            if(depList != null)
            {
                return View(depList);
            }
            else
            {
                return null;
            }
            }
            catch(Exception e)
            {
                Logger.Log(e);
                e.Message.ToString();
                result = ($"Dhananjay program exception as  { e.Message.ToString()}");
            }
            return View();
        }
        /*public async Task<IActionResult> Index()
        {
            var items = await _ICategory.GetAllAsync();
            return View(items);

        }*/
        string result = "";
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var item = await _IDepartment.GetByIDAsync(id);
                return View(item);
            }
            catch (Exception e)
            {
                Logger.Log(e);
                result =($"Dhananjay program exception as  { e.Message.ToString()}");
            }
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _IDepartment.InsertAsync(department);
                    await _IDepartment.SaveAsync();
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                result = ($"Dhananjay program exception as  { ex.Message.ToString()}");
            }
            return View();
        }
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                Department cat = await _IDepartment.GetByIDAsync(id);
                return View(cat);
            }
            catch (Exception e)
            {
                Logger.Log(e);
                result = ($"Dhananjay program exception as  { e.Message.ToString()}");
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Department department)
        {
            try
            {
                await _IDepartment.UpdateAsync(department);
                await _IDepartment.SaveAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Logger.Log(e);
                result = ($"Dhananjay program exception as  { e.Message.ToString()}");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _IDepartment.DeleteAsync(id);
                await _IDepartment.SaveAsync();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
            return View();
        }
    }
}
