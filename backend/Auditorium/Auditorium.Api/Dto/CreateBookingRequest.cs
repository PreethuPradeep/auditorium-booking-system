using System.ComponentModel.DataAnnotations;

namespace Auditorium.Api.Dto
{
    public class CreateBookingRequest
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Address1 { get; set; } = string.Empty;

        public string? Address2 { get; set; }

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public int Pincode { get; set; }
        //local time from client gets converted to utc before ending in db
        [Required]
        public DateTime StartLocal { get; set; }

        [Required]
        public DateTime EndLocal { get; set; }

        [Required]
        public string EventType { get; set; } = string.Empty;
    }


}
