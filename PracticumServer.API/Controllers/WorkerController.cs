using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PracticumServer.Core.Dtos;
using PracticumServer.Core.Entities;
using PracticumServer.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticumServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        // GET: api/<WorkerController>
        [HttpGet]
        public async Task<IEnumerable<WorkerDto>> GetAsync()
        {
            return await _workerService.GetAsync();
        }

        // GET api/<WorkerController>/5
        [HttpGet("{id}")]
        public async Task<WorkerDto> GetByIdAsync(int id)
        {
            return await _workerService.GetByIdAsync(id);
        }

        [HttpGet("name/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<WorkerDto>> GetByNameAsync(string name)
        {
            var workers = await _workerService.GetByNameAsync(name);
            return await _workerService.GetByNameAsync(name);
        }

        [Authorize]
        [HttpPost]
        public async Task<WorkerDto> PostAsync(WorkerDto worker)
        {
            return await _workerService.PostAsync(worker);
        }

        // PUT api/<WorkerController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<WorkerDto> PutAsync(int id, WorkerDto worker)
        {
            return await _workerService.PutAsync(id, worker);
        }

        // DELETE api/<WorkerController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<Worker> DeleteAsync(int id)
        {
            return await _workerService.DeleteAsync(id);
        }
    }
}
