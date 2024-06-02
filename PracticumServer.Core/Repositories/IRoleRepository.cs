using PracticumServer.Core.Dtos;
using PracticumServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Repositories
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleDto>> GetAsync();

        Task<RoleDto> GetByIdAsync(int id);

        Task<RoleDto> GetByNameAndIdWorkerAsync(string name, int workerId);

        Task<RoleDto> PostAsync(RoleDto roleDto);

        Task<RoleDto[]> PostAsyncArray(int workerId, RoleDto[] roleDtoArray);

        Task<RoleDto> PutAsync(int id, RoleDto roleDto);

        Task<Role> DeleteAsync(int id);

        Task<IEnumerable<RoleDto>> GetRolesByIdWorkerAsync(int workerId);
    }
}
