using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbFirst_one_to_many_crud.Models;

namespace DbFirst_one_to_many_crud.Infrastructure
{
   public interface IEmployee
    {
        Task<List<Employee>> GetAllAsync();
        Task InsertAsync(Employee employee);
        Task DeleteAsync(int id);
        Task UpdateAsync(Employee employee);
        Task<Employee> GetByIDAsync(int Id);
    }
}
