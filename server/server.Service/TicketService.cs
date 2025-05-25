using server.Core.Entities;
using server.Core.Repositories;
using server.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server.Service
{
    public class TicketService(IRepositoryManager repositoryManager) : ITicketService
    {
        private readonly IRepositoryManager _repositoryManager = repositoryManager;
        private readonly IRepository<Ticket> _ticketRepository = repositoryManager.TicketRepository;

        public async Task<IEnumerable<Ticket>> GetTicketsAsync()
        {
            return await _ticketRepository.GetAsync();
        }
        public async Task<Ticket?> GetTicketByIdAsync(int id)
        {
            return await _ticketRepository.GetByIdAsync(id);
        }
        public async Task<Ticket> AddTicketAsync(Ticket ticket)
        {
            Ticket addedTicket = await _ticketRepository.AddAsync(ticket);
            await _repositoryManager.SaveAsync();
            return addedTicket;
        }
        //public async Task<Ticket?> UpdateTicketAsync(int id, Ticket ticket)
        //{
        //    Ticket? existingTicket = await GetTicketByIdAsync(id);
        //    if (existingTicket == null)
        //        return null;
        //    existingTicket.FullName = ticket.FullName;
        //    existingTicket.Email = ticket.Email;
        //    existingTicket.Description = ticket.Description;
        //    existingTicket.ImageUrl = ticket.ImageUrl;
        //    Ticket updatedTicket = await _ticketRepository.UpdateAsync(existingTicket);
        //    await _repositoryManager.SaveAsync();
        //    return updatedTicket;
        //}
        public async Task<Ticket?> UpdateTicketStatusAsync(int id, int status)
        {
            Ticket? existingTicket = await GetTicketByIdAsync(id);
            if (existingTicket == null)
                return null;
            existingTicket.StatusId = status;
            Ticket updatedTicket = await _ticketRepository.UpdateAsync(existingTicket);
            await _repositoryManager.SaveAsync();
            return updatedTicket;
        }
        public async Task<Ticket?> DeleteTicketAsync(int id)
        {
            Ticket? existingTicket = await GetTicketByIdAsync(id);
            if (existingTicket == null)
                return null;
            Ticket? deletedTicket = await _ticketRepository.DeleteAsync(existingTicket);
            await _repositoryManager.SaveAsync();
            return deletedTicket;
        }
    }
}
