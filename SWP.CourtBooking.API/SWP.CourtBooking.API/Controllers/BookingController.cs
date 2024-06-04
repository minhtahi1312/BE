using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.Repository.UnitOfWork;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SWP.CourtBooking.API.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private IUnitOfWork _unitOfWork;

        public BookingController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetBookings()
        {
            var bookings = _unitOfWork.BookingRepository.Get();
            return Ok(bookings);
        }
    }
}
