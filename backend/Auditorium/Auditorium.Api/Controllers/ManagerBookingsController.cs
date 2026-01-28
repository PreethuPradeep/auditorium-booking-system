using Auditorium.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auditorium.Api.Controllers
{
    [Route("api/manager/bookings")]
    [Authorize(Roles = "Manager")]
    [ApiController]
    public class ManagerBookingsController : ControllerBase
    {
        private readonly BookingService service;
        public ManagerBookingsController(BookingService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetByDate([FromQuery] DateOnly date)
        {
            var bookings = await service.GetBookingsByDateAsync(date);
            return Ok(bookings);
        }
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> Approve(int id)
        {
            await service.UpdateStatusAsync(id, "Approved");
            return NoContent();
        }
        public async Task<IActionResult> Reject(int id)
        {
            await service.UpdateStatusAsync(id, "Rejected");
            return NoContent();
        }
    }
}
