using Microsoft.AspNetCore.Mvc;
using TaskJunction.Models;
using TaskJunction.Service.Common;
using TaskJunction.WebAPI.RestModels;

namespace TaskJunction.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private IDepartmentService _service;

        public DepartmentController(IDepartmentService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostDepartmentAsync(PostDepartment postDepartment)
        {
            Department department = new Department(postDepartment.Name);

            bool successfulPost = await _service.PostDepartmentAsync(department);
            if (!successfulPost)
                return BadRequest();
            return Ok("Department " + postDepartment.Name + "is added!");
        }

        [HttpGet]
        [Route("GetAllDepartments")]
        public async Task<IActionResult> GetAllDepartmentsAsync()
        {
            List<Department> departments = await _service.GetAllDepartmentsAsync();
            if (departments is null)
                return NotFound();
            List<GetAllDepartments> getAllDepartments = new List<GetAllDepartments>();
            foreach(var department in departments)
            {
                GetAllDepartments getDepartment = new GetAllDepartments
                {
                    Id = department.Id,
                    Name = department.Name
                };
                getAllDepartments.Add(getDepartment);
            }
            return Ok(getAllDepartments);
        }
    }
}
