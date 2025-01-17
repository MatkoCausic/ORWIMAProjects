using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskJunction.Models;

namespace TaskJunction.Service.Common
{
    public interface IDepartmentService
    {
        Task<bool> PostDepartmentAsync(Department department);
        Task<List<Department>> GetAllDepartmentsAsync();
    }
}
