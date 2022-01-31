using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbFirst_one_to_many_crud.Models;
using DbFirst_one_to_many_crud.Data;

namespace DbFirst_one_to_many_crud.Infrastructure
{
   public interface IDepartment
    {
        Task<List<Department>> GetAllAsync();
        Task SaveAsync();
        Task InsertAsync(Department department);
        Task DeleteAsync(int id);
        Task UpdateAsync(Department department);
        Task<Department> GetByIDAsync(int Id);
    }
}
