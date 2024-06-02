using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PracticumServer.Core.Dtos;
using PracticumServer.Core.Entities;
using PracticumServer.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticumServer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IEnumerable<RoleDto>> GetAsync()
        {
            return await _roleService.GetAsync();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<RoleDto> GetByIdAsync(int id)
        {
            return await _roleService.GetByIdAsync(id);
        }

        // GET api/<RoleController>/5
        [HttpGet("{name}/{workerId}")]
        public async Task<RoleDto> GetByNameAndIdWorkerAsync(string name, int workerId)
        {
            return await _roleService.GetByNameAndIdWorkerAsync(name, workerId);
        }


        // POST api/<RoleController>
        [HttpPost]
        public async Task<RoleDto> PostAsync(RoleDto role)
        {
            return await _roleService.PostAsync(role);
        }

        // POST api/<RoleController>
        [HttpPost("{workerId}")]
        public async Task<RoleDto[]> PostAsyncArray(int workerId,[FromBody] RoleDto[] roleDtoArray)
        {
            return await _roleService.PostAsyncArray(workerId, roleDtoArray);
        }


        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<RoleDto> PutAsync(int id, RoleDto role)
        {
            return await _roleService.PutAsync(id, role);
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<Role> DeleteAsync(int id)
        {
            return await _roleService.DeleteAsync(id);
        }

        [HttpGet("workerId/{id}")]

        public async Task<IEnumerable<RoleDto>> GetRolesByIdWorkerAsync(int id)
        {
            return await _roleService.GetRolesByIdWorkerAsync(id);
        }

    }
}
