using PracticumServer.Core.Dtos;
using PracticumServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Repositories
{
    public interface IWorkerRepository
    {
        Task<IEnumerable<WorkerDto>> GetAsync();

        Task<WorkerDto> GetByIdAsync(int id);

        Task<IEnumerable<WorkerDto>> GetByNameAsync(string name);

        Task<WorkerDto> PostAsync(WorkerDto worker);

        Task<WorkerDto> PutAsync(int id, WorkerDto worker);

        Task<Worker> DeleteAsync(int id);

        Worker GetByWorkerNameAndPassword(string workerFirstName, string workerLastName, string workerPassword);

    }
}
