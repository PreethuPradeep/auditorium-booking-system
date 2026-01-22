namespace Auditorium.Api.Dto
{
    public class CreateBookingRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Pincode { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public DateTime StartLocal { get; set; }
        public DateTime EndLocal { get; set; }

        public string EventType { get; set; } = string.Empty;

    }
}
