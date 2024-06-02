using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Core.Entities
{
    public enum GenderType { MALE = 1, FEMALE };
    public class Worker
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public int IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public GenderType Gender { get; set; }
        public List<Role> Roles { get; set; }
        public bool Status { get; set; }
    }
}
