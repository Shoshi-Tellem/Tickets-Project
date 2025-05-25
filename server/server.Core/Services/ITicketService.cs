using server.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Core.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync();
        Task<Ticket?> GetTicketByIdAsync(int id);
        Task<Ticket> AddTicketAsync(Ticket ticket);
        //Task<Ticket?> UpdateTicketAsync(int id, Ticket ticket);
        Task<Ticket?> UpdateTicketStatusAsync(int id, int status);
        Task<Ticket?> DeleteTicketAsync(int id);
    }
}
