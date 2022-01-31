using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbFirst_one_to_many_crud.Models;
using DbFirst_one_to_many_crud.Data;
using Microsoft.EntityFrameworkCore;
using DbFirst_one_to_many_crud.Infrastructure;

namespace DbFirst_one_to_many_crud.Repository
{
    public class DepartmentRepo : IDepartment
    {
        private readonly AppDbContext _context;
        public DepartmentRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task DeleteAsync(int id)
        {
            Department ss = await GetByIDAsync(id);
            _context.Remove(ss);
        }
        public async Task<List<Department>> GetAllAsync()
        {
            return await _context.Departments_jay.ToListAsync();
        }
        public async Task<Department> GetByIDAsync(int Id)
        {
            return await _context.Departments_jay.FindAsync(Id);
        }
        public async Task InsertAsync(Department department)
        {
            await _context.AddAsync(department);
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Department department)
        {
            _context.Departments_jay.Update(department);
            await _context.SaveChangesAsync();
        }
    }
}
