using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TaskJunction.Models;
using TaskJunction.Repository.Common;
using TaskJunction.Service.Common;

namespace TaskJunction.Service
{
    public class WorkerService : IWorkerService
    {
        private IWorkerRepository _repository;
        
        public WorkerService(IWorkerRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> PostWorkerAsync(Worker worker)
        {
            try
            {
                    using var transaction = await _repository.BeginTransactionAsync();
                    bool workerInserted = await _repository.PostWorkerAsync(worker);
                    if (!workerInserted)
                    {
                        await transaction.RollbackAsync();
                        return false;
                    }

                    await transaction.CommitAsync();
                    return true;
            }
            catch
            {
                Console.WriteLine("(-) WorkerService error");
                throw new Exception("Error with creating a new worker.");
            }
        }

        public async Task<List<Worker>> GetAllWorkersAsync()
        {
            try
            {
                using var transaction = await _repository.BeginTransactionAsync();
                List<Worker> workers = await _repository.GetAllWorkersAsync();
                if (workers is null)
                {
                    await transaction.RollbackAsync();
                    return null;
                }

                await transaction.CommitAsync();
                return workers;
            }
            catch
            {
                Console.WriteLine("(-) WorkerService error");
                throw new Exception("Error with getting all workers.");
            }
        }
    }
}
