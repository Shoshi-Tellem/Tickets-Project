using System.ComponentModel.DataAnnotations;

namespace server.Core.Entities
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int StatusId { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public string Solution { get; set; }
    }
}
