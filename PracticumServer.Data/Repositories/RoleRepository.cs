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
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public RoleRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RoleDto>> GetAsync()
        {
            var roles = _context.Roles.Include(w => w.Worker);
            return await Task.FromResult(_mapper.Map<IEnumerable<RoleDto>>(roles));
        }

        public async Task<RoleDto> GetByIdAsync(int id)
        {
            var role = _context.Roles.Where(x => x.Id == id).Include(w => w.Worker).First();
            return await Task.FromResult(_mapper.Map<RoleDto>(role));
        }

        public async Task<RoleDto> GetByNameAndIdWorkerAsync(string name, int workerId)
        {
            var roleName = Enum.Parse<RoleNameOptions>(name, true);
            var role = await _context.Roles
                .Include(w => w.Worker)
                .FirstOrDefaultAsync(x => x.RoleName == roleName && x.WorkerId == workerId);
            return await Task.FromResult(_mapper.Map<RoleDto>(role));
        }

        public async Task<IEnumerable<RoleDto>> GetRolesByIdWorkerAsync(int workerId)
        {
            return await Task.FromResult(_mapper.Map<IEnumerable<RoleDto>>(_context.Roles.Where(x => x.WorkerId == workerId)));
        }

        public async Task<RoleDto> PostAsync(RoleDto role)
        {
            _context.Roles.Add(_mapper.Map<Role>(role));
            await _context.SaveChangesAsync();
            return role;
        }

        public async Task<RoleDto[]> PostAsyncArray(int workerId, RoleDto[] roleDtoArray)
        {
            foreach (var role in roleDtoArray)
            {
                role.WorkerId = workerId;
                var existingRole = await _context.Roles
                    .FirstOrDefaultAsync(r => r.WorkerId == workerId && r.RoleName == role.RoleName);
                if (existingRole == null)
                {
                    _context.Roles.Add(_mapper.Map<Role>(role));
                }
            }
            await _context.SaveChangesAsync();
            return roleDtoArray;
        }

        public async Task<RoleDto> PutAsync(int id, RoleDto roleDto)
        {
            var role = _mapper.Map<Role>(roleDto);
            Role roleToUpdate = _context.Roles.Where(x => x.Id == id).First();
            if (roleToUpdate == null)
            {
                return null;
            }
            else
            {
                roleToUpdate.StartRoleDate = role.StartRoleDate;
                roleToUpdate.IsManagerial = role.IsManagerial;
                roleToUpdate.RoleName = role.RoleName;
                roleToUpdate.WorkerId = role.WorkerId;
            }
            await _context.SaveChangesAsync();
            return roleDto;
        }


        public async Task<Role> DeleteAsync(int id)
        {
            Role roleToDelete = _context.Roles.Where(x => x.Id == id).First();
            if (roleToDelete != null)
            {
                _context.Roles.Remove(roleToDelete);
            }
            await _context.SaveChangesAsync();
            return roleToDelete;
        }
    }
}