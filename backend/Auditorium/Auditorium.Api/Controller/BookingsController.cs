using Auditorium.Api.Dto;
using Auditorium.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auditorium.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingService service;
        public BookingsController(BookingService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBookingRequest request)
        {
            try
            {
                var id = await service.CreateBookingAsync(request);
                return Ok(new { bookingId = id });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }
        [HttpGet("day/{date}")]
        ///api/bookings/day/2026-02-03
        public async Task<IActionResult> GetByDate(string date)
        {
            if(!DateOnly.TryParse(date, out var dateValue))
            {
                return BadRequest("Invalid date format. Use YYYY-MM-DD");
            }
            var bookings = await service.GetBookingsByDateAsync(dateValue);
            return Ok(bookings);
        }
        [HttpGet("month")]
        public async Task<IActionResult> GetByMonth([FromQuery] int year, [FromQuery] int month)
        {
            var bookings = await service.GetBookingsByMonthAsync(year, month);
            return Ok(bookings);
        }
    }
}
