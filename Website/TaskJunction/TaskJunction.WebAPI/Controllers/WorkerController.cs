using Microsoft.AspNetCore.Mvc;
using TaskJunction.Models;
using TaskJunction.Service.Common;
using TaskJunction.WebAPI.RestModels;

namespace TaskJunction.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private IWorkerService _service;

        public WorkerController(IWorkerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostWorkerAsync(PostWorker postWorker)
        {
            Worker worker = new Worker
                (
                    Guid.NewGuid(),
                    postWorker.FirstName,
                    postWorker.LastName,
                    postWorker.Email,
                    postWorker.Address,
                    postWorker.DepartmentId
                );

            bool successfulPost = await _service.PostWorkerAsync(worker);
            if (!successfulPost)
                return BadRequest();
            return Ok("Worker " + worker.FirstName + " " + worker.LastName + " was added!");
        }

        [HttpGet]
        [Route("GetAllWorkers")]
        public async Task<IActionResult> GetAllWorkersAsync()
        {
            List<Worker> workers = await _service.GetAllWorkersAsync();
            if(workers is null)
                return NotFound();
            List<GetWorker> getWorkers = new List<GetWorker>();
            foreach(var worker in workers)
            {
                GetWorker getWorker = new GetWorker
                {
                    Id = worker.Id,
                    FirstName = worker.FirstName,
                    LastName = worker.LastName,
                    Email = worker.Email,
                    Address = worker.Address,
                    DepartmentId = worker.DepartmentId,
                    DateCreated = worker.DateCreated
                };
                getWorkers.Add(getWorker);
            }
            return Ok(getWorkers);
        }
    }
}
