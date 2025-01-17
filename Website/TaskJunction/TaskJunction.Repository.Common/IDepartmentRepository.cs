using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskJunction.Models;
using Npgsql;

namespace TaskJunction.Repository.Common
{
    public interface IDepartmentRepository
    {
        Task<bool> PostDepartmentAsync(Department department);
        Task<Department> GetExistingDepartmentAsync(Department department);
        Task<Department> GetExistingDepartmentAsync(Guid departmentId);
        Task<List<Department>> GetAllDepartmentsAsync();
        Task<NpgsqlTransaction> BeginTransactionAsync();
    }
}
