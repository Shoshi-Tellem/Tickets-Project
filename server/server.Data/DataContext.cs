using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Data
{
    public class DataContext(IConfiguration configuration) : DbContext
    {
        private readonly IConfiguration _configuration = configuration;
        public DbSet<User> User { get; set; }
        public DbSet<Ticket> Ticket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["DbConnectionString"]);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
    }
}
