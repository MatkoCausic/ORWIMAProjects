using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskJunction.Models;

namespace TaskJunction.Service.Common
{
    public interface IWorkerService
    {
        Task<bool> PostWorkerAsync(Worker worker);
        Task<List<Worker>> GetAllWorkersAsync();
    }
}
