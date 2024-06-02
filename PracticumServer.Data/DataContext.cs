using Microsoft.EntityFrameworkCore;
using PracticumServer.Core.Entities;
using PracticumServer.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticumServer.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
    }
}
