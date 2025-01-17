using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskJunction.Models;
using TaskJunction.Service.Common;
using TaskJunction.Repository.Common;

namespace TaskJunction.Service
{
    public class DepartmentService : IDepartmentService
    {
        private IDepartmentRepository _repository;

        public DepartmentService(IDepartmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> PostDepartmentAsync(Department department)
        {
            try
            {
                var existingDepartment = await _repository.GetExistingDepartmentAsync(department);
                if (existingDepartment == null)
                {
                    using var transaction = await _repository.BeginTransactionAsync();

                    department.Id = Guid.NewGuid();
                    bool departmentInserted = await _repository.PostDepartmentAsync(department);
                    if (!departmentInserted)
                    {
                        await transaction.RollbackAsync();
                        return false;
                    }

                    await transaction.CommitAsync();
                    return true;
                }
                return false;
            }
            catch
            {
                Console.WriteLine("(-) DepartmentService error");
                throw new Exception("Error with creating a new department.");
            }
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            try
            {
                using var transaction = await _repository.BeginTransactionAsync();
                List<Department> departments = await _repository.GetAllDepartmentsAsync();
                if(departments is null)
                {
                    await transaction.RollbackAsync();
                    return null;
                }

                await transaction.CommitAsync();
                return departments;
            }
            catch
            {
                Console.WriteLine("(-) DepartmentService error");
                throw new Exception("Error with getting all departments.");
            }
        }
    }
}
