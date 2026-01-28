namespace Auditorium.Api.Models
{

    public class Booking
    {

        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public int Pincode { get; set; }

        public string Email { get; set; } = string.Empty;

        public DateTime StartUtc { get; set; }
        public DateTime EndUtc { get; set; }

        public string EventType { get; set; } = string.Empty;
        public string Status { get; set; } = "Requested";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
