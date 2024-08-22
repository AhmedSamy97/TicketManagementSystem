namespace TicketManagementSystem.Domain.Entities
{
    public class Ticket
    {
        public Guid ID { get; set; }
        public DateTime CreatedAt { get; set; }
        public string PhoneNumber { get; set; }
        public string Governorate { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Status { get; set; } = "Pending";
        public string Color { get; set; } = "Yellow";

    }
}
