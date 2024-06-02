using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Entities
{
   public enum RoleNameOptions { TEACHER = 1, SECRETARY, PRINCIPLE, SUPERVISOR };

    public class Role
    {
        public int Id { get; set; }
        public RoleNameOptions RoleName { get; set; }
        public bool IsManagerial { get; set; }
        public DateTime StartRoleDate { get; set; }
        public Worker Worker { get; set; }
        public int WorkerId { get; set; }
    }
}
