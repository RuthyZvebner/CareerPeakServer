using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PracticumServer.Core.Dtos;
using PracticumServer.Core.Entities;
using PracticumServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Data.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public WorkerRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IEnumerable<WorkerDto>> GetAsync()
        {
            var workersDto = _mapper.Map<IEnumerable<WorkerDto>>(_context.Workers);
            return await Task.FromResult(workersDto);
        }

        public async Task<WorkerDto> GetByIdAsync(int id)
        {
            var workerDto = _mapper.Map<WorkerDto>(_context.Workers.Where(x => x.Id == id).First());
            return await Task.FromResult(workerDto);
        }

        public async Task<IEnumerable<WorkerDto>> GetByNameAsync(string name)
        {
            var workers = _context.Workers.Where(x => x.FirstName.Contains(name) || x.LastName.Contains(name) || x.IdNumber.ToString().Contains(name)
            || x.StartDate.ToString().Contains(name));
            var workerDtos = _mapper.Map<IEnumerable<WorkerDto>>(workers);
            return await Task.FromResult(workerDtos);
        }

        public async Task<WorkerDto> PostAsync(WorkerDto workerDto)
        {
            var worker = _mapper.Map<Worker>(workerDto);
            worker.Status = true;
            _context.Workers.Add(worker);
            await _context.SaveChangesAsync();
            workerDto.Id = worker.Id;
            return workerDto;
        }

        public async Task<WorkerDto> PutAsync(int id, WorkerDto workerDto)
        {
            Worker worker = _mapper.Map<Worker>(workerDto);
            Worker workerToUpdate = _context.Workers.Where(x => x.Id == id).First();
            if (workerToUpdate == null)
            {
                return null;
            }
            else
            {
                workerToUpdate.IdNumber = workerDto.IdNumber;
                workerToUpdate.StartDate = worker.StartDate;
                workerToUpdate.DateOfBirth = worker.DateOfBirth;
                workerToUpdate.FirstName = worker.FirstName;
                workerToUpdate.Gender = worker.Gender;
                workerToUpdate.LastName = worker.LastName;
            }
            await _context.SaveChangesAsync();
            return workerDto;
        }

        public async Task<Worker> DeleteAsync(int id)
        {
            Worker workerToDelete = _context.Workers.Where(x => x.Id == id).First();
            if (workerToDelete != null)
            {
                workerToDelete.Status = false;
            }
            await _context.SaveChangesAsync();
            return workerToDelete;
        }

        public Worker GetByWorkerNameAndPassword(string workerFirstName, string workerLastName, string workerPassword)
        {
            return _context.Workers.FirstOrDefault(e => e.FirstName == workerFirstName && e.LastName == workerLastName && e.Password == workerPassword);
        }
    }
}
