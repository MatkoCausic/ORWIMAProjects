using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskJunction.Models;

namespace TaskJunction.Repository.Common
{
    public interface IWorkerRepository
    {
        Task<bool> PostWorkerAsync(Worker worker);
        Task<List<Worker>> GetAllWorkersAsync();
        Task<NpgsqlTransaction> BeginTransactionAsync();
    }
}
