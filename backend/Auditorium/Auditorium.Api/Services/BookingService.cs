using Auditorium.Api.Database;
using Auditorium.Api.Dto;
using Auditorium.Api.Models;
using Azure.Core;
using Microsoft.EntityFrameworkCore;

namespace Auditorium.Api.Services
{
    public class BookingService
    {
        private readonly AppDbContext db;
        public BookingService(AppDbContext db) { this.db = db; }
        public async Task<int> CreateBookingAsync(CreateBookingRequest request)
        {
            Validate(request);
            var booking = new Booking
            {
                Name = request.Name,
                Phone = request.Phone,
                Email = request.Email,
                Address1 = request.Address1,
                Address2 = request.Address2,
                City = request.City,
                Pincode = request.Pincode,
                EventType = request.EventType,

                StartUtc = request.StartLocal.ToUniversalTime(),
                EndUtc = request.EndLocal.ToUniversalTime(),
                Status = "Requested"
            };
           

            db.Bookings.Add(booking);
            await db.SaveChangesAsync();
            return booking.Id;
        }

        public async Task<List<Booking>> GetBookingsByDateAsync(DateOnly date)
        {
            var start = date.ToDateTime(TimeOnly.MinValue).ToUniversalTime();
            var end = date.ToDateTime(TimeOnly.MaxValue).ToUniversalTime();

            return await db.Bookings.Where(b => b.StartUtc >= start && b.EndUtc <= end)
                .OrderBy(b => b.StartUtc)
                .ToListAsync();
        }
        public async Task<List<Booking>> GetBookingsByMonthAsync(int year, int month)
        {
            var start = new DateTime(year, month, 1, 0, 0, 0, DateTimeKind.Utc);
            var end = start.AddMonths(1);
            return await db.Bookings
                .Where(b=>b.StartUtc >= start && b.EndUtc <= end)
                .OrderBy(b => b.StartUtc)
                .ToListAsync();
        }

        internal async Task UpdateStatusAsync(int id, string status)
        {
            var booking = await db.Bookings.FindAsync(id);
            if (booking == null) throw new Exception("Booking not found!");
            booking.Status = status;
            await db.SaveChangesAsync();
        }

        private void Validate(CreateBookingRequest r)
        {
            if (string.IsNullOrWhiteSpace(r.Name))
                throw new ArgumentException("Name is required");

            if (r.StartLocal < DateTime.UtcNow)
                throw new ArgumentException("Cannot book past time");

            var start = r.StartLocal;
            var end = r.EndLocal;

            if (start.Hour < 6)
                throw new ArgumentException("Bookings can only start after 6 AM");

            if (end <= start)
                throw new ArgumentException("End time must be after start time");

            var midnight = start.Date.AddDays(1);

            if (end > midnight)
                throw new ArgumentException("Bookings must end by 12 AM (midnight)");
        }


    }
}
