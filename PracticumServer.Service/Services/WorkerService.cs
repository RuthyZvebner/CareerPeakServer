using PracticumServer.Core.Dtos;
using PracticumServer.Core.Entities;
using PracticumServer.Core.Repositories;
using PracticumServer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Service.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkerService(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        public async Task<IEnumerable<WorkerDto>> GetAsync()
        {
            return await _workerRepository.GetAsync();
        }

        public async Task<WorkerDto> GetByIdAsync(int id)
        {
            return await _workerRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<WorkerDto>> GetByNameAsync(string name)
        {
            return await _workerRepository.GetByNameAsync(name);
        }

        public async Task<WorkerDto> PostAsync(WorkerDto worker)
        {
            return await _workerRepository.PostAsync(worker);
        }

        public async Task<WorkerDto> PutAsync(int id, WorkerDto worker)
        {
            return await _workerRepository.PutAsync(id, worker);
        }

        public async Task<Worker> DeleteAsync(int id)
        {
            return await _workerRepository.DeleteAsync(id);
        }

        public Worker GetByWorkerNameAndPassword(string workerFirstName, string WorkerLastName, string workerPassword)
        {
            return _workerRepository.GetByWorkerNameAndPassword(workerFirstName, WorkerLastName, workerPassword);
        }
    }
}
