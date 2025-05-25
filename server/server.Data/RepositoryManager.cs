using server.Core.Entities;
using server.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace server.Data
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DataContext _context;
        public IRepository<User> UserRepository { get; }
        public IRepository<Ticket> TicketRepository { get; }

        public RepositoryManager(DataContext context, IRepository<Ticket> ticketRepository, IRepository<User> userRepository)
        {
            _context = context;
            TicketRepository = ticketRepository;
            UserRepository = userRepository;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
