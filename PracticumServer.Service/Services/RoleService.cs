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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<IEnumerable<RoleDto>> GetAsync()
        {
            return await _roleRepository.GetAsync();
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            return await _roleRepository.GetByIdAsync(id);
        }

        public async Task<RoleDto> GetByNameAndIdWorkerAsync(string name, int workerId)
        {
            return await _roleRepository.GetByNameAndIdWorkerAsync(name, workerId);
        }

        public async Task<IEnumerable<RoleDto>> GetRolesByIdWorkerAsync(int workerId)
        {
            return await _roleRepository.GetRolesByIdWorkerAsync(workerId);
        }

        public async Task<RoleDto> PostAsync(RoleDto role)
        {
            return await _roleRepository.PostAsync(role);
        }

        public async Task<RoleDto[]> PostAsyncArray(int workerId, RoleDto[] roleDtoArray)
        {
            return await _roleRepository.PostAsyncArray(workerId, roleDtoArray);
        }


        public async Task<RoleDto> PutAsync(int id, RoleDto role)
        {
            return await _roleRepository.PutAsync(id, role);
        }


        public async Task<Role> DeleteAsync(int id)
        {
            return await _roleRepository.DeleteAsync(id);
        }
    }
}