using Microsoft.AspNetCore.Mvc;
using SWP.CourtBooking.API.Models.BookingModel;
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

        [HttpDelete("{id}")]
        public ActionResult DeleteBookings(String id)
        {
            var existedBookingEntity = _unitOfWork.BookingRepository.GetByID(id);
            _unitOfWork.BookingRepository.Delete(existedBookingEntity);
            _unitOfWork.Save();
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult GetBookingById(string id)
        {
            var responseBooking = _unitOfWork.BookingRepository.GetByID(id);
            return Ok(responseBooking);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(String id, RequestCreateBookingModel requestCreateBookingModel)
        {
            var existedBooking = _unitOfWork.BookingRepository.GetByID(id);
            if (existedBooking != null)
            {
                existedBooking.Code = requestCreateBookingModel.Code;
                existedBooking.Status = requestCreateBookingModel.Status;
                existedBooking.CreatedAt = requestCreateBookingModel.CreatedAt;
                existedBooking.CustomerId = requestCreateBookingModel.CustomerId;
                existedBooking.CourtClusterId = requestCreateBookingModel.CourtClusterId;
                existedBooking.FromTime = requestCreateBookingModel.FromTime;
                existedBooking.ToTime = requestCreateBookingModel.ToTime;
            }
            _unitOfWork.BookingRepository.Update(existedBooking);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
