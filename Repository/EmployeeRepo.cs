using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbFirst_one_to_many_crud.Data;
using DbFirst_one_to_many_crud.Infrastructure;
using DbFirst_one_to_many_crud.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirst_one_to_many_crud.Repository
{
    public class EmployeeRepo : IEmployee
    {
        private readonly AppDbContext _context;
        public EmployeeRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            Employee ss = await GetByIDAsync(id);
            _context.Remove(ss);
        }
        public async Task<List<Employee>> GetAllAsync()
        {
            return await _context.Employees_jay.ToListAsync();
        }
        public async Task<Employee> GetByIDAsync(int Id)
        {
            return await _context.Employees_jay.FindAsync(Id);
        }
        public async Task InsertAsync(Employee employee)
        {
            await _context.AddAsync(employee);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Employee employee)
        {
            _context.Employees_jay.Update(employee);
            await _context.SaveChangesAsync();
        }
    }
}
