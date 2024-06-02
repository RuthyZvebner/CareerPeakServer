using PracticumServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Dtos
{
    public class RoleDto
    {
        public int Id { get; set; }
        public RoleNameOptions RoleName { get; set; }
        public bool IsManagerial { get; set; }
        public DateTime StartRoleDate { get; set; }
        public int WorkerId { get; set; }
    }
}
